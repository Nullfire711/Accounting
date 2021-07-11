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
using Accounting.Model;
using static Accounting.Model.AppData;

namespace Accounting
{
    
    public partial class WindowEdit : Window
    {
        public WindowEdit()
        {

            InitializeComponent();
            var emp = Context.Employee.Where(i => i.ID == IDEmp).FirstOrDefault();

            CBRole.ItemsSource = Context.Position.Select(i => i.Name).ToList();
            CBRole.SelectedItem = Context.Position.Where(i => i.ID == emp.ID).Select(i => i.ID).FirstOrDefault();
            

            TBSecondName.Text = emp.SecondName;
            TBFirstName.Text = emp.FirstName;
            TBMiddleName.Text = emp.MiddleName;
            TBPhone.Text = emp.ContactPhoneNumber;
            TBEmail.Text = emp.Email;
            TBWD.Text = Context.LaborAccounting.Where(i => i.IDEmployee == IDEmp).FirstOrDefault().DaysWorked.ToString();
            TBTax.Text = Convert.ToString(emp.TaxDeduction);

        }

        private void EditSaveBTN_Click(object sender, RoutedEventArgs e)
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
                var emp = Context.Employee.Where(i => i.ID == IDEmp).FirstOrDefault();
                var laborAccounting = Context.LaborAccounting.Where(i => i.IDEmployee == IDEmp).FirstOrDefault();

                emp.SecondName = TBSecondName.Text;
                    emp.FirstName = TBFirstName.Text;
                    emp.MiddleName = TBMiddleName.Text;
                    emp.ContactPhoneNumber = TBPhone.Text;
                    emp.Email = TBEmail.Text;
                    laborAccounting.DaysWorked = Convert.ToInt32(TBWD.Text);
                    emp.TaxDeduction = Convert.ToDecimal(TBTax.Text);


            }

            Context.SaveChanges();
            MessageBox.Show("Данные успешно сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
