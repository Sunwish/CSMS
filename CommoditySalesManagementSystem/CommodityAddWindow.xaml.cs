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
    /// CommodityAddWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CommodityAddWindow : Window
    {
        public CommodityAddWindow()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connString);
            string sql = String.Format("INSERT INTO Commondity(Id, Name, Count, Price) VALUES('{0}','{1}','{2}','{3}')", ItemId.Text, ItemName.Text, ItemCount.Text, ItemPrice.Text); //SQL语句
            try
            {
                connection.Open(); // 打开数据库连接           
                SqlCommand command = new SqlCommand(sql, connection); //创建 Command 对象
                int count = command.ExecuteNonQuery(); // 执行添加命令,返回值为更新的行数
                if (count > 0)  MessageBox.Show("添加商品信息成功", "添加成功", MessageBoxButton.OK, MessageBoxImage.Information);
                else MessageBox.Show("添加商品信息失败", "添加失败", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            finally { connection.Close(); }
        }
    }
}
