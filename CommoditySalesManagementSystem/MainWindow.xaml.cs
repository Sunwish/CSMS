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
            // ShowMainFrm();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            Login(TextBox_UserName.Text, TextBox_Password.Password, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void Login(string userName, string password, string connString)
        {
            //获取用户名和密码匹配的行的数量的SQL语句
            string sql = String.Format("select count(*) from [User] where userName='{0}'and password='{1}'", userName, GetPasswordEncryption(password));
            try
            {
                if ((int)SqlManager.ExecuteScalar(sql) > 0)
                {
                    //如果有匹配的行,则表明用户名和密码正确
                    MessageBox.Show("欢迎进入商品销售管理系统！", "登录成功", 0, MessageBoxImage.Information);
                    ShowMainFrm();
                }
                else MessageBox.Show("您输入的用户名或密码错误！", "登录失败", 0, MessageBoxImage.Exclamation);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "操作数据库出错！", 0, MessageBoxImage.Exclamation); }
        }

        private void ShowMainFrm(bool closeThisFrm = true)
        {
            MainFrm mainForm = new MainFrm(); // 创建主窗体对象                    
            mainForm.Show(); // 显示窗体                   
            if(closeThisFrm)  this.Close();
        }

        private void TextBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                e.Handled = true;
                Login(TextBox_UserName.Text, TextBox_Password.Password, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        private static string GetPasswordEncryption(string pw)
        {
            StringBuilder sb = new StringBuilder();
            using (IEnumerator<char> ieor = pw.Reverse().GetEnumerator())
            {
                while (ieor.MoveNext())
                    sb.Append(ieor.Current);
            }
            string pwReverse = sb.ToString();
            return CreateMD5(pw + pwReverse);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}
