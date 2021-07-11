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
using Accounting.Model;
using static Accounting.Model.AppData;

namespace Accounting.Pages
{

    public partial class Service : Page
    {

        public Service()
        {
            InitializeComponent();
            LVService.ItemsSource = Context.Employee.ToList();
        }

        private double calcSalary()
        {   

            int days = Context.LaborAccounting.Where(i => i.IDEmployee == IDEmp).FirstOrDefault().DaysWorked;
            int idPos = Context.Employee.Where(i => i.ID == IDEmp).FirstOrDefault().IDPosition;
            double rate = Convert.ToDouble(Context.Position.Where(i => i.ID == idPos).FirstOrDefault().WageRate);

            return days * rate;
        }

        private void LVService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVService.SelectedItem is Employee employee)
            {
                TBTotalSalary.Text = "";
                TBInsurance.Text = "6040";
                IDEmp = employee.ID;
                LVService.ItemsSource = Context.Employee.ToList();

                TBSalary.Text = Convert.ToString(calcSalary());
                TBTax.Text = Convert.ToString(employee.TaxDeduction);
            }
            else
            {
                MessageBox.Show("Выберите пользователя из списка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            if (LVService.SelectedItem is Employee employee)
            {
                double res;
                if (Convert.ToDouble(TBTax.Text) + Convert.ToDouble(TBInsurance.Text) < Convert.ToDouble(TBSalary.Text))
                {
                     res = Convert.ToDouble(TBSalary.Text) - Convert.ToDouble(TBTax.Text) - Convert.ToDouble(TBInsurance.Text);
                   
                }
                else 
                {
                    res = 0;
                }
                TBTotalSalary.Text = res.ToString();
            }
            else
            {
                MessageBox.Show("Выберите пользователя из списка", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void SaveReport_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBTotalSalary.Text))
                {
                    MessageBox.Show("Не был произведён расчёт заработной платы", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            else
            {
                Context.Report.Add(new Report
                {

                    IDEmployee = IDEmp,
                    FinalSalary = Convert.ToDecimal(TBTotalSalary.Text),
                    Date = DateTime.Now,

                });
                Context.SaveChanges();
                MessageBox.Show("Отчёт был успешно сохранён", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
