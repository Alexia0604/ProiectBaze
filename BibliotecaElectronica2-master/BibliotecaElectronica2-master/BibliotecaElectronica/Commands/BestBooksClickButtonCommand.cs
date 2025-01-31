using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.ViewModel;

namespace BibliotecaElectronica.Commands
{
    public class BestBooksClickButtonCommand : CommandBase
    {
        private readonly ClientViewModel _clientViewModel;

        public BestBooksClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new BestBooksViewModel(_clientViewModel);
        }
    }
}
