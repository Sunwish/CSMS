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
                SqlConnection con= new SqlConnection(connString);
               
                //string sql = String.Format("select * from Commondity");
                string sql1 = "select * from Commondity";
                con.Open();// 打开数据库连接           
                SqlCommand com = new SqlCommand(sql1, con); //创建 Command 对象
                try    //try里面放可能出现错误的代码
               {

                SqlDataReader read = com.ExecuteReader();  //用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型

                while (read.Read()) 
                                   
                {

                    int ID = Convert.ToInt32(read["Id"]);

                    string name = read["Name"].ToString(); 

                    string count = read["Count"].ToString();

                    string price = read["Price"].ToString();

                    // int day = Convert.ToInt32(read["列名5"]);
                    listbox1.Items.Add(ID.ToString()+ "  "+ name.ToString()+ price.ToString() + count.ToString());
                    //listbox1.Items.Add(name.ToString());
                    //listbox1.Items.Add(name.ToString());
                    //listbox1.Items.Add(price.ToString());
  

                }
            }
            catch (Exception) //当try中有错误则执行catch中的代码,否则不执行

            {

                Console.WriteLine("网络异常!");

            }

            finally //无论如何都会执行finally中的代码

            {

                if (con != null) //判断con不为空

                {

                    con.Close();

                }
            }


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listbox1.Items.Clear();
            string Name = context1.Text;
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);

           // string sql = String.Format("select * from Commondity");
           // "select * from Commondity where name=";
            string sql1 = String.Format("select * from Commondity where Name='{0}'", Name);
            con.Open();// 打开数据库连接           
            SqlCommand com = new SqlCommand(sql1, con); //创建 Command 对象
            try    //try里面放可能出现错误的代码
            {

                SqlDataReader read = com.ExecuteReader();  //用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型

                while (read.Read())

                {

                    int ID = Convert.ToInt32(read["Id"]);

                    string name = read["Name"].ToString();

                    string time = read["Count"].ToString();

                    string price = read["Price"].ToString();

                    // int day = Convert.ToInt32(read["列名5"]);
                    listbox1.Items.Add(ID.ToString() + "  " + name.ToString() + price.ToString());
                    //listbox1.Items.Add(name.ToString());
                    //listbox1.Items.Add(name.ToString());
                    //listbox1.Items.Add(price.ToString());


                }
            }
            catch (Exception) //当try中有错误则执行catch中的代码,否则不执行

            {

                Console.WriteLine("网络异常!");

            }

            finally //无论如何都会执行finally中的代码

            {

                if (con != null) //判断con不为空

                {

                    con.Close();

                }
            }
        }
    }
}
