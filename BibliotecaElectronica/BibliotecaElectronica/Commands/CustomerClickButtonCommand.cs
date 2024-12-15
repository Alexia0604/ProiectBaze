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

        public CustomerClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new CustomerViewModel(_clientViewModel);
        }
    }
}
