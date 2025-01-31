using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BibliotecaElectronica.Model;
using System.Windows.Input;
using System.Windows;

namespace BibliotecaElectronica.ViewModel
{
    public class CititoriViewModel : ViewModelBase
    {
        private ObservableCollection<CititorModel> _readers;

        private AdminViewModel _adminViewModel;
        public ObservableCollection<CititorModel> Readers
        {
            get => _readers;
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(Readers));
            }
        }

        public CititoriViewModel()
        {
            
        }

        public ICommand DeleteCommand { get; }

        public CititoriViewModel(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;

            Readers = new ObservableCollection<CititorModel>();

            DeleteCommand = new RelayCommand<int>(DeleteReader);

            LoadAllReaders();
        }

        private void LoadAllReaders()
        {
            var cititori = CititorModel.LoadAllReaders();
            foreach (var cititor in cititori)
            {
                Readers.Add(cititor);
            }
        }

        private void DeleteReader(int readerId)
        {
            var result = MessageBox.Show("Sigur vrei să ștergi acest cont? Această acțiune nu poate fi anulată!",
                                          "Confirmare ștergere", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var readerToDelete = Readers.FirstOrDefault(r => r.IdPerson == readerId);
                if (readerToDelete != null)
                {
                    Readers.Remove(readerToDelete);
                    CititorModel.DeleteReader(readerToDelete); 
                }
            }
        }
    }
}
