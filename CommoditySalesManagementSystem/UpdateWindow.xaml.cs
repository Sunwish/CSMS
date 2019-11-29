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

        private void Button_Click(object sender, RoutedEventArgs e) //更改商品价格
        {
            string sql = String.Format("update  Commondity set Price='{0}'where Name='{1}'", context2.Text, context.Text);
            try
            {
                if (SqlManager.ExecuteCommand(sql) > 0)
                    MessageBox.Show("修改成功！", "修改成功", 0, MessageBoxImage.Information);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //更改商品名称
        {
            string sql = String.Format("update  Commondity set Name='{0}'where Name='{1}'", context3.Text, context.Text);
            try
            {
                if(SqlManager.ExecuteCommand(sql) > 0)
                    MessageBox.Show("修改成功！", "修改成功", 0, MessageBoxImage.Information);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
