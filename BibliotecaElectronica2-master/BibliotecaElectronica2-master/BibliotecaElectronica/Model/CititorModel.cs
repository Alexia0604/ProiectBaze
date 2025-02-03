using BibliotecaElectronica.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.Utilities;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using BibliotecaElectronica.Exceptions;
using System.Collections.ObjectModel;
using BibliotecaElectronica.View;

namespace BibliotecaElectronica.Model
{
    public class CititorModel : PersoanaModel
    {

        private int idReader;
        private DateTime registerDate;
        private int? nrOfBooks;

        public string Email
        {
            get => base.EmailAddress; 
            set
            {
                base.EmailAddress = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public int IDReader
        {
            get => idReader;
            set
            {
                idReader = value;
                OnPropertyChanged(nameof(IDReader));
            }
        }

        public int IdPerson
        {
            get => base.idPerson;
            set
            {
                base.idPerson = value;
                OnPropertyChanged(nameof(IdPerson));
            }
        }

        public CititorModel(int iD) { }

        public CititorModel(int idReader, DateTime registerDate, int? nrOfBooks,
            int idPerson, string lastname, string firstname, string username, string password, 
            string email, string address,string phone, DateTime birthdate, int status):base (idPerson,lastname,firstname,username
                ,password,email,address,phone,birthdate,status)
        {
            this.idReader = idReader;
            this.registerDate = registerDate;
            this.nrOfBooks = nrOfBooks;
        }
        public CititorModel(string _nume,string _prenume,string _adresa,string _telefon, string _email, DateTime birthDate): base(_nume,_prenume,
            _adresa, _telefon, _email,birthDate)
        { }
        
        public CititorModel() { }
        public override PersoanaModel LoginClient(string _username, string _password)
        {
            var db = new BibliotecaElectronicaEntities3();

            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {
                if (user.StareCont == 0)
                {
                    throw new ClosedAccountException();
                }
                var reader_db = db.Cititors.SingleOrDefault(c => c.ID_Persoana == user.ID);
                if (reader_db != null)
                {
                    this.idReader = reader_db.ID;
                    this.registerDate = reader_db.DataInregistrare;
                    this.nrOfBooks = reader_db.NrCartiImprumutate;
                    this.idPerson = reader_db.ID_Persoana.GetValueOrDefault();
                    this.FirstName = reader_db.Persoana.Prenume;
                    this.LastName = reader_db.Persoana.Nume;
                    this.Password = reader_db.Persoana.Parola;
                    this.Email = reader_db.Persoana.Email;
                    this.Address = reader_db.Persoana.Adresa;
                    this.Phone = reader_db.Persoana.Telefon;
                    this.BirthDate = reader_db.Persoana.DataNasterii.GetValueOrDefault();
                    this.NumeUtilizator = reader_db.Persoana.Username;


                    return this;
                }
                else
                    throw new SignInException();
            }
            else
            {
                //MessageBox.Show("Contul este inchis. Nu va puteti conecta!");
                throw new SignInWrongCredentialsException();
            }

        }

        public override PersoanaModel CreateAccount(string _nume, string _prenume, string _adresa, string _telefon, string _email, DateTime birthDate)
        {
            if (_nume == "Nume" || _prenume == "Prenume" || _telefon == "Telefon" || _email == "Email" ||
               _nume == string.Empty || _prenume == string.Empty || _telefon == string.Empty || _email == string.Empty)
                throw new AccountException();

            Utility u = new Utility();
            if (!u.IsValidEmail(_email))
                throw new EmailException();
            if(!u.IsValidNr(_telefon))
                throw new NrException();

            LastName = _nume;
            FirstName = _prenume;
            Address = _adresa;
            Phone = _telefon;
            Email = _email;
            BirthDate = birthDate;

            return this;
        }

        public override bool AdaugaClient()
        {
            var db = new BibliotecaElectronicaEntities3();
            if (this.Username == "Username" || this.Password == "Parolă" ||
                this.Username == string.Empty || this.Password == string.Empty)
                throw new NoUsernameOrPasswordException();
            
            Cititor cititor_db = new Cititor { DataInregistrare=DateTime.Now, NrCartiImprumutate=0};
            Persoana persoana = new Persoana
            {
                Nume = this.LastName,
                Prenume = this.FirstName,
                Adresa = this.Address,
                Telefon = this.Phone,
                Email = this.Email,
                Parola = this.Password,
                DataNasterii = this.BirthDate,
                Username = this.Username
            };
            cititor_db.Persoana = persoana;
            try
            {
                db.Persoanas.Add(cititor_db.Persoana);
                db.Cititors.Add(cititor_db);
   
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw new DataBaseException();
            }

        }

        public static ObservableCollection<CititorModel> LoadAllReaders()
        {
            var db = new BibliotecaElectronicaEntities3();
            var allreadersData = db.Cititors.Join(db.Persoanas,
            cititor => cititor.ID_Persoana,
            persoana => persoana.ID,
            (cititor, persoana) => new
            {
                CititorID = cititor.ID,
                PersoanaID = persoana.ID,
                Nume = persoana.Nume,
                Prenume = persoana.Prenume,
                Telefon = persoana.Telefon,
                Email = persoana.Email,
                Adresa = persoana.Adresa,
                Username = persoana.Username,
                DataNasterii = persoana.DataNasterii,
                StareCont = persoana.StareCont,
                DataInregistrare = cititor.DataInregistrare,
                NrCartiImprumutate = cititor.NrCartiImprumutate
            })
            .Where(c => c.StareCont == 1)
            .ToList();

            var allreaders = allreadersData.Select(c => new CititorModel
            {
                idReader = c.CititorID,
                idPerson = c.PersoanaID,
                LastName = c.Nume,
                FirstName = c.Prenume,
                Phone = c.Telefon,
                Email = c.Email,
                Address = c.Adresa,
                Username = c.Username,
                BirthDate = c.DataNasterii.GetValueOrDefault(),
                Status = c.StareCont.GetValueOrDefault()
            }).ToList();

            ObservableCollection<CititorModel> cititori = new ObservableCollection<CititorModel>(allreaders);

            return cititori;
        }

        public static void DeleteReader(CititorModel readerToDelete)
        {
            var db = new BibliotecaElectronicaEntities3();

            var cititorDb = db.Cititors.SingleOrDefault(c => c.ID_Persoana == readerToDelete.idPerson);

            if (cititorDb != null)
            {
                try
                {
                    cititorDb.Persoana.StareCont = 0;
                    db.SaveChanges();

                    MessageBox.Show("Cititorul a fost șters cu succes!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"A apărut o eroare la ștergerea cititorului: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Cititorul nu a fost găsit în baza de date.");
            }
        }
    }
}
