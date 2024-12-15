using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media.Imaging;


namespace BibliotecaElectronica.ViewModel
{
    public class CartiViewModel : ViewModelBase
    {
        private readonly BibliotecaElectronicaClassesDataContext _context;

        private ClientViewModel _clientViewModel;

        // Colecția pentru cărți
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

        // Textul pentru căutare
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

        // Comandă pentru search
        public ICommand SearchCommand { get; }

        public CartiViewModel(ClientViewModel clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        public CartiViewModel()
        {
            _context = new BibliotecaElectronicaClassesDataContext();
            Books = new ObservableCollection<CarteModel>();

            SearchCommand = new RelayCommand(SearchBooks);
            LoadAllBooks();
        }

        private void LoadAllBooks()
        {
            var allBooksData = _context.Cartes.Select(c => new
            {
                Titlu = c.Titlu,
                Autor = c.Autor,
                Imagine = c.Imagine.ToArray()
            }).ToList();

            var allBooks = allBooksData.Select(c => new CarteModel
            {
                Title = c.Titlu,
                Author = c.Autor,
                Image = c.Imagine
            }).ToList();

            Books = new ObservableCollection<CarteModel>(allBooks);
        }

        private void SearchBooks()
        {
            var filteredBooksData = _context.Cartes
            .Where(c => c.Titlu.Contains(SearchText) || c.Autor.Contains(SearchText))
            .Select(c => new
            {
                Titlu = c.Titlu,
                Autor = c.Autor,
                Imagine = c.Imagine.ToArray()
            }).ToList();

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