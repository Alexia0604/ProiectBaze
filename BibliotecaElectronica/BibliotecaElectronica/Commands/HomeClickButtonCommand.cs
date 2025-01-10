using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.View;
using BibliotecaElectronica.ViewModel;
namespace BibliotecaElectronica.Commands
{
    public class HomeClickButtonCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;
        private readonly LibrarianViewModel _librarianViewModel;
        private readonly AdminViewModel _adminViewModel;
        private readonly NavigationStore _navigationStore;

        public HomeClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public HomeClickButtonCommand(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel ?? throw new ArgumentNullException(nameof(librarianViewModel));
        }

        public HomeClickButtonCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel ?? throw new ArgumentNullException(nameof(adminViewModel));
        }

        public override void Execute(object parameter)
        {
            if (_clientViewModel!=null) // Sau orice altă condiție pentru a verifica dacă este client
            {
                _clientViewModel.CurrentRightViewModel = new HomeViewModel(_clientViewModel);
            }
            else if (_librarianViewModel!=null) // Condiție pentru bibliotecar
                {
                _librarianViewModel.CurrentRightViewModel = new HomeViewModel(_librarianViewModel);
                }
                else if (_adminViewModel!=null)
                {
                    _adminViewModel.CurrentRightViewModel = new HomeViewModel(_adminViewModel);
                }
        }
    }
}
