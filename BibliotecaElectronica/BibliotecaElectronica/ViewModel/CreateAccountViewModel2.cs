﻿using BibliotecaElectronica.Commands;
using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BibliotecaElectronica.ViewModel
{
    public class CreateAccountViewModel2 : ViewModelBase
    {
        private ClientRepository Client;
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

        public ICommand BackToCreateAccountCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ClearTextBoxCommand { get; }

        public CreateAccountViewModel2(Stores.NavigationStore navigationStore,ClientRepository client)
        {
            Client = client;
            ClearTextBoxCommand = new RelayCommand<string>(ClearText);
            BackToCreateAccountCommand =new BackToCreateAccountCommand(navigationStore);
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
            }
        }
    }
}