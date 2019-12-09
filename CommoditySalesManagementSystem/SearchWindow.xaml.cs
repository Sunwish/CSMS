using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// SearchWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SearchWindow : Window
    {

        public SearchWindow()
        {
            InitializeComponent();
            context1.Focus();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)  //查询货物
        {
            ItemList.Items.Clear();
            string sql1 = "select * from Commondity";
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                    ItemList.Items.Add(new { Id = ids[i].Trim(), Name = names[i].Trim(), SinglePrice = prices[i].Trim(), Count = counts[i].Trim() });
            }
            catch (Exception ex){ MessageBox.Show(ex.Message, "查询失败", 0, MessageBoxImage.Error); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String key = context1.Text;
            ItemList.Items.Clear();



            ItemList.Items.Add("id".Trim()+ "name".Trim()+"Count".Trim()+ "price".Trim());
            string sql1 = String.Format("select * from Commondity where Id='{0}'", context1.Text);
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                    ItemList.Items.Add(new { Id = ids[i].Trim(), Name = names[i].Trim(), SinglePrice = prices[i].Trim(), Count = counts[i].Trim() });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "查询失败", 0, MessageBoxImage.Error); }
        }
    }
}
