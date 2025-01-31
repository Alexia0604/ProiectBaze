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
    public class BibliotecariViewModel : ViewModelBase
    {
        private ObservableCollection<BibliotecarModel> _librarians;

        private AdminViewModel _adminViewModel;
        public ObservableCollection<BibliotecarModel> Librarians
        {
            get => _librarians;
            set
            {
                _librarians = value;
                OnPropertyChanged(nameof(Librarians));
            }
        }

        public BibliotecariViewModel()
        {

        }

        public ICommand DeleteCommand { get; }

        public BibliotecariViewModel(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;

            Librarians = new ObservableCollection<BibliotecarModel>();

            DeleteCommand = new RelayCommand<int>(DeleteLibrarian);

            LoadAllLibrarians();
        }

        private void LoadAllLibrarians()
        {
            var bibliotecari = BibliotecarModel.LoadAllLibrarians();
            foreach (var bibliotecar in bibliotecari)
            {
                Librarians.Add(bibliotecar);
            }
        }

        private void DeleteLibrarian(int librarianId)
        {
            var result = MessageBox.Show("Sigur vrei să ștergi acest cont? Această acțiune nu poate fi anulată!",
                                          "Confirmare ștergere", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var librarianToDelete = Librarians.FirstOrDefault(l => l.IdPerson == librarianId);
                if (librarianToDelete != null)
                {
                    Librarians.Remove(librarianToDelete);
                    BibliotecarModel.DeleteLibrarian(librarianToDelete); 
                }
            }
        }
    }
}
