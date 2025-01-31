using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;


namespace BibliotecaElectronica.Model
{   
    public class ClientRepository
    {
        private BibliotecaElectronicaClassesDataContext db = new BibliotecaElectronicaClassesDataContext();

        private bool IsValidEmail(string email)
        {
         
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public BibliotecaElectronica.Persoana LoginClient(string _username, string _password, string _role)
        {
            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {
                switch (_role)
                {
                    case "Administrator":
                        var admin = db.Administrators.SingleOrDefault(a => a.ID_Persoana == user.ID);
                        if (admin != null)
                            return user;
                        throw new SignInException();

                    case "Client":
                        var client = db.Cititors.SingleOrDefault(c => c.ID_Persoana == user.ID);
                        if (client != null)
                            return user;
                        throw new SignInException();

                    case "Bibliotecar":
                        var bibliotecar = db.Bibliotecars.SingleOrDefault(b => b.ID_Persoana == user.ID);
                        if (bibliotecar != null)
                            return user;
                        throw new SignInException();

                    default:
                        throw new SignInException();
                }
            }
            else
            {
                throw new SignInWrongCredentialsException();    
            }
        }

        public BibliotecaElectronica.Cititor CreateAccount(string _nume,string _prenume, string _adresa,string _telefon,string _email)
        {
            if (_nume == "Nume" || _prenume == "Prenume" || _telefon == "Telefon" || _email == "Email" ||
               _nume == string.Empty || _prenume == string.Empty || _telefon == string.Empty || _email == string.Empty)
                throw new AccountException();

            if(!IsValidEmail(_email))
                throw new EmailException();

            BibliotecaElectronica.Cititor cititor = new BibliotecaElectronica.Cititor();
            cititor.Persoana = new BibliotecaElectronica.Persoana();
            cititor.Persoana.Nume = _nume;
            cititor.Persoana.Prenume = _prenume;
            cititor.Persoana.Adresa = _adresa;
            cititor.Persoana.Telefon = _telefon;
            cititor.Persoana.Email = _email;
            return cititor;
            
        }
    }
}
