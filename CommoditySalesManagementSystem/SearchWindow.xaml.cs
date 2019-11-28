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
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql1 = "select * from Commondity";

            try    //try里面放可能出现错误的代码
            {
                SqlConnection con = new SqlConnection(connString);
                SqlDataReader read = SqlRead(con, sql1);  //用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                while (read.Read())
                {
                    int ID = Convert.ToInt32(read["Id"]);
                    string name = read["Name"].ToString();
                    string count = read["Count"].ToString();
                    string price = read["Price"].ToString();
                    listbox1.Items.Add(ID.ToString().Trim() + "  " + name.ToString().Trim() + "  " + price.ToString().Trim() + "  " + count.ToString().Trim());
                }
            }
            catch (Exception){Console.WriteLine("网络异常!");}
        }

        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listbox1.Items.Clear();
            string Name = context1.Text;
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql1 = String.Format("select * from Commondity where Name='{0}'", Name);

            try    //try里面放可能出现错误的代码
            {
                SqlConnection con = new SqlConnection(connString);
                SqlDataReader read = SqlRead(con, sql1);
                while (read.Read())
                {
                    int ID = Convert.ToInt32(read["Id"]);
                    string name = read["Name"].ToString();
                    string count = read["Count"].ToString();
                    string price = read["Price"].ToString();
                    listbox1.Items.Add(ID.ToString().Trim() + "  " + name.ToString().Trim() + "  " + price.ToString().Trim() + "  " + count.ToString().Trim());
                }
            }
            catch (Exception){ Console.WriteLine("网络异常!"); }
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
