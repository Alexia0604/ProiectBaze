using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class ClientViewModel : ViewModelBase
    {
        private ViewModelBase _currentRightViewModel;

        public PersoanaModel _persoana;

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

        public ICommand OrdersClickButtonCommmand { get; }

        public ClientViewModel(Stores.NavigationStore navigationStore,PersoanaModel persoana)
        {
            _persoana = persoana;

            _currentRightViewModel = new HomeViewModel();

            HomeClickButtonCommand = new HomeClickButtonCommand(this);
            CustomerClickButtonCommand = new CustomerClickButtonCommand(this);
            ProductsClickButtonCommand = new ProductsClickButtonCommand(this);
            //OrdersClickButtonCommmand = new OrdersClickButtonCommand(this, navigationStore);

            //Startup Page
            //_currentRightViewModel = new HomeViewModel();
        }
    }
}
