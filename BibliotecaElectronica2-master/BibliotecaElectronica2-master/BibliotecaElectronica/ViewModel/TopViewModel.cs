using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.Commands;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Input;

namespace BibliotecaElectronica.ViewModel
{
    public class TopViewModel : ViewModelBase
    {
        private ObservableCollection<CarteModel> topBooks;
        private ClientViewModel _clientViewModel;

        public ObservableCollection<CarteModel> TopBooks
        {
            get => topBooks;
            set
            {
                topBooks = value;
                OnPropertyChanged(nameof(TopBooks));
            }
        }

        private CarteModel _selectedBook;
        public CarteModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
                if (_selectedBook != null)
                {
                    SelectBookCommand.Execute(_selectedBook);

                }
            }
        }

        public ICommand SelectBookCommand { get; }

        private void SelectBook(CarteModel selectedBook)
        {
            if (selectedBook != null)
            {
                _clientViewModel.CurrentRightViewModel = new DetaliiCarteViewModel(selectedBook, _clientViewModel);
            }
        }

        public TopViewModel(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;

            SelectBookCommand = new RelayCommand<CarteModel>(SelectBook);
            LoadTopBooks();
        }

        public void LoadTopBooks()
        {
            TopBooks = new ObservableCollection<CarteModel>(CarteModel.LoadTopBooks());
        }
    }
}
