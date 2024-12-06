using BibliotecaElectronica.Commands;
using MaterialDesignThemes.Wpf.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BibliotecaElectronica.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BibliotecaElectronica.ViewModel
{
    public  class CreateAccountViewModel: ViewModelBase
    {
        private string _lastName="Nume";
        Utility u=new Utility();
        public string LastName 
        {
            get
            { 
                return _lastName;
            }
            set
            {
                _lastName = u.CapitalizeFirstLetter(value);
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _firstName = "Prenume";

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = u.CapitalizeFirstLetter(value);
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _email = "Email";
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string _phone="Telefon";
        public string Phone
        {
            get { 
            return _phone;}

            set
            {
                _phone = value;     
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string _address = "Adresă";
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = u.CapitalizeFirstLetter( value);
                OnPropertyChanged(nameof(Address));
            }
        }

        private int _day = 1;
        public int Day
        {
            get { return _day; }
            set
            {
                _day = value;
                OnPropertyChanged(nameof(Day));
            }
        }
        private string _month = "Ianuarie";
        public string Month
        {
            get { return _month; }
            set
            {
                _month = value;
                OnPropertyChanged(nameof(Month));
            }

        }

        private int _year=2024;
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        private readonly ObservableCollection<int> _days;

        public IEnumerable<int> Days => _days;

        private readonly ObservableCollection<string> _months;

        public IEnumerable<string> Months => _months;

        private readonly ObservableCollection<int> _years;
        public IEnumerable<int> Years => _years;

        public ICommand BackToLoginCommand { get; }
        public ICommand ContinueCreatingAccountCommand { get; }

        public ICommand ClearTextBoxCommand { get; }
      
        
        public CreateAccountViewModel(Stores.NavigationStore navigationStore)
        {
            _days= new ObservableCollection<int>();
            for (int i = 1; i <= 31; i++)
            {
                _days.Add(i);
            }

            _months = new ObservableCollection<string>();
            string[] months = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)  // Ultimul element este gol
            {
                _months.Add(months[i]);
            }

            _years = new ObservableCollection<int>();
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= 1960; i--)
            {
                _years.Add(i);
            }

            ContinueCreatingAccountCommand = new ContinueCreatingAccountCommand(navigationStore,this);
            BackToLoginCommand = new BackToLoginCommand(navigationStore);
            ClearTextBoxCommand = new RelayCommand<string>(ClearText);
        }

        private void ClearText(string textBoxName)
        {
            switch (textBoxName)
            {
                case "LastName":
                    LastName = string.Empty;
                    break;
                case "FirstName":
                    FirstName = string.Empty;
                    break;
                case "Phone":
                    Phone = string.Empty;
                    break;
                case "Address":
                    Address = string.Empty;
                    break;
                case "Email":
                    Email = string.Empty;
                    break;

            }
        }
      
    }
}
