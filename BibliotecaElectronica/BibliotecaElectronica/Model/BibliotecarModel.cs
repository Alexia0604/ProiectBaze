using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Model
{
    public class BibliotecarModel : PersoanaModel
    {
        private int IDBibliotecar;
        private DateTime HiredDate;

       public BibliotecarModel(int idBibliotecar, int idPersoana, string lastname, string firstname, string username, string password,
           string email, string phone, string address, DateTime birthdate) : base(idPersoana, lastname, firstname, username,
               password, email, address, phone, birthdate)
        {
            IDBibliotecar = idBibliotecar;
        }

        public BibliotecarModel(string _nume, string _prenume, string _adresa, string _telefon, string _email, DateTime birthDate) : base(_nume, _prenume,
         _adresa, _telefon, _email, birthDate)
        { }
        public BibliotecarModel() { }
        public override PersoanaModel CreateAccount(string _nume, string _prenume, string _adresa, string _telefon, string _email, DateTime birthDate)
        {
            if (_nume == "Nume" || _prenume == "Prenume" || _telefon == "Telefon" || _email == "Email" ||
             _nume == string.Empty || _prenume == string.Empty || _telefon == string.Empty || _email == string.Empty)
                throw new AccountException();

            Utility u = new Utility();
            if (!u.IsValidEmail(_email))
                throw new EmailException();
            LastName = _nume;
            FirstName = _prenume;
            Address = _adresa;
            Phone = _telefon;
            Email = _email;
            BirthDate = birthDate;

            return this;
        }

        public override PersoanaModel LoginClient(string _username, string _password)
        {
            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {

                var bibliotecar_db = db.Bibliotecars.SingleOrDefault(a => a.ID_Persoana == user.ID);
                if (bibliotecar_db != null)
                {
                    BibliotecarModel bibliotecar = new BibliotecarModel(bibliotecar_db.ID, bibliotecar_db.ID_Persoana.GetValueOrDefault(),
                        bibliotecar_db.Persoana.Nume, bibliotecar_db.Persoana.Prenume, bibliotecar_db.Persoana.Username,
                        bibliotecar_db.Persoana.Parola, bibliotecar_db.Persoana.Email, bibliotecar_db.Persoana.Adresa,
                        bibliotecar_db.Persoana.Telefon, bibliotecar_db.Persoana.DataNasterii.GetValueOrDefault());

                    return bibliotecar;
                }
                else
                    throw new SignInException();
            }
            else
            {
                throw new SignInWrongCredentialsException();
            }
        }
    }
}
