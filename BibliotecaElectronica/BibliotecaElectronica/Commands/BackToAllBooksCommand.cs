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
        public BackToAllBooksCommand( ClientViewModel clientViewModel)
        {
            _clientViewModel=clientViewModel;
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new CartiViewModel(_clientViewModel);
        }
    }
}
