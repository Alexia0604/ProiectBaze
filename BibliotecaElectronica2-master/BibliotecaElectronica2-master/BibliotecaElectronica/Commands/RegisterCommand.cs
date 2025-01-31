using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.Utilities;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Commands
{
    public class RegisterCommand : CommandBase
    {
        
        private PersoanaModel client;
        private readonly CreateAccountViewModel2 viewModel;
        private readonly NavigationStore _navigationStore;


        public RegisterCommand(NavigationStore navigationStore,CreateAccountViewModel2 _viewModel,PersoanaModel _client)
        {
            viewModel= _viewModel;
            _navigationStore=navigationStore;
            client = _client;
        }
        public override void Execute(object parameter)
        {
            var u = new Utility();
            try
            {
                
                if (viewModel.Password2 != viewModel.Password3)
                {
                    viewModel.Password2 = string.Empty;
                    viewModel.Password3 = string.Empty;

                    throw new MatchingPasswordsFailed();
                }
                if (u.IsValidPassword(viewModel.Password2)==false)
                {
                    throw new PasswordException();
                }
                string hashedPassword = EncryptPassword(viewModel.Password2);

                var db = new BibliotecaElectronicaClassesDataContext();
                var username = db.Persoanas.Where(p => p.Username == viewModel.Username2).FirstOrDefault();
                if (username == null)
                {
                    client.setUsername(viewModel.Username2);
                    client.setPassword(hashedPassword);
                }
                else
                {
                    throw new UsernameException();
                }

                client.AdaugaClient();
                MessageBox.Show("Te-ai înregistrat cu succes!", "Mesaj înregistrare", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);

            }
            catch (UsernameException e)
            {
                MessageBox.Show("Acest username nu este disponibil! Încercați unul nou! ", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NoUsernameOrPasswordException e)
            {
                MessageBox.Show("Înregistrare eșuată! Username sau parolă lipsă!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (DataBaseException e)
            {
                MessageBox.Show("Înregistrare eșuată! Încearcă din nou!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (MatchingPasswordsFailed e)
            {
                MessageBox.Show("Parolele nu coincid! Vă rugăm să le introduceți din nou.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (PasswordException e)
            {
                MessageBox.Show("Parolă slabă! Încercați una mai puternică, cel puțin: 8 caractere, o literă mare, cifre și caractere speciale! ", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
