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
using BibliotecaElectronica.Utilities;

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
            Utility u=new Utility();

            DateTime birthDate=new DateTime(_createAccountViewModel.Year,u.getMonthByName(_createAccountViewModel.Month),_createAccountViewModel.Day);

            try
            {
                CititorModel cititor=new CititorModel();
                cititor.CreateAccount(_createAccountViewModel.LastName, _createAccountViewModel.FirstName,
                    _createAccountViewModel.Address, _createAccountViewModel.Phone, _createAccountViewModel.Email,birthDate);
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
