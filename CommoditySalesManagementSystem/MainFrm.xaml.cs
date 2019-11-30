using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CommoditySalesManagementSystem
{
    public class PaymentItemInfo
    {
        public string Id { get; set; }
        public string Count { /*get => _count; set { _count = value; SumPrice = (int.Parse(_singlePrice) * float.Parse(value)).ToString(); }*/ get; set; }
        public string Name { get; set; }
        public string SinglePrice { /*get => SinglePrice; set { _singlePrice = value; SumPrice = (int.Parse(_count) * float.Parse(value)).ToString(); }*/ get; set; }
        public string SumPrice { get; set; }
    }

    /// <summary>
    /// MainFrm.xaml 的交互逻辑
    /// </summary>
    public partial class MainFrm : Window
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void ShowWindow<T>() where T : Window, new()
        {
            T window = new T();
            window.Show();
        }

        private void MenuItem_Click_Add(object sender, RoutedEventArgs e)
        {
            ShowWindow<CommodityAddWindow>();
        }

        private void MenuItem_Click_Search(object sender, RoutedEventArgs e)
        {
            ShowWindow<SearchWindow>();                 
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<UpdateWindow>();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ShowWindow<SalesRecordsWindow>();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ShowWindow<SalesCalculation>();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)//tianjia
        {
            if(Brushes.Red == context1.Foreground || Brushes.Red == context2.Foreground)
            {
                MessageBox.Show("商品ID不存在或库存不足，添加失败。", "操作失败", 0, MessageBoxImage.Error);
                return;
            }

            string sql1 = String.Format("select * from Commondity where Id='{0}'", context1.Text);
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                    ItemList.Items.Add(new PaymentItemInfo { Id = ids[i].Trim(), Count = context2.Text.Trim(), SinglePrice = prices[i].Trim(), Name = names[i].Trim(), SumPrice = (int.Parse(context2.Text.Trim()) * float.Parse(prices[i].Trim())).ToString() });
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Button2_Click(object sender, RoutedEventArgs e) //结算
        {
            // string sql1 = String.Format("select Count from Table where Name='{0}'", context1.Text);
            // int c = int.Parse(SqlManager.ReadColumn(sql1, "Count")[0]);

            List<PaymentItemInfo> successedList = new List<PaymentItemInfo>();
            List<PaymentItemInfo> failedList = new List<PaymentItemInfo>();

            try
            {
                foreach (PaymentItemInfo info in ItemList.Items)
                {
                    string sql = String.Format("INSERT INTO Sale(Id, Count, Price) VALUES('{0}','{1}','{2}')", info.Id, info.Count, info.SinglePrice);

                    try
                    {
                        SqlManager.ExecuteCommand(String.Format("update Commondity set Count={0} where Id={1}", int.Parse(SqlManager.ReadColumn(String.Format("select * from Commondity where Id='{0}'", info.Id), "Count")[0]) - int.Parse(info.Count), info.Id));
                        SqlManager.ExecuteCommand(sql);
                    } catch (Exception) { failedList.Add(info); continue; }
                    successedList.Add(info);
                }
                if(ItemList.Items.Count - failedList.Count > 0)
                {
                    context1.Text = context2.Text = "";
                    foreach (PaymentItemInfo pi in successedList)
                        ItemList.Items.Remove(pi);
                    if (0 == failedList.Count)
                        MessageBox.Show("结算成功！", "结算成功", 0, MessageBoxImage.Information);
                    else
                    {
                        string failedString = "";
                        foreach (PaymentItemInfo pi in failedList)
                            failedString += pi.Id + " " + pi.Name + Environment.NewLine;
                        MessageBox.Show(successedList.Count + "样商品结算成功，以下是结算失败的商品：" + Environment.NewLine + failedString);
                    }
                }
                else
                {
                    MessageBox.Show("结算失败！", "结算失败", 0, MessageBoxImage.Error);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void context1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sql1 = String.Format("select * from Commondity where Id='{0}'", context1.Text);
            try
            {
                if ("" == context1.Text) ItemInfo.Content = ""; else { ItemInfo.Content = "未找到商品信息"; context1.Foreground = Brushes.Red; }
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                {
                    context1.Foreground = context2.Foreground = Brushes.Black;
                    ItemInfo.Content = names[i].Trim() + "  单价：" + prices[i].Trim() + "  库存：" + counts[i].Trim() + "件";
                    if (int.Parse(context2.Text) > int.Parse(counts[i])) context2.Foreground = Brushes.Red;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void context2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sql1 = String.Format("select * from Commondity where Id='{0}'", context1.Text);
            try
            {
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                context2.Foreground = Brushes.Black;
                for (int i = 0; i < counts.Count; i++)
                    if (int.Parse(context2.Text) > int.Parse(counts[i])) context2.Foreground = Brushes.Red;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            // 还有一个隐患在于单次结算场景下的分配请求超量，例如库存为10时一次性不可添加11个，但可以先添加5个，再添加6个，显然不符合实际。
        }
    }
}
