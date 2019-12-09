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
    public class SaltInfo
    {
        public string Id { get; set; }
        public string Count { get; set; }
        public string Name { get; set; }
        public string Money { get; set; }
        public string Time { get; set; }
    }

    /// <summary>
    /// SalesCalculation.xaml 的交互逻辑
    /// </summary>
    public partial class SalesCalculation : Window
    {
        public SalesCalculation()
        {
            InitializeComponent();

            string sql1 = "select * from [Commondity]";
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = new List<string>();
                List<string> moneys = new List<string>();
                foreach (string id in ids)
                {
                    int count = 0;
                    float money = 0;
                    string sql_Id2Name = "select * from [Sale] where Id=" + id;
                    List<string> c = SqlManager.ReadColumn(sql_Id2Name, "Count");
                    List<string> p = SqlManager.ReadColumn(sql_Id2Name, "Price");
                    for(int i = 0; i < c.Count; i++)
                    { count += int.Parse(c[i]); money += int.Parse(c[i]) * float.Parse(p[i]); }
                    counts.Add(count.ToString());
                    moneys.Add(money.ToString());
                }

                float sum = 0;
                for (int i = 0; i < ids.Count; i++)
                { listView.Items.Add(new SaltInfo { Id = ids[i].Trim(), Count = counts[i].Trim(), Name = names[i].Trim(), Money = moneys[i].Trim() }); sum += float.Parse(moneys[i]); }

                Label_Sum.Content = "销售总额：" + sum;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "查询失败", 0, MessageBoxImage.Error); }
        }

        private void listView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SaltInfo si = listView.SelectedItem as SaltInfo;
            if (null != si)
            {
                e.Handled = true;
                new SalesRecordsWindow(si.Id).Show();
            }
        }
    }
}
