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

namespace Proyecto_HotelABC.Views.EmployeeViews
{
    /// <summary>
    /// Lógica de interacción para EmployeeMenu.xaml
    /// </summary>
    public partial class EmployeeMenu : Window
    {
        public EmployeeMenu()
        {
            InitializeComponent();
        }

        private void BTN_ManageGuest_Click(object sender, RoutedEventArgs e)
        {
            ManageGuest manageguest = new ManageGuest();
            Close();
            manageguest.Show();
        }

        private void BTN_SignOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Close();
            login.Show();
        }
    }
}
