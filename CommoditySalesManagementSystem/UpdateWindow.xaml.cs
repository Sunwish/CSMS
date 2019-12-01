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
            TextBox_Id.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //更改商品价格
        {
            string sql = String.Format("update Commondity set Price='{0}',Count='{1}',Name='{2}' where Id='{3}'", TextBox_SinglePrice.Text,TextBox_Count.Text, TextBox_Name.Text, TextBox_Id.Text);
            try
            {
                if (SqlManager.ExecuteCommand(sql) > 0)
                    MessageBox.Show("修改成功！", "修改成功", 0, MessageBoxImage.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "修改失败", 0, MessageBoxImage.Error); }
        }

        private void TextBox_Id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ("" == TextBox_Id.Text) return;
            TextBox_Id.Foreground = Brushes.Red;
            TextBox_Name.Text = TextBox_Count.Text = TextBox_SinglePrice.Text = "";
            string sql = String.Format("select * from [Commondity] where Id={0}", TextBox_Id.Text);
            List<string> names = SqlManager.ReadColumn(sql, "Name");
            List<string> prices = SqlManager.ReadColumn(sql, "Price");
            List<string> counts = SqlManager.ReadColumn(sql, "Count");
            for(int i = 0; i < names.Count; i++)
            {
                TextBox_Id.Foreground = Brushes.Black;
                TextBox_Name.Text = names[i].Trim();
                TextBox_SinglePrice.Text = prices[i].Trim();
                TextBox_Count.Text = counts[i].Trim();
            }
        }
    }
}
