using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class ClickOnBookImage : CommandBase
    {
        private CarteModel _SelectedBook;
        private readonly ClientViewModel _clientViewModel;
        public ClickOnBookImage(CarteModel selectedBook,ClientViewModel clientViewModel)
        {
            _SelectedBook = selectedBook;
            _clientViewModel = clientViewModel;
    }

        public override void Execute(object parameter)
        {
            _clientViewModel.CurrentRightViewModel = new DetaliiCarteViewModel(_SelectedBook,_clientViewModel);
        }
    }
}
