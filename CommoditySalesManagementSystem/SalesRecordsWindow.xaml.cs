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

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql1 = "select * from [Table]";

            try    //try里面放可能出现错误的代码
            {
                SqlConnection con = new SqlConnection(connString);
                SqlDataReader read = SqlRead(con, sql1);
                while (read.Read())
                {
                    int ID = Convert.ToInt32(read["Id"]);
                    string count = read["Count"].ToString();
                    listView.Items.Add(new Item { Id = ID.ToString().Trim(), Count = count.ToString().Trim()});
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private SqlDataReader SqlRead(SqlConnection con, string sqlString)
        {
            con.Open();// 打开数据库连接           
            SqlCommand com = new SqlCommand(sqlString, con); //创建 Command 对象
            try
            {
                SqlDataReader read = com.ExecuteReader();  //用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                return read;
            }
            catch (Exception) { throw; }
        }
    }
}
