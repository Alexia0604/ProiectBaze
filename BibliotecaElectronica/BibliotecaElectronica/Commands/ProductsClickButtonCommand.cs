using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.View;

namespace BibliotecaElectronica.Commands
{
    internal class ProductsClickButtonCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;

        public ProductsClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new CartiViewModel(_clientViewModel);
        }
    }
}
