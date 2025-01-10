using BibliotecaElectronica.Model;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class OrdersClickButtonCommand : CommandBase
    {
        private readonly PersoanaModel _persoana;
        private readonly ClientViewModel _clientViewModel;
        private readonly LibrarianViewModel _librarianViewModel;

        public OrdersClickButtonCommand(PersoanaModel client,ClientViewModel clientViewModel)
        {
            _persoana = client;

            _clientViewModel = clientViewModel;
        }

        public OrdersClickButtonCommand(PersoanaModel client, LibrarianViewModel librarianViewModel)
        {
            _persoana = client;

            _librarianViewModel = librarianViewModel;
        }
        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new OrdersViewModel(_clientViewModel, _persoana);
        }
    }
}
