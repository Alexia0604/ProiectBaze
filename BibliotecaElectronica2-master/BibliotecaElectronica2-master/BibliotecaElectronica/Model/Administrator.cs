using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Model
{
    public class AdministratorModel : PersoanaModel
    {
        private int IDAdmin;
        AdministratorModel(int idAdmin, int idPersoana, string lastname, string firstname, string username, string password,
            string email, string phone, string address, DateTime birthdate, int status): base(idPersoana, lastname, firstname, username, 
                password, email, address, phone, birthdate, status)
        {
            IDAdmin = idAdmin;
        }
        public AdministratorModel(string _nume, string _prenume, string _adresa, string _telefon, string _email,DateTime birthdate) : base(_nume, _prenume,
          _adresa, _telefon, _email,birthdate)
        { }

        public AdministratorModel() { }
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
            var db = new BibliotecaElectronicaEntities3();
            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {

                var admin_db = db.Administrators.SingleOrDefault(a => a.ID_Persoana == user.ID); 
                if (admin_db!=null)
                {
                    this.IDAdmin = admin_db.ID;
                    this.IdPerson = admin_db.ID_Persoana.GetValueOrDefault();
                    this.LastName = admin_db.Persoana.Nume;
                    this.FirstName = admin_db.Persoana.Prenume;
                    this.Username = admin_db.Persoana.Username;
                    this.Password = admin_db.Persoana.Parola;
                    this.Email = admin_db.Persoana.Email;
                    this.Address = admin_db.Persoana.Adresa;
                    this.Phone = admin_db.Persoana.Telefon;
                    this.BirthDate = admin_db.Persoana.DataNasterii.GetValueOrDefault();

                    return this;
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
