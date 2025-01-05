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
        private void SelectBook(CarteModel selectedBook)
        {
            if (selectedBook != null)
            {
              // ClickOnBookImage = new ClickOnBookImage(selectedBook, _clientViewModel);
               _clientViewModel.CurrentRightViewModel = new DetaliiCarteViewModel(selectedBook, _clientViewModel);
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
                .Where(c => c.Titlu.Contains(SearchText) || c.Autor.Contains(SearchText))
                .Select(c => new
                {
                    Titlu = c.Titlu,
                    Autor = c.Autor,
                    Imagine = c.Imagine.ToArray(),
                    CategorieId = c.ID_Categorie 
                }).ToList();

            var category = _context.Categories
                .Where(c => c.Nume.Contains(SearchText))
                .Select(c => new
                {
                    ID = c.ID,
                    Nume = c.Nume
                }).FirstOrDefault();
        
            var filteredBooksByCategory = _context.Cartes.Where(c => c.ID_Categorie==category.ID)
                                             .Select(c => new
                                             {
                                                 Titlu = c.Titlu,
                                                 Autor = c.Autor,
                                                 Imagine = c.Imagine.ToArray(),
                                                 CategorieId = c.ID_Categorie
                                             }).ToList() ;
              
            var combinedResults = filteredBooksData.Union(filteredBooksByCategory).Distinct().ToList();
            
            var filteredBooks = combinedResults.Select(c => new CarteModel
            {
                Title = c.Titlu,
                Author = c.Autor,
                Image = c.Imagine
            }).ToList();
            Books = new ObservableCollection<CarteModel>(filteredBooks);
        }
    }
}