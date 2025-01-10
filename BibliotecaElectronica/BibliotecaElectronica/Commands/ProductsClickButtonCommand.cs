using BibliotecaElectronica.ViewModel;
using System;
using System.Net.NetworkInformation;

namespace BibliotecaElectronica.Commands
{
    internal class ProductsClickButtonCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;
        private readonly LibrarianViewModel _librarianViewModel;
        private readonly AdminViewModel _adminViewModel;

        public ProductsClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public ProductsClickButtonCommand(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel ?? throw new ArgumentNullException(nameof(librarianViewModel));
        }

        public ProductsClickButtonCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel ?? throw new ArgumentNullException(nameof(_adminViewModel));
        }

        public override void Execute(object parameter)
        {
            if (_clientViewModel != null)
            {
                _clientViewModel.CurrentRightViewModel = new CartiViewModel(_clientViewModel);
            }
            else if (_librarianViewModel != null)
            {
                _librarianViewModel.CurrentRightViewModel = new CartiViewModel(_librarianViewModel);
            } else if(_adminViewModel != null)
            {
                _adminViewModel.CurrentRightViewModel = new CartiViewModel(_adminViewModel);
            }

        }
    }
}
