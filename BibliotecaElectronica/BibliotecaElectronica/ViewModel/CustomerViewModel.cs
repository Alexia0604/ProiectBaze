﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;

namespace BibliotecaElectronica.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ClientViewModel _clientViewModel;

        private BibliotecaElectronicaClassesDataContext _dbContext;


        private string _lastName;
        private string _firstName;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _birthDate;
        private string _username;

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

        // Comenzi
        public ICommand StartEditCommand { get; }
        public ICommand SaveEditCommand { get; }
        public ICommand CancelEditCommand { get; }

        // Valori originale pentru a putea anula modificările
        private string _originalFirstName;
        private string _originalLastName;
        private string _originalEmail;
        private string _originalPhoneNumber;
        private string _originalAddress;
        private string _originalUsername;

        public CustomerViewModel(ClientViewModel clientViewModel)
        {
            // Inițializări existente...
            _clientViewModel = clientViewModel;
            _dbContext = new BibliotecaElectronicaClassesDataContext();

            if (clientViewModel != null && clientViewModel._persoana != null)
            {
                CustomerLastName = clientViewModel._persoana.Nume;
                CustomerFirstName = clientViewModel._persoana.Prenume;
                Email = clientViewModel._persoana.EmailAddress;
                PhoneNumber = clientViewModel._persoana.Telefon;
                Address = clientViewModel._persoana.Adresa;
                BirthDate = clientViewModel._persoana.DataNasterii.ToString("dd/MM/yyyy");
                Username = clientViewModel._persoana.NumeUtilizator;
            }

            // Inițializare comenzi
            StartEditCommand = new RelayCommand<string>(StartEdit);
            SaveEditCommand = new RelayCommand<string>(SaveEdit);
            CancelEditCommand = new RelayCommand<string>(CancelEdit);
        }

        // Metode pentru comenzi
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
            var persoana = _dbContext.Persoanas.FirstOrDefault(p => p.ID == _clientViewModel._persoana.IdPerson);
            if (persoana == null) return;

            switch (field)
            {
                case "FirstName":
                    persoana.Prenume = CustomerFirstName;
                    _clientViewModel._persoana.Prenume=CustomerFirstName;
                    IsEditingFirstName = false;
                    break;
                case "LastName":
                    persoana.Nume = CustomerLastName;
                    _clientViewModel._persoana.Nume=CustomerLastName;
                    IsEditingLastName = false;
                    break;
                case "Email":
                    persoana.Email = Email;
                    _clientViewModel._persoana.EmailAddress=Email;
                    IsEditingEmail = false;
                    break;
                case "PhoneNumber":
                    persoana.Telefon = PhoneNumber;
                    _clientViewModel._persoana.Telefon=PhoneNumber;
                    IsEditingPhoneNumber = false;
                    break;
                case "Address":
                    persoana.Adresa = Address;
                    _clientViewModel._persoana.Adresa=Address;
                    IsEditingAddress = false;
                    break;
                case "Username":
                    persoana.Username = Username;
                    _clientViewModel._persoana.NumeUtilizator=Username;
                    IsEditingUsername = false;
                    break;
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
