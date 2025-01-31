using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BibliotecaElectronica.Model
{
    public abstract class PersoanaModel : INotifyPropertyChanged

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
        protected int Status;


        protected BibliotecaElectronicaClassesDataContext db = new BibliotecaElectronicaClassesDataContext();

        public int IdPerson
        {
            get => idPerson;
            set => idPerson = value;
        }

        public string Nume
        {
            get => LastName;
            set => LastName = value;
        }

        public string Prenume
        {
            get => FirstName;
            set => FirstName = value;
        }

        public string EmailAddress
        {
            get => Email;
            set => Email = value;
        }

        public string Adresa
        {
            get => Address;
            set => Address = value;
        }

        public string Telefon
        {
            get => Phone;
            set => Phone = value;
        }

        public DateTime DataNasterii
        {
            get => BirthDate;
            set => BirthDate = value;
        }


        public int StareCont
        {
            get => Status;
            set => Status = value;
        }
        public string NumeUtilizator
        {
            get => Username;
            set => Username = value;
        }

        public PersoanaModel() { }
        public PersoanaModel(int id, string lastname, string firstname, string username, string password, string email, string phone, string address, DateTime birthdate, int status)
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
            Status = status;
        }

        public PersoanaModel(string _nume, string _prenume, string _adresa, string _telefon, string _email, DateTime birthDate)
        {
            LastName = _nume;
            FirstName = _prenume;
            Address = _adresa;
            Phone = _telefon;
            Email = _email;
            BirthDate = birthDate;
        }
        public abstract PersoanaModel LoginClient(string _username, string _password);
        public abstract PersoanaModel CreateAccount(string _nume, string _prenume, string _adresa, string _telefon, string _email,DateTime birthDate);

        public void setPassword(string _password)
        {
            Password = _password;
        }
        public void setUsername(string _username)
        {
            Username = _username;
        }
        public virtual bool AdaugaClient() { return true; }

        private int _nrNotificariNecitite;
        public int NrNotificariNecitite
        {
            set
            {
                _nrNotificariNecitite = value;
                OnPropertyChanged(nameof(NrNotificariNecitite));
            }
            get
            {
                return _nrNotificariNecitite;
            }
        }

        public int getClientID()
        {
            int id=db.Cititors.Where(c=>c.ID_Persoana==this.idPerson).FirstOrDefault().ID;
            return id;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
