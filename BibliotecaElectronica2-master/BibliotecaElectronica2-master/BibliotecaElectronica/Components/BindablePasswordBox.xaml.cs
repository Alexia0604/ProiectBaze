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

namespace BibliotecaElectronica.Components
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        bool _isPasswordChanging;

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is BindablePasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

       
        public string Password
        {
           
            get { return (string)GetValue(PasswordProperty); }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }
        
        public BindablePasswordBox()
        {
            InitializeComponent();
        }
        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging=true;
            Password = passwordBox.Password;
            _isPasswordChanging = false;    
        }

        private void UpdatePassword()
        {
            if (!_isPasswordChanging)
            {
                passwordBox.Password = Password;
            }
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox txt = sender as PasswordBox;
            if (txt != null)
            {
                txt.Password = "";
                txt.Foreground = new SolidColorBrush(Colors.Black); // Schimbă culoarea textului la negru
                txt.FontStyle = FontStyles.Normal; // Elimină stilul italic
            }
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox txt = sender as PasswordBox;
            if (txt != null && string.IsNullOrEmpty(txt.Password))
            {
                txt.Password = "parola"; // Reintroduce textul implicit dacă nu s-a introdus nimic
                txt.Foreground = new SolidColorBrush(Colors.Gray); // Schimbă culoarea textului în gri
            }
        }
    }
}
