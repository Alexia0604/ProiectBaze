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


namespace BibliotecaElectronica.Commands
{
    public class SignInCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;

        public SignInCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public override void Execute(object parameter)
        {
            string _role = _loginViewModel.SelectedRole;
            try
            {
                switch (_role)
                {
                    case "Administrator":
                        AdministratorModel administrator = new AdministratorModel();
                        administrator.LoginClient(_loginViewModel.Username, _loginViewModel.Password);
                        MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                        $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case "Bibliotecar":
                        BibliotecarModel bibliotecar = new BibliotecarModel();
                        bibliotecar.LoginClient(_loginViewModel.Username, _loginViewModel.Password);
                        MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                        $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case "Client":
                        CititorModel cititor = new CititorModel();
                        cititor.LoginClient(_loginViewModel.Username, _loginViewModel.Password);
                        MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                        $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);
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
            
        }
    }
}
