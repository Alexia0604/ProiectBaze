﻿using BibliotecaElectronica.Exceptions;
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

namespace BibliotecaElectronica.Model
{
    public class CititorModel : PersoanaModel
    {
        private int idReader;
        private DateTime registerDate;
        private int? nrOfBooks;
    
       public CititorModel(int iD) { }

        public CititorModel(int idReader, DateTime registerDate, int? nrOfBooks,
            int idPerson, string lastname, string firstname, string username, string password, 
            string email, string address,string phone, DateTime birthdate):base (idPerson,lastname,firstname,username
                ,password,email,address,phone,birthdate)
        {
            this.idReader = idReader;
            this.registerDate = registerDate;
            this.nrOfBooks = nrOfBooks;
        }
        public CititorModel(string _nume,string _prenume,string _adresa,string _telefon, string _email): base(_nume,_prenume,
            _adresa, _telefon, _email)
        { }
        
        public CititorModel() { }
        public override PersoanaModel LoginClient(string _username, string _password)
        {
            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {
                
                var reader_db = db.Cititors.SingleOrDefault(c => c.ID_Persoana == user.ID);
                if ( reader_db!= null)
                {
                    CititorModel reader = new CititorModel(reader_db.ID, reader_db.DataInregistrare, reader_db.NrCartiImprumutate,
                        reader_db.ID_Persoana.GetValueOrDefault(), reader_db.Persoana.Nume, reader_db.Persoana.Prenume, reader_db.Persoana.Username,
                        reader_db.Persoana.Parola, reader_db.Persoana.Email, reader_db.Persoana.Adresa,reader_db.Persoana.Telefon, reader_db.Persoana.DataNasterii.GetValueOrDefault());
                 
                    return reader;
                }
                else
                  throw new SignInException();
            }
            else
            {
                throw new SignInWrongCredentialsException();
            }
        }

        public override PersoanaModel CreateAccount(string _nume, string _prenume, string _adresa, string _telefon, string _email)
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
            return this;
        }

        public override bool AdaugaClient()
        {
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
            db.Persoanas.InsertOnSubmit(cititor_db.Persoana);
            db.Cititors.InsertOnSubmit(cititor_db);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                throw new DataBaseException();
            }

        }
    }
}