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
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)  //查询货物
        {
            listbox1.Items.Clear();
            string sql1 = "select * from Commondity";
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                    listbox1.Items.Add(ids[i].Trim() + "  " + names[i].Trim() + "  " + prices[i].Trim() + "  " + counts[i].Trim());
            }
            catch (Exception ex){ Console.WriteLine(ex.Message); }
        }

        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listbox1.Items.Clear();
            string sql1 = String.Format("select * from Commondity where Name='{0}'", context1.Text);
            try
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> names = SqlManager.ReadColumn(sql1, "Name");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                for (int i = 0; i < ids.Count; i++)
                    listbox1.Items.Add(ids[i].Trim() + "  " + names[i].Trim() + "  " + prices[i].Trim() + "  " + counts[i].Trim());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
