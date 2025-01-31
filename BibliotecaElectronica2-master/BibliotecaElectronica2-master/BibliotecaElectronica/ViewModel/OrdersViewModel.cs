using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BibliotecaElectronica.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        //  private ObservableCollection<CarteModel> _cartiImprumutate;
        private ClientViewModel _clientViewModel;
      //  private LibrarianViewModel _librarianViewModel;
        private ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> _cartiImprumutate;
        public ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> CartiImprumutate
        {
            get => _cartiImprumutate;
            set
            {
                _cartiImprumutate = value;
                OnPropertyChanged(nameof(CartiImprumutate));
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
        public ICommand ReturneazaCarteCommand { get; }
        public ICommand PrelungesteTermenCommand { get; }
        public ICommand ConfirmaPrelungireCommand { get; }
        public ICommand AnuleazaPrelungireCommand { get; }

        private PersoanaModel persoana;
       

        private DateTime _nouaData=DateTime.Now;
        public DateTime NouaData
        {
            get => _nouaData;
            set
            {
                _nouaData = value;
                OnPropertyChanged(nameof(NouaData));
            }
        }
        public OrdersViewModel(ClientViewModel clientViewModel, PersoanaModel _persoana)
        {
            persoana = _persoana;
            _clientViewModel = clientViewModel;
            CartiImprumutate = new ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>>();
            afiseazaCartileImprumutate(persoana.IdPerson);
            ReturneazaCarteCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(ReturneazaCarte);
            PrelungesteTermenCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(PrelungesteTermen);
            ConfirmaPrelungireCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(ConfirmaPrelungire);
            AnuleazaPrelungireCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(AnuleazaPrelungire);
        }

        //public OrdersViewModel(LibrarianViewModel librarianViewModel, PersoanaModel _persoana)
        //{
        //    persoana = _persoana;
        //    _librarianViewModel = librarianViewModel;
        //    CartiImprumutate = new ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>>();
        //    afiseazaCartileImprumutate(persoana.IdPerson);
        //    ReturneazaCarteCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(ReturneazaCarte);
        //    PrelungesteTermenCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(PrelungesteTermen);
        //    ConfirmaPrelungireCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(ConfirmaPrelungire);
        //    AnuleazaPrelungireCommand = new RelayCommand<KeyValuePair<CarteModel, ImprumutModel>>(AnuleazaPrelungire);
        //}

        private void AnuleazaPrelungire(KeyValuePair<CarteModel, ImprumutModel> item)
        {
            item.Value.IsPopupOpen = false;
            NouaData = DateTime.Now;
        }
        private void ConfirmaPrelungire(KeyValuePair<CarteModel, ImprumutModel> item)
        {
            try { 
                if(NouaData<DateTime.Today)
                {
                    throw new DateTimeException();
                }
                item.Value.updateTermenLimita(NouaData);
                item.Value.IsPopupOpen = false;
                MessageBox.Show($"Termen returnare schimbat!", "Succes!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(DataBaseException e)
            {
                MessageBox.Show($"S-a întâmpinat o problemă! Vă rugăm să încercați mai târziu!", "Eroare", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            catch (DateTimeException e)
            {
                MessageBox.Show($"Dată invalidă!", "Eroare", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        private void PrelungesteTermen(KeyValuePair<CarteModel, ImprumutModel> item)
        {
            item.Value.IsPopupOpen = true;
        }
        private void ReturneazaCarte(KeyValuePair<CarteModel, ImprumutModel> item)
        {
            try
            {
                item.Key.returneazaCarteCititor(item.Value.IDImprumut);
                item.Value.finalizareImprumut();
                MessageBox.Show($"Cerere de returnare procesată!", "Succes!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (DataBaseException e)
            {
                MessageBox.Show($"S-a întâmpinat o problemă! Vă rugăm să încercați mai târziu!", "Eroare", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        private void afiseazaCartileImprumutate(int userID)
        {
            var carti = CarteModel.getCartiImprumutate(userID);
            foreach (var carte in carti)
            {
                CartiImprumutate.Add(carte);
            }
        }


    }
}
