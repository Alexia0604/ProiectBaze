using BibliotecaElectronica.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class RegisterCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public RegisterCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();

        }
    }
}
