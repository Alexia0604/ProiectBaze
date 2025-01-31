using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibliotecaElectronica.ViewModel;

namespace BibliotecaElectronica.Commands
{
    public class ListLibrariansClickButtonCommand : CommandBase
    {
        private readonly AdminViewModel _adminViewModel;

        public ListLibrariansClickButtonCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        public override void Execute(object parameter)
        {
            _adminViewModel.CurrentRightViewModel = new BibliotecariViewModel(_adminViewModel);
        }
    }
}
