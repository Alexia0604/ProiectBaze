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
using BibliotecaElectronica.Utilities;


namespace BibliotecaElectronica.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.gotFocus(sender);
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            var u = new Utility();
            u.lostFocus(sender,"Username");
        }
    }
}
