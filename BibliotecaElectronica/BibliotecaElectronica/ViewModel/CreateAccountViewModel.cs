using BibliotecaElectronica.Commands;
using MaterialDesignThemes.Wpf.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BibliotecaElectronica.Utilities;



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

        public ICommand BackToLoginCommand { get; }
        public ICommand ContinueCreatingAccountCommand { get; }

        public ICommand ClearTextBoxCommand { get; }
        public CreateAccountViewModel(Stores.NavigationStore navigationStore)
        {
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
