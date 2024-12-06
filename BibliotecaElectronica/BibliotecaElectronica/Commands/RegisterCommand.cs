using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Commands
{
    public class RegisterCommand : CommandBase
    {
        
        private PersoanaModel client;
        private readonly CreateAccountViewModel2 viewModel;
        private readonly NavigationStore _navigationStore;


        public RegisterCommand(NavigationStore navigationStore,CreateAccountViewModel2 _viewModel,PersoanaModel _client)
        {
            viewModel= _viewModel;
            _navigationStore=navigationStore;
            client = _client;
        }
        public override void Execute(object parameter)
        {
            try
            {
                client.setUsername(viewModel.Username2);
                client.setPassword(viewModel.Password2);
                client.AdaugaClient();
                MessageBox.Show("Te-ai înregistrat cu succes!", "Mesaj înregistrare", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);

            }
            catch (NoUsernameOrPasswordException e)
            {
                MessageBox.Show("Înregistrare eșuată! Username sau parolă lipsă!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DataBaseException e)
            {
                MessageBox.Show("Înregistrare eșuată! Încearcă din nou!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
