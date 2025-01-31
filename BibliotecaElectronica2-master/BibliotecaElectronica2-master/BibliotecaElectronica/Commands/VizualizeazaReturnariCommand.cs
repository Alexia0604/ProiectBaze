using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class VizualizeazaReturnariCommand : CommandBase
    {
        LibrarianViewModel _librarianViewModel;
        public VizualizeazaReturnariCommand(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel=librarianViewModel;
        }

        public override void Execute(object parameter)
        {
            _librarianViewModel.CurrentRightViewModel = new ReturnariViewModel(_librarianViewModel);
        }
    }
}
