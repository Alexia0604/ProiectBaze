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
            set { _nrNotificari = value;
            OnPropertyChanged(nameof(NrNotificari));}
            get { return _nrNotificari; }
         }


        public ICommand HomeClickButtonCommand { get; }

        public ICommand CustomerClickButtonCommand { get; }

        public ICommand ProductsClickButtonCommand { get; }

        public ICommand OrdersClickButtonCommmand { get; }
        public ICommand InboxClickButtonCommmand { get; }

        public ICommand TopBooksClickButtonCommand { get; }

        public ClientViewModel(Stores.NavigationStore navigationStore,PersoanaModel persoana)
        {
            _persoana = persoana; 
            
            _currentRightViewModel = new HomeViewModel();
          
            Persoana.NrNotificariNecitite = NotificareModel.getNrMesajeNecitite(persoana.IdPerson);
            HomeClickButtonCommand = new HomeClickButtonCommand(this);
            CustomerClickButtonCommand = new CustomerClickButtonCommand(this);
            ProductsClickButtonCommand = new ProductsClickButtonCommand(this);
            OrdersClickButtonCommmand = new OrdersClickButtonCommand(persoana,this);
            InboxClickButtonCommmand = new InboxClickButtonCommmand(persoana,this);
            TopBooksClickButtonCommand = new TopBooksClickButtonCommand(this);
        }
    }
}
