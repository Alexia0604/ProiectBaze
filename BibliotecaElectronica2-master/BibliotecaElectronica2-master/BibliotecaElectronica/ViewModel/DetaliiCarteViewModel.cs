using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.Utilities;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Shapes;

namespace BibliotecaElectronica.ViewModel
{
    public class DetaliiCarteViewModel : ViewModelBase
    {
        public readonly ClientViewModel _clientViewModel;

        public readonly LibrarianViewModel _librarianViewModel;

        public AdminViewModel _adminViewModel;

        private CarteModel _selectedBook;
        public CarteModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private ObservableCollection<RecenzieModel> recenzii;

        public ObservableCollection<RecenzieModel> Recenzii
        {
            get => recenzii;
            set
            {
                recenzii = value;
                OnPropertyChanged(nameof(Recenzii));
            }
        }

        private RecenzieModel selectedReview;
        public RecenzieModel SelectedReview
        {
            get => selectedReview;
            set
            {
                selectedReview = value;
                OnPropertyChanged(nameof(SelectedReview));
               
            }
        }

        private int _borrowedCount = 0;
        public int BorrowedCount
        {
            get => _borrowedCount;
            set
            {
                _borrowedCount = value;
                OnPropertyChanged(nameof(BorrowedCount));
            }
        }

        public ICommand BorrowBook { get; }
        public ICommand BackToAllBooks { get; }

        private bool isLiked;
        public bool IsLiked
        {
            get => isLiked;
            set
            {
                isLiked = value;
                OnPropertyChanged(nameof(IsLiked));
            }
        }

        private bool isDisliked;
        public bool IsDisliked
        {
            get => isDisliked;
            set
            {
                isDisliked = value;
                OnPropertyChanged(nameof(IsDisliked));
            }
        }

        public ICommand LikeCommand { get; }
        public ICommand DislikeCommand { get; }

        public int TotalRatings => Ratings.Sum(r => r.Value);

        private ObservableCollection<RatingDistributionItem> ratings;
        public ObservableCollection<RatingDistributionItem> Ratings { get => ratings;
            set
            {
                ratings = value;
                OnPropertyChanged(nameof(Ratings));
            }
        }

        private double averageRating;
        public double AverageRating
        {
            get { return averageRating; }
            set { averageRating = value;
                OnPropertyChanged(nameof(AverageRating));
            }
        }

        private int totalReviews;
        public int TotalReviews
        {
            get { return totalReviews; }
            set { totalReviews = value;
            OnPropertyChanged(nameof(TotalReviews));}
        }

        private ObservableCollection<bool> stars;
        public ObservableCollection<bool> Stars { 
            get { return stars; }
            set {
                stars = value;
                OnPropertyChanged(nameof(Stars));
            }
        }

        private ObservableCollection<int> starOptions = new ObservableCollection<int> { 1, 2, 3, 4, 5 };

        public ObservableCollection<int> StarOptions
        {
            get { return starOptions; }
            set
            {
                starOptions = value;
                OnPropertyChanged(nameof(StarOptions));
            }
        }

        private int _selectedStars = 0;
        public int SelectedStars
        {
            get => _selectedStars;
            set
            {
                _selectedStars = value;
                OnPropertyChanged(nameof(SelectedStars));
                if (_selectedStars != 0)
                    SelectStarCommand.Execute(SelectedStars);

            }
        }

