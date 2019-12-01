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
            ItemId.Focus();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string sql = String.Format("INSERT INTO Commondity(Id, Name, Count, Price) VALUES('{0}','{1}','{2}','{3}')", ItemId.Text, ItemName.Text, ItemCount.Text, ItemPrice.Text); //SQL语句
            try
            {        
                if (SqlManager.ExecuteCommand(sql) > 0)  MessageBox.Show("添加商品信息成功", "添加成功", 0, MessageBoxImage.Information);
                else MessageBox.Show("添加商品信息失败", "添加失败", 0, MessageBoxImage.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "添加失败！", 0, MessageBoxImage.Error); }
        }
    }
}
