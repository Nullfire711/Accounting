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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Accounting.Model.AppData;
namespace Accounting.Pages
{

    public partial class EmpList : Page
    {
        public EmpList()
        {
            InitializeComponent();
            LVEmp.ItemsSource = Context.Employee.ToList();
        }

        private void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowClientAdd = new WindowAdd();
            windowClientAdd.ShowDialog();
            LVEmp.ItemsSource = Context.Employee.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVEmp.SelectedItem is Employee employee)
            {
                IDEmp = employee.ID;
                WindowEdit windowEditClient = new WindowEdit();
                windowEditClient.ShowDialog();
                LVEmp.ItemsSource = Context.Employee.ToList();
            }
            else
            {
                MessageBox.Show("Выберите пользователя из списка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LVEmp.SelectedItem is Employee employee)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить запись?",
                                         "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                        Context.Employee.Remove(Context.Employee.Where(i => i.ID == employee.ID).FirstOrDefault());
                        Context.SaveChanges();
                        MessageBox.Show("Запись успешно удалена",
                                        "Удаление пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
                        LVEmp.ItemsSource = Context.Employee.ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя из списка",
                                "Удаление пользователя", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LVEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
