using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.Commands;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Input;
using BibliotecaElectronica.Model;
using System.Collections.ObjectModel;

namespace BibliotecaElectronica.ViewModel
{
    public class BestBooksViewModel : ViewModelBase
    {
        private ObservableCollection<CarteModel> bestBooks;
        private ClientViewModel _clientViewModel;

        public ObservableCollection<CarteModel> BestBooks
        {
            get => bestBooks;
            set
            {
                bestBooks = value;
                OnPropertyChanged(nameof(BestBooks));
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

        public BestBooksViewModel(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;

            SelectBookCommand = new RelayCommand<CarteModel>(SelectBook);
            LoadTopBooks();
        }

        public void LoadTopBooks()
        {
            BestBooks = new ObservableCollection<CarteModel>(CarteModel.LoadTopBooks());
        }
    }
}
