﻿using System;
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CommodityAddWindow addForm = new CommodityAddWindow();// 创建主窗体对象
            addForm.Show();// 显示窗体
        }
    }
}
