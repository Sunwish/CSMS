using System;
using System.Collections.Generic;
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
    /// MainFrm.xaml 的交互逻辑
    /// </summary>
    public partial class MainFrm : Window
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void MenuItem_Click_Add(object sender, RoutedEventArgs e)
        {
            CommodityAddWindow add = new CommodityAddWindow();
            add.Show();
        }

        private void MenuItem_Click_Search(object sender, RoutedEventArgs e)
        {
            SearchWindow search= new SearchWindow();// 创建主窗体对象                    
            search.Show();// 显示窗体                   
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow update = new UpdateWindow();
            update.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SalesRecordsWindow sales = new SalesRecordsWindow();
            sales.Show();
        }
    }
}
