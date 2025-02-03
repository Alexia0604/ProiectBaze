using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BibliotecaElectronica.ViewModel
{
    public class TodayReturnariViewModel : ViewModelBase
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
       
        public TodayReturnariViewModel(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
            CartiReturnate = new ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>>();
            afiseazaCartileReturnate();
        }

        
        private void afiseazaCartileReturnate()
        {
            var carti = CarteModel.getCartiDeReturnatAstazi();
            foreach (var carte in carti)
            {
                CartiReturnate.Add(carte);
            }
        }
    }
}
