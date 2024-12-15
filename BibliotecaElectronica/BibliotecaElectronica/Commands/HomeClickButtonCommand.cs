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
        private readonly NavigationStore _navigationStore;

        public HomeClickButtonCommand(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel ?? throw new ArgumentNullException(nameof(clientViewModel));
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new HomeViewModel(_clientViewModel);
        }
    }
}
