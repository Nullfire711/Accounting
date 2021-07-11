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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Accounting.ClassHelper.Authorization;
using static Accounting.Model.AppData;

namespace Accounting
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Username.Text = getUsername();
        }

        private void ClientListBtn_Click(object sender, RoutedEventArgs e)
        {
                FRMain.Navigate(new Uri("Pages/EmpList.xaml", UriKind.Relative));
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
                FRMain.Navigate(new Uri("Pages/Service.xaml", UriKind.Relative));
        }

        private void BookBtn_Click(object sender, RoutedEventArgs e)
        {
                FRMain.Navigate(new Uri("Pages/Book.xaml", UriKind.Relative));
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization LogScr  = new Authorization();
            LogScr.Show();
            this.Close();
        }
    }
}
