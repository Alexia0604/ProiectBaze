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
            string defaultUsername1 = "Username";
            string defaultUsername2 = "Introdu username-ul";
            string defaultPassword = "Password";

            if (username==defaultUsername1 || username==defaultUsername2 || password==defaultPassword)
            {
                MessageBox.Show("Introdu parola și username-ul!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            try
            {
                using (var db = new BibliotecaElectronicaClassesDataContext())
                {
                    var user = db.Persoanas.SingleOrDefault(u => u.Username == username && u.Parola == password);
                    string role =cmbRole.Text;
                    switch(role)
                    {
                        case "Administrator":
                            var admin = db.Administrators.SingleOrDefault(a => a.ID_Persoana == user.ID);
                            if(admin!=null)
                            {
                                MessageBox.Show($"Bine ai venit, {user.Username}!", "Conectare administrator reușită!", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Acest utilizator NU este un administrator!");
                            }
                            break;
                        case "Client": 
                            var client = db.Cititors.SingleOrDefault(c => c.ID_Persoana == user.ID);
                            if (user != null)
                            {
                                MessageBox.Show($"Bine ai venit, {user.Username}!", "Conectare reușită", MessageBoxButton.OK, MessageBoxImage.Information);

                            }
                            else
                            {
                                MessageBox.Show("Username sau parola greșită!", "Conectare eșuată!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            break;
                        case "Bibliotecar":
                            var bibliotecar=db.Bibliotecars.SingleOrDefault(b => b.ID_Persoana==user.ID);
                            if(bibliotecar!=null)
                            {
                                MessageBox.Show($"Bine ai venit, {user.Username}!", "Conectare bibliotecar reușită!", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Acest utilizator NU este un bibliotecar!");
                            }
                            break;
                        default:
                            break;

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
            if (txt != null)
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
                txt.Text = "Introdu username-ul"; // Reintroduce textul implicit dacă nu s-a introdus nimic
                txt.Foreground = new SolidColorBrush(Colors.Gray); // Schimbă culoarea textului în gri
                txt.FontStyle = FontStyles.Italic; // Setează stilul italic pentru textul implicit
            
            }
          //  cmbRole.IsEnabled = !(txtUsername.Text == "Enter your username") || !(txtPassword.Password == "");
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox txt = sender as PasswordBox;
            if (txt != null)
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
                txt.Password = "password"; // Reintroduce textul implicit dacă nu s-a introdus nimic
                txt.Foreground = new SolidColorBrush(Colors.Gray); // Schimbă culoarea textului în gri
                txt.FontStyle = FontStyles.Italic; // Setează stilul italic pentru textul implicit
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow= new RegisterWindow(this);
            registerWindow.Show();
            this.Hide();
        }

        
    }
}
