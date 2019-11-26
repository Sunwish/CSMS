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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommoditySalesManagementSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBox_UserName.Focus();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            Login(TextBox_UserName.Text, TextBox_Password.Password, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void Login(string userName, string password, string connString)
        {
            SqlConnection connection = new SqlConnection(connString);
            //获取用户名和密码匹配的行的数量的SQL语句
            string sql = String.Format("select count(*) from [User] where userName='{0}'and password='{1}'", userName, password);
            try
            {
                connection.Open();// 打开数据库连接           
                SqlCommand command = new SqlCommand(sql, connection); //创建 Command 对象
                int num = (int)command.ExecuteScalar();//执行查询语句,返回匹配的行数
                if (num > 0)
                {
                    //如果有匹配的行,则表明用户名和密码正确
                    MessageBox.Show("欢迎进入商品销售管理系统！", "登录成功", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainFrm mainForm = new MainFrm();// 创建主窗体对象                    
                    mainForm.Show();// 显示窗体                   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("您输入的用户名或密码错误！", "登录失败", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            finally
            {
                connection.Close();// 关闭数据库连接
            }
        }

        private void TextBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                e.Handled = true;
                Login(TextBox_UserName.Text, TextBox_Password.Password, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
    }
}
