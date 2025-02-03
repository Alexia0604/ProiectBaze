using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BibliotecaElectronica.View;
using System.Windows;


namespace BibliotecaElectronica.Model
{
    public class BibliotecarModel : PersoanaModel
    {
        private int IDBibliotecar;
        private DateTime hiredDate;

        public DateTime HireDate
        {
            get => hiredDate;
            set
            {
                hiredDate = value;
            }
        }

        public string Email
        {
            get => base.EmailAddress; 
            set
            {
                base.EmailAddress = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public BibliotecarModel(int idBibliotecar, int idPersoana, string lastname, string firstname, string username, string password,
           string email, string phone, string address, DateTime birthdate, int status) : base(idPersoana, lastname, firstname, username,
               password, email, address, phone, birthdate, status)
        {
            IDBibliotecar = idBibliotecar;
        }

        public BibliotecarModel(string lastname, string firstname, string email, string phone,
            string address, DateTime birthdate, string username)
        {
            HireDate = hiredDate;
        }

        public DateTime getHireDate(int idPersoana)
        {
            var db = new BibliotecaElectronicaEntities3();
            return db.Bibliotecars.Where(c => c.ID_Persoana == idPersoana).FirstOrDefault().DataAngajare;
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
            var db = new BibliotecaElectronicaEntities3();
            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {
                if (user.StareCont == 0)
                {
                    throw new ClosedAccountException();
                    
                }

                var bibliotecar_db = db.Bibliotecars.SingleOrDefault(a => a.ID_Persoana == user.ID);
                if (bibliotecar_db != null)
                {    
                    this.IDBibliotecar = bibliotecar_db.ID;
                    this.IdPerson = bibliotecar_db.ID_Persoana.GetValueOrDefault();
                    this.LastName = bibliotecar_db.Persoana.Nume;
                    this.FirstName = bibliotecar_db.Persoana.Prenume;
                    this.Username = bibliotecar_db.Persoana.Username;
                    this.Password = bibliotecar_db.Persoana.Parola;
                    this.Email = bibliotecar_db.Persoana.Email;
                    this.Phone = bibliotecar_db.Persoana.Telefon;
                    this.Adresa = bibliotecar_db.Persoana.Adresa;
                    this.BirthDate = bibliotecar_db.Persoana.DataNasterii.GetValueOrDefault();
                    this.HireDate = bibliotecar_db.DataAngajare;


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

        public static ObservableCollection<BibliotecarModel> LoadAllLibrarians()
        {
            var db = new BibliotecaElectronicaEntities3();
            var allLibrariansData = db.Bibliotecars.Join(db.Persoanas,
            bibliotecar => bibliotecar.ID_Persoana,
            persoana => persoana.ID,
            (bibliotecar, persoana) => new
            {
                BibliotecarID = bibliotecar.ID,
                PersoanaID = persoana.ID,
                Nume = persoana.Nume,
                Prenume = persoana.Prenume,
                Telefon = persoana.Telefon,
                Email = persoana.Email,
                Adresa = persoana.Adresa,
                Username = persoana.Username,
                DataNasterii = persoana.DataNasterii,
                StareCont = persoana.StareCont,
                DataAngajare = bibliotecar.DataAngajare
            })
        .Where(c => c.StareCont == 1)
        .ToList();

            var allLibrarians = allLibrariansData.Select(c => new BibliotecarModel
            {
                IDBibliotecar = c.BibliotecarID,
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

            ObservableCollection<BibliotecarModel> bibliotecari = new ObservableCollection<BibliotecarModel>(allLibrarians);

            return bibliotecari;
        }

        public static void DeleteLibrarian(BibliotecarModel librarianToDelete)
        {
            var db = new BibliotecaElectronicaEntities3();
            var bibliotecarDb = db.Bibliotecars.SingleOrDefault(c => c.ID_Persoana == librarianToDelete.idPerson);

            if (bibliotecarDb != null)
            {
                try
                {
                    bibliotecarDb.Persoana.StareCont = 0;
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
