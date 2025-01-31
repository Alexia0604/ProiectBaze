using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.View;
using BibliotecaElectronica.ViewModel;


namespace BibliotecaElectronica.Commands
{
    public class CustomerClickButtonCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;
        private readonly LibrarianViewModel _librarianViewModel;
        private readonly AdminViewModel _adminViewModel;

        public CustomerClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public CustomerClickButtonCommand(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel ?? throw new ArgumentNullException(nameof(librarianViewModel));
        }

        public CustomerClickButtonCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel ?? throw new ArgumentNullException(nameof(adminViewModel));
        }

        public override void Execute(object parameter)
        {
            if (_clientViewModel != null)
            {
                _clientViewModel.CurrentRightViewModel = new CustomerViewModel(_clientViewModel);
            }
            else if (_librarianViewModel != null)
            {
                _librarianViewModel.CurrentRightViewModel = new CustomerViewModel(_librarianViewModel);
            }
            else if (_adminViewModel != null)
            {
                _adminViewModel.CurrentRightViewModel = new CustomerViewModel(_adminViewModel);
            }
        }
    }
}
