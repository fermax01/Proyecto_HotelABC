using Proyecto_HotelABC.Entities;
using Proyecto_HotelABC.Services;
using Proyecto_HotelABC.Views.ManagerViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_HotelABC.Views.EmployeeViews
{
    /// <summary>
    /// Lógica de interacción para ManageGuest.xaml
    /// </summary>
    public partial class ManageGuest : Window
    {
        CountServices services = new CountServices();
        public ManageGuest()
        {
            InitializeComponent();
            GetCountsTableGuest("Huesped");
        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string possiblePk = TXT_PkCount.Text;


                if (!int.TryParse(possiblePk, out int existPk))
                {
                    Count count = new Count();

                    count.Name = TXT_Name.Text;
                    count.Lastname = TXT_Lastname.Text;
                    count.Mail = TXT_Mail.Text;
                    count.PhoneNumber = TXT_PhoneNumber.Text;
                    count.Password = TXT_Password.Text;
                    count.FkRole = null;

                    services.AddCount(count);
                }
                else
                {
                    Count count = new Count();

                    count.PkCount = int.Parse(TXT_PkCount.Text);
                    count.Name = TXT_Name.Text;
                    count.Lastname = TXT_Lastname.Text;
                    count.Mail = TXT_Mail.Text;
                    count.PhoneNumber = TXT_PhoneNumber.Text;
                    count.Password = TXT_Password.Text;

                    services.UptadeCount(count);
                }
                GetCountsTableGuest("Huesped");
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
           
        }
        public void BTN_EditItem_Click(object sender, EventArgs e)
        {
            Count count = new Count();

            count = (sender as FrameworkElement).DataContext as Count;

            TXT_PkCount.Text = count.PkCount.ToString();
            TXT_Name.Text = count.Name.ToString();
            TXT_Lastname.Text = count.Lastname.ToString();
            TXT_Mail.Text = count.Mail.ToString();
            TXT_PhoneNumber.Text = count.PhoneNumber.ToString();
            TXT_Password.Text = count.Password.ToString();

        }
        public void BTN_Delete_Click(object sender, EventArgs e)
        {
            Count count = new Count();

            count = (sender as FrameworkElement).DataContext as Count;

            int DeletePk = int.Parse(count.PkCount.ToString());
            services.DeleteCount(DeletePk);

            GetCountsTableGuest("Huesped");
        }
        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            CleanTXTs();
        }
        public void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeMenu employeemenu = new EmployeeMenu();
            Close();
            employeemenu.Show();
        }

        private void CleanTXTs()
        {
            TXT_PkCount.Clear();
            TXT_Name.Clear();
            TXT_Lastname.Clear();
            TXT_Mail.Clear();
            TXT_PhoneNumber.Clear();
            TXT_Password.Clear();
        }

        private void GetCountsTableGuest(string rol)
        {
            List<Count> filteredCounts = services.GetCounts().Where(c => c.Roles.Name == rol).ToList();
            GuestTable.ItemsSource = filteredCounts;
        }

        private void BTN_SignOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Close();
            login.Show();
        }
    }
}
