using Proyecto_HotelABC.Entities;
using Proyecto_HotelABC.Services;
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

namespace Proyecto_HotelABC.Views.GuestViews
{
    /// <summary>
    /// Lógica de interacción para CheckIn.xaml
    /// </summary>
    public partial class CheckIn : Window
    {
        CountServices services = new CountServices();
        public CheckIn()
        {
            InitializeComponent();
        }

        private void CrearCuenta_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                             
                    Count count = new Count();

                    count.Name = txtNombre.Text;
                    count.Lastname = txtApellido.Text;
                    count.Mail = txtCorreo.Text;
                    count.PhoneNumber = txtTelefono.Text;
                    count.Password = txtContrasena.Password;
                    count.FkRole = null;

                    services.AddCount(count);

                MessageBox.Show("Cuenta creada correctamente\n Será redirigido al login");
                // Muestra la ventana de inicio de sesión antes de cerrar la ventana actual.
                MainWindow login = new MainWindow();
                login.Show();

                // Cierra la ventana actual.
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error (CreateCount): " + ex.Message);
            }
        }

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
          
            Close();
        }
    }
}
