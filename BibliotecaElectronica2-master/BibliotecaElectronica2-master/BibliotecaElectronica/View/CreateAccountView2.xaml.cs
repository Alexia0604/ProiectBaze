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


namespace BibliotecaElectronica.View
{
    /// <summary>
    /// Interaction logic for CreateAccountView2.xaml
    /// </summary>
    public partial class CreateAccountView2 : UserControl
    {
        public CreateAccountView2()
        {
            InitializeComponent();
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Username");
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender, "Parolă");
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }
    }
}
