using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.View;
using BibliotecaElectronica.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibliotecaElectronica.Stores;
using System.Security.Cryptography;


namespace BibliotecaElectronica.Commands
{
    public class SignInCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationStore _navigationStore;

        public SignInCommand(LoginViewModel loginViewModel, NavigationStore navigationStore)
        {
            _loginViewModel = loginViewModel;
            _navigationStore = navigationStore;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public override void Execute(object parameter)
        {
            string _role = _loginViewModel.SelectedRole;
            try
            {
                string hashedPassword = EncryptPassword(_loginViewModel.Password);

                switch (_role)
                {
                    case "Administrator":
                        AdministratorModel administrator = new AdministratorModel();
                        administrator.LoginClient(_loginViewModel.Username, hashedPassword);
                        MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                        $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);

                        _navigationStore.CurrentViewModel=new AdminViewModel(_navigationStore,administrator);

                        break;

                    case "Bibliotecar":
                        BibliotecarModel bibliotecar = new BibliotecarModel();
                        bibliotecar.LoginClient(_loginViewModel.Username, hashedPassword);
                        MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                        $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);

                        _navigationStore.CurrentViewModel=new LibrarianViewModel(_navigationStore,bibliotecar);

                        break;
                    case "Cititor":
                        CititorModel cititor = new CititorModel();
                        cititor.LoginClient(_loginViewModel.Username, hashedPassword);
                        MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                        $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);

                        _navigationStore.CurrentViewModel = new ClientViewModel(_navigationStore,cititor);

                        break;



                }
            }
            catch (SignInException e)
            {
                MessageBox.Show($"Acest utilizator NU este un {_loginViewModel.SelectedRole}!");
            }
            catch (SignInWrongCredentialsException e2)
            {
                MessageBox.Show("Username sau parolă greșită!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ClosedAccountException e3)
            {
                MessageBox.Show("Contul este inchis!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }
            
        }
    }
}
