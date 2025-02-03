using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class VizualizeazaReturnariTodayCommand : CommandBase
    {
        LibrarianViewModel _librarianViewModel;
        public VizualizeazaReturnariTodayCommand(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
        }

        public override void Execute(object parameter)
        {
            _librarianViewModel.CurrentRightViewModel = new TodayReturnariViewModel(_librarianViewModel);
        }
    }
}
