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
    public class LibrarianViewModel : ViewModelBase
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

        private int _nrNotificari;
        public int NrNotificari
        {
            set
            {
                _nrNotificari = value;
                OnPropertyChanged(nameof(NrNotificari));
            }
            get { return _nrNotificari; }
        }

        public ICommand HomeClickButtonCommand { get; }
        public ICommand CustomerClickButtonCommand { get; }

        public ICommand ProductsClickButtonCommand { get; }

        public ICommand OrdersClickButtonCommmand { get; }
        public ICommand AddBooksClickButtonCommand { get; }

        public ICommand VizualizeazaReturnariCommand { get; }
        public ICommand VizualizeazaReturnariTodayCommand { get; }

        public LibrarianViewModel(Stores.NavigationStore navigationStore, PersoanaModel persoana)
        {
            _persoana = persoana;

            _currentRightViewModel = new HomeViewModel();

            Persoana.NrNotificariNecitite = NotificareModel.getNrMesajeNecitite(persoana.IdPerson);
            HomeClickButtonCommand = new HomeClickButtonCommand(this);
            CustomerClickButtonCommand = new CustomerClickButtonCommand(this);
            ProductsClickButtonCommand = new ProductsClickButtonCommand(this);
            AddBooksClickButtonCommand = new AddBooksClickButtonCommand(this);
            VizualizeazaReturnariCommand = new VizualizeazaReturnariCommand(this);
            VizualizeazaReturnariTodayCommand = new VizualizeazaReturnariTodayCommand(this);
        }
    }
}
