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

        private void Button1_Click(object sender, RoutedEventArgs e)//tianjia
        {
            //context3.Items.Clear();
            string sql1 = String.Format("select * from Commondity where Id='{0}'", context1.Text);
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                    context3.Items.Add(ids[i].Trim() + " 商品名称：  " + names[i].Trim() + "    价格为：  " + prices[i].Trim());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)//结算
        {
           // string sql1 = String.Format("select Count from Table where Name='{0}'", context1.Text);
           // int c = int.Parse(SqlManager.ReadColumn(sql1, "Count")[0]);

            string sql = String.Format("INSERT INTO Sale(Id, Count) VALUES('{0}','{1}')", int.Parse(context1.Text), context2.Text);
           
            try
            {
                if (SqlManager.ExecuteCommand(sql) > 0)
                    MessageBox.Show("结算成功！", "结算成功", 0, MessageBoxImage.Information);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
    }