        public ICommand OpenPopupCommand { get; }
        public ICommand ClosePopupCommand { get; }
        public ICommand SubmitReviewCommand { get; }
        public ICommand SelectStarCommand { get; }

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged(nameof(IsPopupOpen));
            }
        }

        private string _newReview;
        public string NewReview
        {
            get => _newReview;
            set
            {
                _newReview = value;
                OnPropertyChanged(nameof(NewReview));
            }
        }

        private bool _isSectionVisible;
        public bool IsSectionVisible
        {
            get => _isSectionVisible;
            set
            {
                _isSectionVisible = value;
                OnPropertyChanged(nameof(IsSectionVisible));
            }
        }

        private bool isButtonPressed;
        public bool IsButtonPressed
        {
            get => isButtonPressed;
            set
            {
                isButtonPressed = value;
                OnPropertyChanged(nameof(IsButtonPressed));
                CommandManager.InvalidateRequerySuggested();
            }
        }
       
        public DetaliiCarteViewModel(CarteModel selectedBook, ClientViewModel clientViewModel)
        {
            // IsButtonVisible = true;
            IsButtonPressed = !ImprumutModel.verificaImprumut(selectedBook.idBook,clientViewModel.Persoana.IdPerson);
            _isSectionVisible= true;
            ratings =selectedBook.getRatingDistributions();
            averageRating = GetPercentage();
            stars = GetStars(averageRating);
            _selectedBook =selectedBook;
            _clientViewModel = clientViewModel;
          
            _selectedBook.populeazaRecenziile();
            recenzii=new ObservableCollection<RecenzieModel>();
            recenzii = _selectedBook.populeazaRecenziile();
            BorrowBook = new BorrowBookCommand(selectedBook, clientViewModel.Persoana, OnBorrowSuccess);
            LikeCommand = new RelayCommand<RecenzieModel>(likeCommand);
            DislikeCommand = new RelayCommand<RecenzieModel>(dislikeCommand);
            totalReviews = selectedBook.getNrRecenzii();
            OpenPopupCommand = new RelayCommand(OpenPopup);
            ClosePopupCommand = new RelayCommand(ClosePopup);
            SubmitReviewCommand = new SubmitReviewCommand(this);
            SelectStarCommand = new RelayCommand<int>(SelectStar);
        }

        private void OnBorrowSuccess()
        {
            IsButtonPressed = false; 
                                  
        }

        public DetaliiCarteViewModel(CarteModel selectedBook, LibrarianViewModel librarianViewModel)
        {
            _isSectionVisible = false;
           
            ratings = selectedBook.getRatingDistributions();
            averageRating = GetPercentage();
            stars = GetStars(averageRating);
            _selectedBook = selectedBook;
            _librarianViewModel = librarianViewModel;
            _selectedBook.populeazaRecenziile();
            recenzii = new ObservableCollection<RecenzieModel>();
            recenzii = _selectedBook.populeazaRecenziile();
            LikeCommand = new RelayCommand<RecenzieModel>(likeCommand);
            DislikeCommand = new RelayCommand<RecenzieModel>(dislikeCommand);
            totalReviews = selectedBook.getNrRecenzii();
         
        }

        public DetaliiCarteViewModel(CarteModel selectedBook, AdminViewModel adminViewModel)
        {
            _isSectionVisible = false;
            ratings = selectedBook.getRatingDistributions();
            averageRating = GetPercentage();
            stars = GetStars(averageRating);
            _selectedBook = selectedBook;
            _adminViewModel = adminViewModel;
            BackToAllBooks = new BackToAllBooksCommand(adminViewModel);
            _selectedBook.populeazaRecenziile();
            recenzii = new ObservableCollection<RecenzieModel>();
            recenzii = _selectedBook.populeazaRecenziile();
         
        }

        private void SelectStar(int selectedStar)
        {
            if (selectedStar != 0)
            {
                _selectedStars = selectedStar;
                StarOptions = GetStars(selectedStar);
            }
        }

        public ObservableCollection<int> GetStars(int selectedStars)
        {
            ObservableCollection<int> stars = new ObservableCollection<int>();
            if(selectedStars>5)
            {
                selectedStars -= 10;
            }
            for (int i = 1; i <= 5; i++)
            {
                if (i <= selectedStars)
                {
                    stars.Add(10+i);
                }
                else
                {
                    stars.Add(i);
                }
            }
            return stars;
        }


        private void OpenPopup()
        {
            IsPopupOpen = true;
        }
        private void ClosePopup()
        {
            IsPopupOpen = false;
        }

        public ObservableCollection<bool> GetStars(double percentage)
        {
            ObservableCollection<bool> stars = new ObservableCollection<bool>();

            int fullStars = (int)Math.Round(percentage);
            for (int i = 0; i < fullStars; i++)
            {
                stars.Add(true); 
            }


            while (stars.Count < 5)
            {
                stars.Add(false); 
            }

            return stars;
        }
        private void likeCommand(RecenzieModel recenzie)
        {
            if (isLiked == false)
            {
               
                IsLiked = true;
                recenzie.addLike();
                if (IsDisliked)
                {
                    IsDisliked = false;
                    recenzie.decrementDislike();
                }
            }
            else
                return;
           
        }

        private double GetPercentage()
        {
            if (TotalRatings == 0) return 0; 

            double percentage = 0;
            foreach(var item in Ratings)
            {
                percentage+= item.Value*item.Key;
            }

            double result = (double)percentage / TotalRatings;

            return Math.Round(result, 2);
        }


        private void dislikeCommand(RecenzieModel recenzie)
        {
            if (IsDisliked == false)
            {
              
                IsDisliked = true;
                recenzie.addDislike();
                if (IsLiked)
                {
                    IsLiked = false;
                    recenzie.decrementLike();
                }
            }
            else
                return;
          
        }
    }
}
