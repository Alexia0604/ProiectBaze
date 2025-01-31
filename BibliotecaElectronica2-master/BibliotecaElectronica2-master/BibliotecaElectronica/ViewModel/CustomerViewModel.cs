using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.Utilities;

namespace BibliotecaElectronica.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ClientViewModel _clientViewModel;
        private PersoanaModel persoana;
        private LibrarianViewModel _librarianViewModel;
        private AdminViewModel _adminViewModel;
        private BibliotecaElectronicaClassesDataContext _dbContext;

        private string _lastName;
        private string _firstName;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _birthDate;
        private string _username;
        private string _hireDate;

        public string CustomerLastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(CustomerLastName));
            }
        }

        public string CustomerFirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(CustomerFirstName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string HireDate
        {
            get => _hireDate;
            set
            {
                _hireDate = value;
                OnPropertyChanged(nameof(HireDate));
            }
        }

        private bool _isEditingFirstName;
        public bool IsEditingFirstName
        {
            get => _isEditingFirstName;
            set
            {
                _isEditingFirstName = value;
                OnPropertyChanged(nameof(IsEditingFirstName));
            }
        }

        private bool _isEditingLastName;
        public bool IsEditingLastName
        {
            get => _isEditingLastName;
            set
            {
                _isEditingLastName = value;
                OnPropertyChanged(nameof(IsEditingLastName));
            }
        }

        private bool _isEditingEmail;
        public bool IsEditingEmail
        {
            get => _isEditingEmail;
            set
            {
                _isEditingEmail = value;
                OnPropertyChanged(nameof(IsEditingEmail));
            }
        }

        private bool _isEditingPhoneNumber;
        public bool IsEditingPhoneNumber
        {
            get => _isEditingPhoneNumber;
            set
            {
                _isEditingPhoneNumber = value;
                OnPropertyChanged(nameof(IsEditingPhoneNumber));
            }
        }

        private bool _isEditingAddress;
        public bool IsEditingAddress
        {
            get => _isEditingAddress;
            set
            {
                _isEditingAddress = value;
                OnPropertyChanged(nameof(IsEditingAddress));
            }
        }

        private bool _isEditingUsername;
        public bool IsEditingUsername
        {
            get => _isEditingUsername;
            set
            {
                _isEditingUsername = value;
                OnPropertyChanged(nameof(IsEditingUsername));
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
        public ICommand StartEditCommand { get; }
        public ICommand SaveEditCommand { get; }
        public ICommand CancelEditCommand { get; }
     
        private string _originalFirstName;
        private string _originalLastName;
        private string _originalEmail;
        private string _originalPhoneNumber;
        private string _originalAddress;
        private string _originalUsername;

        public CustomerViewModel(ClientViewModel clientViewModel)
        {
           
            _clientViewModel = clientViewModel;
            _isSectionVisible = false;
            _dbContext = new BibliotecaElectronicaClassesDataContext();

            if (clientViewModel != null && clientViewModel.Persoana != null)
            {
                this.persoana = clientViewModel.Persoana;
                CustomerLastName = clientViewModel.Persoana.Nume;
                CustomerFirstName = clientViewModel.Persoana.Prenume;
                Email = clientViewModel.Persoana.EmailAddress;
                PhoneNumber = clientViewModel.Persoana.Telefon;
                Address = clientViewModel.Persoana.Adresa;
                BirthDate = clientViewModel.Persoana.DataNasterii.ToString("dd/MM/yyyy");
                Username = clientViewModel.Persoana.NumeUtilizator;
            }

          
            StartEditCommand = new RelayCommand<string>(StartEdit);
            SaveEditCommand = new RelayCommand<string>(SaveEdit);
            CancelEditCommand = new RelayCommand<string>(CancelEdit);
        }

        public CustomerViewModel(LibrarianViewModel librarianViewModel)
        {
            _librarianViewModel = librarianViewModel;
            _isSectionVisible = true;
            _dbContext = new BibliotecaElectronicaClassesDataContext();

            BibliotecarModel bibliotecar = new BibliotecarModel();

            if (librarianViewModel != null && librarianViewModel.Persoana != null)
            {
                this.persoana= librarianViewModel.Persoana;
                CustomerLastName = librarianViewModel.Persoana.Nume;
                CustomerFirstName = librarianViewModel.Persoana.Prenume;
                Email = librarianViewModel.Persoana.EmailAddress;
                PhoneNumber = librarianViewModel.Persoana.Telefon;
                Address = librarianViewModel.Persoana.Adresa;
                BirthDate = librarianViewModel.Persoana.DataNasterii.ToString("dd/MM/yyyy");
                Username = librarianViewModel.Persoana.NumeUtilizator;
                HireDate = bibliotecar.getHireDate(librarianViewModel.Persoana.IdPerson).ToString("dd/MM/yyyy");
            }
            StartEditCommand = new RelayCommand<string>(StartEdit);
            SaveEditCommand = new RelayCommand<string>(SaveEdit);
            CancelEditCommand = new RelayCommand<string>(CancelEdit);
        }


        public CustomerViewModel(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
            _isSectionVisible = false;
            _dbContext = new BibliotecaElectronicaClassesDataContext();

            AdministratorModel administrator = new AdministratorModel();

            if (adminViewModel != null && adminViewModel.Persoana != null)
            {
                this.persoana = adminViewModel.Persoana;
                CustomerLastName = adminViewModel.Persoana.Nume;
                CustomerFirstName = adminViewModel.Persoana.Prenume;
                Email = adminViewModel.Persoana.EmailAddress;
                PhoneNumber = adminViewModel.Persoana.Telefon;
                Address = adminViewModel.Persoana.Adresa;
                BirthDate = adminViewModel.Persoana.DataNasterii.ToString("dd/MM/yyyy");
                Username = adminViewModel.Persoana.NumeUtilizator;
            }
            StartEditCommand = new RelayCommand<string>(StartEdit);
            SaveEditCommand = new RelayCommand<string>(SaveEdit);
            CancelEditCommand = new RelayCommand<string>(CancelEdit);
        }

        private void StartEdit(string field)
        {
            switch (field)
            {
                case "FirstName":
                    _originalFirstName = CustomerFirstName;
                    IsEditingFirstName = true;
                    break;
                case "LastName":
                    _originalLastName = CustomerLastName;
                    IsEditingLastName = true;
                    break;
                case "Email":
                    _originalEmail = Email;
                    IsEditingEmail = true;
                    break;
                case "PhoneNumber":
                    _originalPhoneNumber = PhoneNumber;
                    IsEditingPhoneNumber = true;
                    break;
                case "Address":
                    _originalAddress = Address;
                    IsEditingAddress = true;
                    break;
                case "Username":
                    _originalUsername = Username;
                    IsEditingUsername = true;
                    break;
            }
        }

        private void SaveEdit(string field)
        {
            var persoana = _dbContext.Persoanas.FirstOrDefault(p => p.ID ==this.persoana.IdPerson);
            if (persoana == null) return;
            try
            {
                var u = new Utility();
                switch (field)
                {
                    case "FirstName":
                        persoana.Prenume = CustomerFirstName;
                        this.persoana.Prenume = CustomerFirstName;
                        IsEditingFirstName = false;
                        break;
                    case "LastName":
                        persoana.Nume = CustomerLastName;
                        this.persoana.Nume = CustomerLastName;
                        IsEditingLastName = false;
                        break;
                    case "Email":
                        if (u.IsValidEmail(Email) == false)
                        {
                            throw new EmailException();
                        }
                        persoana.Email = Email;

                        this.persoana.EmailAddress = Email;
                        IsEditingEmail = false;
                        break;
                    case "PhoneNumber":
                        if (u.IsValidNr(PhoneNumber)== false)
                        {
                            throw new NrException();
                        }
                        persoana.Telefon = PhoneNumber;
                        this.persoana.Telefon = PhoneNumber;
                        IsEditingPhoneNumber = false;
                        break;
                    case "Address":
                        persoana.Adresa = Address;
                        this.persoana.Adresa = Address;
                        IsEditingAddress = false;
                        break;
                    case "Username":
                        if (u.IsValidUsername(Username) == false)
                        {
                            throw new UsernameException();
                        }
                        persoana.Username = Username;
                        this.persoana.NumeUtilizator = Username;
                        IsEditingUsername = false;
                        break;
                }
            }
            catch(EmailException e)
            {
                MessageBox.Show("Adresă de email incorectă!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NrException e)
            {
                MessageBox.Show("Număr de telefon incorect!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (UsernameException e)
            {
                MessageBox.Show("Username indisponibil!!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _dbContext.SubmitChanges();
        }



        private void CancelEdit(string field)
        {
            switch (field)
            {
                case "FirstName":
                    CustomerFirstName = _originalFirstName;
                    IsEditingFirstName = false;
                    break;
                case "LastName":
                    CustomerLastName = _originalLastName;
                    IsEditingLastName = false;
                    break;
                case "Email":
                    Email = _originalEmail;
                    IsEditingEmail = false;
                    break;
                case "PhoneNumber":
                    PhoneNumber = _originalPhoneNumber;
                    IsEditingPhoneNumber = false;
                    break;
                case "Address":
                    Address = _originalAddress;
                    IsEditingAddress = false;
                    break;
                case "Username":
                    Username = _originalUsername;
                    IsEditingUsername = false;
                    break;
            }
        }



        public CustomerViewModel()
        {

        }
    }
}
