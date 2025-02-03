using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BibliotecaElectronica.ViewModel
{
    public class ReturnariViewModel : ViewModelBase
    {
        private readonly LibrarianViewModel _librarianViewModel;
        private ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> _cartiReturnate;
        public ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> CartiReturnate
        {
            get => _cartiReturnate;
            set
            {
                _cartiReturnate = value;
                OnPropertyChanged(nameof(CartiReturnate));
            }
        }

        private KeyValuePair<CarteModel, ImprumutModel> selectedItem;
        public KeyValuePair<CarteModel, ImprumutModel> SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ICommand AprobaSolicitareCommand { get; }
        public ICommand RespingeSolicitareCommand { get; }
        public ReturnariViewModel(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
            CartiReturnate = new ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>>();
            afiseazaCartileReturnate();
            //   AprobaSolicitareCommand=RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(AprobaSolicitare);
            AprobaSolicitareCommand =new  RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(AprobaSolicitare);
            RespingeSolicitareCommand= new RelayCommand<KeyValuePair<CarteModel,ImprumutModel>>(RespingeSolicitare);

        }

        private void AprobaSolicitare(KeyValuePair<CarteModel, ImprumutModel> item)
        {
            try
            {
                item.Key.aprobaReturnareCarte(item.Value.IDImprumut);
                item.Value.finalizareImprumutByBibliotecar();
                if (_librarianViewModel.Persoana.NrNotificariNecitite > 0)
                    _librarianViewModel.Persoana.NrNotificariNecitite--;
            }
            catch (DataBaseException e)
            {
                MessageBox.Show($"S-a întâmpinat o problemă! Vă rugăm să încercați mai târziu!", "Eroare", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void RespingeSolicitare(KeyValuePair<CarteModel, ImprumutModel> item)
        {
            try
            {
                item.Key.respingeReturnareCarte(item.Value.IDImprumut);
                item.Value.respingereFinalizareImprumut();
                if (_librarianViewModel.Persoana.NrNotificariNecitite > 0)
                    _librarianViewModel.Persoana.NrNotificariNecitite--;
            }
            catch (DataBaseException e)
            {
                MessageBox.Show($"S-a întâmpinat o problemă! Vă rugăm să încercați mai târziu!", "Eroare", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

        }
        private void afiseazaCartileReturnate()
        {
            var carti = CarteModel.getCartiReturnate();
            foreach (var carte in carti)
            {
                CartiReturnate.Add(carte);
            }
        }
    }
}
