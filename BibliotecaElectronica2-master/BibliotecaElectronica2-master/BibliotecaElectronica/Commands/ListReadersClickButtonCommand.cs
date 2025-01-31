using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BibliotecaElectronica.ViewModel;

namespace BibliotecaElectronica.Commands
{
    public class ListReadersClickButtonCommand : CommandBase
    {
        private readonly AdminViewModel _adminViewModel;

        public ListReadersClickButtonCommand(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        public override void Execute(object parameter)
        {
            _adminViewModel.CurrentRightViewModel = new CititoriViewModel(_adminViewModel);
        }
    }
}
