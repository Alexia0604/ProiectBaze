using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using CommunityToolkit.Mvvm.Input;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Exceptions;

namespace BibliotecaElectronica.ViewModel
{
    public class AddBooksViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly LibrarianViewModel _librarianViewModel;
        private Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        bool _valid = true;
        public bool HasErrors => _propertyErrors.Count > 0;

        public AddBooksViewModel(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
            SelectImageCommand = new RelayCommand(SelectImage);
            AddBookCommand = new RelayCommand(AddBook);
        }


        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                ValidateProperty(nameof(Title), value);
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _author;
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                ValidateProperty(nameof(Author), value);
                OnPropertyChanged(nameof(Author));
            }
        }

        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                ValidateProperty(nameof(Year), value);
                OnPropertyChanged(nameof(Year));
            }
        }


        private string _isbn;
        public string ISBN
        {
            get => _isbn;
            set
            {
                _isbn = value;
                ValidateProperty(nameof(ISBN), value);
                OnPropertyChanged(nameof(ISBN));
            }
        }


        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                ValidateProperty(nameof(Category), value);
                OnPropertyChanged(nameof(Category));
            }
        }


        private string _publisher;
        public string Publisher
        {
            get => _publisher;
            set
            {
                _publisher = value;
                ValidateProperty(nameof(Publisher), value);
                OnPropertyChanged(nameof(Publisher));
            }
        }

        private int _pageCount;
        public int PageCount
        {
            get => _pageCount;
            set
            {
                _pageCount = value;
                ValidateProperty(nameof(PageCount), value);
                OnPropertyChanged(nameof(PageCount));
            }
        }

        private string _dimensions;
        public string Dimensions
        {
            get => _dimensions;
            set
            {
                _dimensions = value;
                ValidateProperty(nameof(Dimensions), value);
                OnPropertyChanged(nameof(Dimensions));
            }
        }

        private int _copies;
        public int Copies
        {
            get => _copies;
            set
            {
                _copies = value;
                ValidateProperty(nameof(Copies), value);
                OnPropertyChanged(nameof(Copies));
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                ValidateProperty(nameof(Description), value);
                OnPropertyChanged(nameof(Description));
            }
        }

        private byte[] _selectedImage;
        public byte[] SelectedImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                ValidateProperty(nameof(SelectedImage), value);
                OnPropertyChanged(nameof(SelectedImage));
            }
        }

        public ICommand SelectImageCommand { get; }
        public ICommand AddBookCommand { get; }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_propertyErrors.ContainsKey(propertyName))
                return null;

            return _propertyErrors[propertyName];
        }

        private void ValidateProperty(string propertyName, object value)
        {
            var errors = new List<string>();
           // _valid = true;

            switch (propertyName)
            {
                case nameof(Title):
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        errors.Add("Câmp obligatoriu!");
                       
                    }
                    break;

                case nameof(Author):
                    if (string.IsNullOrWhiteSpace((string)value))
                        errors.Add("Câmp obligatoriu!");
                   
                    break;

                case nameof(Year):
                    if ((int)value <= 0)
                        errors.Add("Anul trebuie să fie mai mare decât 0!");
                    if ((int)value < 1450 || (int)value > DateTime.Now.Year)
                        errors.Add($"Anul trebuie să fie între 1450 și {DateTime.Now.Year}!");
                  
                    break;

                case nameof(ISBN):
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        errors.Add("Câmp obligatoriu!");
                    }
                    else if (!IsValidISBN((string)value))
                        errors.Add("ISBN invalid!");
                   
                    break;

                case nameof(Category):
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        errors.Add("Câmp obligatoriu!");
                       
                    }
                    break;

                case nameof(Publisher):
                    if (string.IsNullOrWhiteSpace((string)value))
                    {
                        errors.Add("Câmp obligatoriu!");
                      
                    }
                    break;

                case nameof(PageCount):
                    if ((int)value <= 0)
                        errors.Add("Numărul de pagini trebuie să fie mai mare decât 0!");
                    break;

                case nameof(Dimensions):
                    if (string.IsNullOrWhiteSpace((string)value))
                        errors.Add("Câmp obligatoriu!");
                    break;

                case nameof(Copies):
                    if ((int)value <= 0)
                        errors.Add("Numărul de exemplare trebuie să fie mai mare decât 0!");
                    break;

                case nameof(Description):
                    if (string.IsNullOrWhiteSpace((string)value))
                        errors.Add("Câmp obligatoriu!");
                    break;

                case nameof(SelectedImage):
                    if (value == null)
                        errors.Add("Selectați o imagine!");
                    break;
            }

            if (errors.Count > 0)
            {
                _propertyErrors[propertyName] = errors;
            }
            else if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private bool IsValidISBN(string isbn)
        {
            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length == 10)
                return IsValidISBN10(isbn);
            else if (isbn.Length == 13)
                return IsValidISBN13(isbn);

            return false;
        }

        private bool IsValidISBN10(string isbn)
        {
            if (!long.TryParse(isbn.Substring(0, 9), out _) || !char.IsDigit(isbn[9]) && isbn[9] != 'X')
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (isbn[i] - '0') * (10 - i);
            }
            sum += isbn[9] == 'X' ? 10 : (isbn[9] - '0');

            return sum % 11 == 0;
        }

        private bool IsValidISBN13(string isbn)
        {
            if (!long.TryParse(isbn, out _))
                return false;

            int sum = 0;
            for (int i = 0; i < 13; i++)
            {
                int digit = isbn[i] - '0';
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            return sum % 10 == 0;
        }

        private void SelectImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Selectează o imagine",
                Filter = "Imagini|*.png;*.jpg;*.jpeg;*.bmp",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                SelectedImage = File.ReadAllBytes(filePath);
            }
        }

        private void AddBook()
        {
            if (HasErrors)
            {
                MessageBox.Show("Cartea nu poate fi adăugată!", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }
            if(string.IsNullOrWhiteSpace(this.ISBN)==true || string.IsNullOrWhiteSpace(this.Author)==true || string.IsNullOrWhiteSpace(this.Dimensions) == true
                || string.IsNullOrWhiteSpace(this.Title) == true || string.IsNullOrWhiteSpace(this.Category) == true || this.Copies <= 0
                || string.IsNullOrWhiteSpace(this.Description) == true || this.PageCount == 0 || string.IsNullOrWhiteSpace(this.Publisher) == true
                || this.Year == 0 )
            {
                _valid = false;
            }

            if (_valid==true)
            {
                CarteModel carteModel = new CarteModel();
                bool succes = carteModel.AddCarte(
                title: Title,
                author: Author,
                year: Year,
                isbn: ISBN,
                categorie: Category,
                image: SelectedImage,
                description: Description,
                nrPagini: PageCount,
                dimensiune: Dimensions,
                editura: Publisher,
                nrExemplare: Copies
                );

                if (succes)
                {
                    MessageBox.Show("Cartea a fost adăugată cu succes!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cartea nu a putut fi adăugată!","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Cartea nu poate fi adăugată!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
           

        private void ClearFields()
        {
            Title = string.Empty;
            Author = string.Empty;
            Year = 0;
            ISBN = string.Empty;
            Category = string.Empty;
            Publisher = string.Empty;
            PageCount = 0;
            Dimensions = string.Empty;
            Copies = 0;
            Description = string.Empty;
            SelectedImage = null;

            _propertyErrors.Clear();
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(string.Empty));

            foreach (var propertyName in new[] { nameof(Title), nameof(Author), nameof(Year), nameof(ISBN), nameof(Category), nameof(Publisher), nameof(PageCount), nameof(Dimensions), nameof(Copies), nameof(Description), nameof(SelectedImage) })
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}