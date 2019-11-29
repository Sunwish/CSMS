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
    public class Item
    {
        public string Id { get; set; }
        public string Count { get; set; }
    }
    /// <summary>
    /// SalesRecordsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SalesRecordsWindow : Window
    {
        public SalesRecordsWindow()
        {
            InitializeComponent();

            string sql1 = "select * from [Table]";
            try    //try里面放可能出现错误的代码
            {
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                for(int i = 0; i < ids.Count; i++)
                    listView.Items.Add(new Item { Id = ids[i].Trim(), Count = counts[i].Trim()});
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
