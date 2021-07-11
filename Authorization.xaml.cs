using Accounting.Model;
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
using static Accounting.ClassHelper.Authorization;
using static Accounting.Model.AppData;

namespace Accounting
{

    public partial class Authorization : Window
    {
        public UserData User;

        public enum Status
        {
            admin = 1,
            user
        }

        public struct UserData
        {
            public User user { get; set; }
            public Status status { get; set; }
        }

        private string login, password;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }



        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public Authorization()
        {
            InitializeComponent();
        }



        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            var user = Context.User.Where(i => i.Login == TBLogin.Text).Where(i => i.Password == PBPassword.Password);

            if (user.Count() > 0)
            {

                User.user = user.FirstOrDefault();

                if (User.user.ID == 1)
                {
                    User.status = Status.admin;
                    setUser(user.FirstOrDefault());
                    MessageBox.Show("Вы успешно вошли как администратор");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    User.status = Status.user;
                    MessageBox.Show("Вы успешно вошли как пользователь");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

        }
    }
}
