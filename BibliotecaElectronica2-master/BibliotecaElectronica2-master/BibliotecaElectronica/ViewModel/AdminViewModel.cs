using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;

namespace BibliotecaElectronica.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        private ViewModelBase _currentRightViewModel;

        private PersoanaModel _persoana;
        public PersoanaModel Persoana
        {
            get { return _persoana; }
            set
            {
                _persoana = value;
                OnPropertyChanged(nameof(Persoana));
            }
        }

        public ViewModelBase CurrentRightViewModel
        {
            get => _currentRightViewModel;

            set
            {
                _currentRightViewModel = value;
                OnPropertyChanged(nameof(CurrentRightViewModel));
            }
        }

        public ICommand HomeClickButtonCommand { get; }

        public ICommand CustomerClickButtonCommand { get; }

        public ICommand ProductsClickButtonCommand { get; }

        public ICommand ListReadersClickButtonCommand { get; }

        public ICommand ListLibrariansClickButtonCommand { get; }

        public AdminViewModel(Stores.NavigationStore navigationStore, PersoanaModel persoana)
        {
            _persoana = persoana;

            _currentRightViewModel = new HomeViewModel();

            HomeClickButtonCommand = new HomeClickButtonCommand(this);
            CustomerClickButtonCommand = new CustomerClickButtonCommand(this);
            ProductsClickButtonCommand = new ProductsClickButtonCommand(this);
            ListReadersClickButtonCommand = new ListReadersClickButtonCommand(this);
            ListLibrariansClickButtonCommand = new ListLibrariansClickButtonCommand(this);
        }
    }
}
