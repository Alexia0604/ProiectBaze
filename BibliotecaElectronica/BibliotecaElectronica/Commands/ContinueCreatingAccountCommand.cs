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
    public class ContinueCreatingAccountCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly CreateAccountViewModel _createAccountViewModel;

        public ContinueCreatingAccountCommand(NavigationStore navigationStore, CreateAccountViewModel createAccountViewModel)
        {
            _navigationStore = navigationStore;
            _createAccountViewModel = createAccountViewModel;
        }
        public override void Execute(object parameter)
        {
            try
            {
                CititorModel cititor=new CititorModel();
                cititor.CreateAccount(_createAccountViewModel.LastName, _createAccountViewModel.FirstName,
                    _createAccountViewModel.Address, _createAccountViewModel.Phone, _createAccountViewModel.Email);
                _navigationStore.CurrentViewModel = new CreateAccountViewModel2(_navigationStore,cititor);
            }
            catch(AccountException ex)
            {
                MessageBox.Show("Completați toate câmpurile!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(EmailException ex)
            {
                MessageBox.Show("Email invalid!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
