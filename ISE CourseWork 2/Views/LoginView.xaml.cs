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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginView : Page
    {

        public LoginView()
        {
            InitializeComponent();
        }

        private void BtnClick_Login(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new EaterHomeView();
            ((MainWindow)App.Current.MainWindow).UpdateView("toast");
        }
    }
}
