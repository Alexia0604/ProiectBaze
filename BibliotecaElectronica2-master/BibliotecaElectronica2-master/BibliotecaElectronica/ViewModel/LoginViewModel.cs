using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BibliotecaElectronica.Services;


namespace BibliotecaElectronica.ViewModel
{
    public class LoginViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private string _username = "Username";

        [Required(ErrorMessage ="Câmp obligatoriu!")]
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                Validate(nameof(Username), value);
            }
        }

        private string _password="Password";

        [Required(ErrorMessage = "Câmp obligatoriu!")]
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                Validate(nameof(Password), value);
            }
        }

        public ICommand SignInCommand { get; }
        public ICommand CreateAccountCommand { get; }

        public ICommand TextBoxLostFocusCommand { get; }
        public ICommand TextBoxGotFocusCommand { get; }

        private readonly ObservableCollection<string> _roles;

        private string _selectedRole="Cititor";

        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
           
            }
        }

        public IEnumerable<string> Roles => _roles;

        private  Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();
        public bool HasErrors => Errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        
        public LoginViewModel(NavigationStore navigationStore) 
        {

           _roles = new ObservableCollection<string> { "Cititor", "Bibliotecar","Administrator" };
            SignInCommand = new SignInCommand(this,navigationStore);
            CreateAccountCommand = new CreateAccountCommand(navigationStore);
        }

       
        public IEnumerable GetErrors(string propertyName)
        {
           if(Errors.ContainsKey(propertyName))
           {
                return Errors[propertyName];
           }
           else
                return Enumerable.Empty<string>();  
        }

        public void Validate(string propertyName, object propertyValue)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(propertyValue, new ValidationContext(this) { MemberName = propertyName },results);

            if(results.Any())
            {
                Errors.Add(propertyName, results.Select(r => r.ErrorMessage).ToList());
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
            else
            {
                Errors.Remove(propertyName);
            }
        }

    }

  

}
