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

    public partial class Book : Page
    {
        public Book()
        {
            InitializeComponent();
            LVBook.ItemsSource = Context.Report.ToList();
        }
    }
}
