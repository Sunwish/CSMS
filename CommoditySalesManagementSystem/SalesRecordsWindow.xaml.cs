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
    /// SalesRecordsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SalesRecordsWindow : Window
    {
        public SalesRecordsWindow()
        {
            InitializeComponent();

            string sql1 = "select * from [Sale]";
            try
            {
                List<string> names = new List<string>();
                List<string> ids = SqlManager.ReadColumn(sql1, "Id");
                List<string> counts = SqlManager.ReadColumn(sql1, "Count");
                List<string> prices = SqlManager.ReadColumn(sql1, "Price");
                List<string> times = SqlManager.ReadColumn(sql1, "Time");
                foreach (string id in ids)
                {
                    string sql_Id2Name = "select * from [Commondity] where Id=" + id;
                    names.Add(SqlManager.ReadColumn(sql_Id2Name, "name")[0]);
                }
                for (int i = 0; i < ids.Count; i++)
                    listView.Items.Add(new SaltInfo { Id = ids[i].Trim(), Count = counts[i].Trim(), Name = names[i].Trim(), Money = prices[i].Trim(), Time = times[i].Trim()});
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "查询失败", 0, MessageBoxImage.Error); }

        }
    }
}
