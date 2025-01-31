using BibliotecaElectronica.Model;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class InboxClickButtonCommmand : CommandBase
    {
        private PersoanaModel _persoana;
        private ClientViewModel _clientViewModel;
        public InboxClickButtonCommmand(PersoanaModel persoana,ClientViewModel clientViewModel)
        {
            _persoana = persoana;
            _clientViewModel = clientViewModel;
        }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new InboxViewModel( _persoana);
        }
    }
}
