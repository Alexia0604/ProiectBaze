using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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


        public HomeViewModel(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        public HomeViewModel()
        {

        }
    }
}
