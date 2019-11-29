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

        private void ShowWindow<T>() where T : Window, new()
        {
            T window = new T();
            window.Show();
        }

        private void MenuItem_Click_Add(object sender, RoutedEventArgs e)
        {
            ShowWindow<CommodityAddWindow>();
        }

        private void MenuItem_Click_Search(object sender, RoutedEventArgs e)
        {
            ShowWindow<SearchWindow>();                 
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<UpdateWindow>();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ShowWindow<SalesRecordsWindow>();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ShowWindow<SalesCalculation>();
        }
    }
}
