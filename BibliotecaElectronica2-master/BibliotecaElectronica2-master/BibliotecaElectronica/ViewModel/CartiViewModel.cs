using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media.Imaging;
using System.Windows;


namespace BibliotecaElectronica.ViewModel
{
    public class CartiViewModel : ViewModelBase
    {
        private readonly BibliotecaElectronicaClassesDataContext _context;

        private ClientViewModel _clientViewModel;

        private LibrarianViewModel _librarianViewModel;

        private AdminViewModel _adminViewModel;

        private ObservableCollection<CarteModel> _books;
        public ObservableCollection<CarteModel> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
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
                if(_selectedBook!=null)
                {
                    SelectBookCommand.Execute(_selectedBook);

                }
            }
        }



        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

      
        public ICommand SearchCommand { get; }
        public ICommand SelectBookCommand { get; }
        public ICommand ClickOnBookImage { get; set; }
        public CartiViewModel(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;
            _context = new BibliotecaElectronicaClassesDataContext();
            Books = new ObservableCollection<CarteModel>();

            SearchCommand = new RelayCommand(SearchBooks);
            SelectBookCommand = new RelayCommand<CarteModel>(SelectBook);
            LoadAllBooks();

        }

        public CartiViewModel(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
            _context = new BibliotecaElectronicaClassesDataContext();
            Books = new ObservableCollection<CarteModel>();

            SearchCommand = new RelayCommand(SearchBooks);
            SelectBookCommand = new RelayCommand<CarteModel>(SelectBook);
            LoadAllBooks();

        }

        public CartiViewModel(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            _context = new BibliotecaElectronicaClassesDataContext();
            Books = new ObservableCollection<CarteModel>();

            SearchCommand = new RelayCommand(SearchBooks);
            SelectBookCommand = new RelayCommand<CarteModel>(SelectBook);
            LoadAllBooks();

        }

        private void SelectBook(CarteModel selectedBook)
        {
            if (selectedBook != null)
            {

                if (_clientViewModel != null)
                {
                    _clientViewModel.CurrentRightViewModel = new DetaliiCarteViewModel(selectedBook, _clientViewModel);
                }
                else if (_librarianViewModel != null)
                {
                    _librarianViewModel.CurrentRightViewModel = new DetaliiCarteViewModel(selectedBook, _librarianViewModel);
                }
                else if (_adminViewModel != null)
                {
                    _adminViewModel.CurrentRightViewModel = new DetaliiCarteViewModel(selectedBook, _adminViewModel);
                }
            }
        }
        private void LoadAllBooks()
        {
            var carti = CarteModel.LoadAllBooks();
            foreach (var carte in carti)
            {
                Books.Add(carte);
            }
        }
        private void SearchBooks()
        {

            var filteredBooksData = _context.Cartes
                .Where(c => c.Titlu.Contains(SearchText) || c.Autor.Contains(SearchText) || c.Categorie.Contains(SearchText))
                .Select(c => new
                {
                    Titlu = c.Titlu,
                    Autor = c.Autor,
                    Imagine = c.Imagine.ToArray()

                }).ToList();

            if(filteredBooksData.Count == 0)
            {
                MessageBox.Show($"Nu exista rezultate pentru {SearchText}! ", "Mesaj cautare", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var filteredBooks = filteredBooksData.Select(c => new CarteModel
                {
                    Title = c.Titlu,
                    Author = c.Autor,
                    Image = c.Imagine
                }).ToList();

                Books = new ObservableCollection<CarteModel>(filteredBooks);
            }

        }
    }
}