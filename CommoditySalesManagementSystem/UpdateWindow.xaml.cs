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
    /// UpdateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//更改商品价格
        {
            // listbox1.Items.Clear();
            string Name = context.Text;
             string money = context2.Text;
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql1 = String.Format("updata  Commondity set Price='{0}'where Name='{1}'", money, Name);
            try    //try里面放可能出现错误的代码
            {
                SqlConnection con = new SqlConnection(connString);
               // SqlConnection con = new SqlConnection(connString);
                con.Open();// 打开数据库连接           
                SqlCommand com = new SqlCommand(sql1, con); //创建 Command 对象
                int read = com.ExecuteNonQuery();

                if (read > 0)
                    MessageBox.Show("修改成功！", "修改成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//更改商品名称
        {
            // listbox1.Items.Clear();
            string n = context3.Text;
            string Name = context.Text;
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql1 = String.Format("update  Commondity set Name='{0}'where Name='{1}'", n, Name);
            try    //try里面放可能出现错误的代码
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();// 打开数据库连接           
                SqlCommand com = new SqlCommand(sql1, con); //创建 Command 对象
                int read = com.ExecuteNonQuery();

              //  if(read>0)
                MessageBox.Show("修改成功！", "修改成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception) { Console.WriteLine("哈哈哈网络异常啦!"); }
        }
        
    }
}
