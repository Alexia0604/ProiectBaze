using BibliotecaElectronica.Utilities;
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
using static System.Net.Mime.MediaTypeNames;

namespace BibliotecaElectronica.View
{
    /// <summary>
    /// Interaction logic for CreateAccountView.xaml
    /// </summary>
    public partial class CreateAccountView : UserControl
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }
      
          
        private void txtLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Telefon");
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Nume");
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Prenume");
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Email");
        }

        private void txtAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Adresă");
        }
    }
}
