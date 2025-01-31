using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    internal class TopBooksClickButtonCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;

        public TopBooksClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new TopViewModel(_clientViewModel);
        }
    }
}
