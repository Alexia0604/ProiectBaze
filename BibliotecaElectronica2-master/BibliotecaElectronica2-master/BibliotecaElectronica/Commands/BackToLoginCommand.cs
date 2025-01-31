using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class BackToLoginCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

       public  BackToLoginCommand(NavigationStore navigationStore) { _navigationStore = navigationStore; }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel=new LoginViewModel(_navigationStore);
        }
    }
}
