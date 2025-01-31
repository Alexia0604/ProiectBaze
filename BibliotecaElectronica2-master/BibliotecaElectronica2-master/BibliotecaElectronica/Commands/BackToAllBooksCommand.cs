using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class BackToAllBooksCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;
        
        private readonly LibrarianViewModel _librarianViewModel;

        private readonly AdminViewModel _adminViewModel;
        public BackToAllBooksCommand( ClientViewModel clientViewModel)
        {
            _clientViewModel=clientViewModel;
        }

        public BackToAllBooksCommand(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
        }

        public BackToAllBooksCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel=adminViewModel;
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
            }
            else if (_adminViewModel != null)
            {
                _adminViewModel.CurrentRightViewModel = new CartiViewModel(_adminViewModel);
            }
        }
    }
}
