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
using MaterialDesignThemes.Wpf;

namespace BibliotecaElectronica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Validare simplă
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Conectare la baza de date folosind LINQ to SQL
            try
            {
                using (var db = new BibliotecaElectronicaClassesDataContext())
                {
                    var user = db.Persoanas.SingleOrDefault(u => u.Username == username && u.Parola == password);
                    if (user != null)
                    {
                        MessageBox.Show($"Welcome, {user.Username}!", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Navighează la următoarea fereastră (exemplu)
                        // var dashboard = new DashboardWindow();
                        // dashboard.Show();
                        // this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && txt.Text==txtUsername.Tag.ToString())
            {
                txt.Text = "";
                txt.Foreground = new SolidColorBrush(Colors.Black); // Schimbă culoarea textului la negru
                txt.FontStyle = FontStyles.Normal; // Elimină stilul italic
            }
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null && string.IsNullOrEmpty(txt.Text))
            {
                txt.Text = "Enter your username"; // Reintroduce textul implicit dacă nu s-a introdus nimic
                txt.Foreground = new SolidColorBrush(Colors.Gray); // Schimbă culoarea textului în gri
                txt.FontStyle = FontStyles.Italic; // Setează stilul italic pentru textul implicit
            }
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox txt = sender as PasswordBox;
            if (txt != null && txt.Password == txtPassword.Tag.ToString())
            {
                txt.Password = "";
                txt.Foreground = new SolidColorBrush(Colors.Black); // Schimbă culoarea textului la negru
                txt.FontStyle = FontStyles.Normal; // Elimină stilul italic
            }
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox txt = sender as PasswordBox;
            if (txt != null && string.IsNullOrEmpty(txt.Password))
            {
                txt.Password = "Enter your password"; // Reintroduce textul implicit dacă nu s-a introdus nimic
                txt.Foreground = new SolidColorBrush(Colors.Gray); // Schimbă culoarea textului în gri
                txt.FontStyle = FontStyles.Italic; // Setează stilul italic pentru textul implicit
            }
        }
    }
}
