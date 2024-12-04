using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibliotecaElectronica.Model
{
    public abstract class PersoanaModel
    {
        protected int idPerson;
        protected string LastName; //nume
        protected string FirstName; //prenume
        protected string Username;
        protected string Password;
        protected string Email;
        protected string Address;
        protected string Phone;
        protected DateTime BirthDate;

        protected BibliotecaElectronicaClassesDataContext db = new BibliotecaElectronicaClassesDataContext();

        public PersoanaModel() { }
        public PersoanaModel(int id, string lastname, string firstname, string username, string password, string email, string phone, string address, DateTime birthdate)
        {
            idPerson = id;
            LastName = lastname;
            FirstName = firstname;
            Username = username;
            Password = password;
            Email = email;
            Address = address;
            Phone = phone;
            BirthDate = birthdate;
        }

        public PersoanaModel(string _nume, string _prenume, string _adresa, string _telefon, string _email)
        {
            LastName = _nume;
            FirstName = _prenume;
            Address = _adresa;
            Phone = _telefon;
            Email = _email;
        }
        public abstract PersoanaModel LoginClient(string _username, string _password);
        public abstract PersoanaModel CreateAccount(string _nume, string _prenume, string _adresa, string _telefon, string _email);

        public void setPassword(string _password)
        {
            Password = _password;
        }
        public void setUsername(string _username)
        {
            Username = _username;
        }
        public virtual bool AdaugaClient() { return true; }
    }
}
