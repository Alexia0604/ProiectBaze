using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class BackToCreateAccountCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public BackToCreateAccountCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new CreateAccountViewModel(_navigationStore);
        }
    }
}
