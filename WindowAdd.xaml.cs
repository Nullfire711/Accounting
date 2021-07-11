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
using static Accounting.Model.AppData;

namespace Accounting
{

    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
            CBRole.ItemsSource = Context.Position.Select(i => i.Name).ToList();
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TBSecondName.Text) ||
               string.IsNullOrWhiteSpace(TBFirstName.Text) ||
               string.IsNullOrWhiteSpace(TBPhone.Text) ||
               string.IsNullOrWhiteSpace(TBEmail.Text) ||
               string.IsNullOrWhiteSpace(TBEmail.Text) ||
               string.IsNullOrWhiteSpace(TBTax.Text) ||
               string.IsNullOrWhiteSpace(CBRole.Text) ||
               
               CBRole.SelectedItem == null)
            {
                MessageBox.Show("Заполните обязательные для ввода поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



            else
            {
                Context.Employee.Add(new Model.Employee
                {
                    SecondName = TBSecondName.Text,
                    FirstName = TBFirstName.Text,
                    MiddleName = TBMiddleName.Text,
                    ContactPhoneNumber = TBPhone.Text,
                    Email = TBEmail.Text,
                    TaxDeduction = Convert.ToDecimal(TBTax.Text),
                    IDPosition = Context.Position.Where(i => i.Name == CBRole.SelectedItem.ToString()).Select(i => i.ID).FirstOrDefault()
                });
                Context.LaborAccounting.Add(new Model.LaborAccounting
                {
                    DaysWorked = Convert.ToInt32(TBWD.Text)
                });
            }

            Context.SaveChanges();
            MessageBox.Show($"Пользователь {TBSecondName.Text} {TBFirstName.Text} успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
