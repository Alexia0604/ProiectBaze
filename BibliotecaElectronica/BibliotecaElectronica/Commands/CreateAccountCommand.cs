using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class CreateAccountCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public  CreateAccountCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
           
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new CreateAccountViewModel(_navigationStore);
        }
 
    }
}
