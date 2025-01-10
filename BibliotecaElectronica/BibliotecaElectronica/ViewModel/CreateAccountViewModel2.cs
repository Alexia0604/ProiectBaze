using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BibliotecaElectronica.ViewModel
{
    public class CreateAccountViewModel2 : ViewModelBase
    {
        private PersoanaModel Client;
        private string _username="Username";
        
        public string Username2 { 
            get 
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username2));
            }
        }

        private string _password = "Parola";
        public string Password2 {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password2));
            }
        }


        private string _password3 = "Parola";
        public string Password3
        {
            get
            {
                return _password3;
            }
            set
            {
                _password3 = value;
                OnPropertyChanged(nameof(Password3));
            }
        }

        public ICommand BackToCreateAccountCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ClearTextBoxCommand { get; }

        public CreateAccountViewModel2(Stores.NavigationStore navigationStore,CititorModel client)
        {
            Client = client;
            ClearTextBoxCommand = new RelayCommand<string>(ClearText);
            BackToCreateAccountCommand =new BackToCreateAccountCommand(navigationStore);

            if (_password != _password3)
            {
                // Golește câmpurile de parolă și confirmare
                _password = string.Empty;
                _password3 = string.Empty;

                // Afișează un mesaj de eroare
                MessageBox.Show("Parolele nu coincid! Vă rugăm să le introduceți din nou.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                RegisterCommand =new RegisterCommand(navigationStore,this,client);
            }
        }

        private void CheckPasswordsMatch()
        {
            if (Password2 != _password3)
            {
                // Golește câmpurile de parolă și confirmare
                _password = string.Empty;
                _password3 = string.Empty;

                // Afișează un mesaj de eroare
                MessageBox.Show("Parolele nu coincid! Vă rugăm să le introduceți din nou.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearText(string textBoxName)
        {
            switch (textBoxName)
            {
                case "Username":
                    Username2 = string.Empty;
                    break;
                case "Password":
                    Password2 = string.Empty;
                    break;
                case "Password2":
                    Password3 = string.Empty;
                    break;
            }
        }
    }
}
