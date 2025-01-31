using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;

namespace BibliotecaElectronica.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private ClientViewModel _clientViewModel;
        private LibrarianViewModel _librarianViewModel;
        private AdminViewModel _adminViewModel;

        public HomeViewModel(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        public HomeViewModel(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
        }

        public HomeViewModel(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        public HomeViewModel()
        {

        }
    }
}
