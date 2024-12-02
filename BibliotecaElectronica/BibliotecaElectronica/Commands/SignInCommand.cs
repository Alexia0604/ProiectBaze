using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.View;
using BibliotecaElectronica.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
            ClientRepository clientRepository = new ClientRepository();
            try
            {
                clientRepository.LoginClient(_loginViewModel.Username, _loginViewModel.Password, _loginViewModel.SelectedRole);
                MessageBox.Show($"Bine ai venit, {_loginViewModel.Username}!",
                    $"Conectare {_loginViewModel.SelectedRole} reușită!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (SignInException e )
            {
                MessageBox.Show($"Acest utilizator NU este un {_loginViewModel.SelectedRole}!");
            }
            catch (SignInWrongCredentialsException e2)
            {
                MessageBox.Show("Username sau parolă greșită!","Eroare",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }
    }
}
