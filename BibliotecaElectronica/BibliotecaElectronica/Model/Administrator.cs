﻿using BibliotecaElectronica.Exceptions;
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
            string email, string phone, string address, DateTime birthdate): base(idPersoana, lastname, firstname, username, 
                password, email, address, phone, birthdate)
        {
            IDAdmin = idAdmin;
        }
        public AdministratorModel(string _nume, string _prenume, string _adresa, string _telefon, string _email) : base(_nume, _prenume,
          _adresa, _telefon, _email)
        { }

        public AdministratorModel() { }
        public override PersoanaModel CreateAccount(string _nume, string _prenume, string _adresa, string _telefon, string _email)
        {
            if (_nume == "Nume" || _prenume == "Prenume" || _telefon == "Telefon" || _email == "Email" ||
              _nume == string.Empty || _prenume == string.Empty || _telefon == string.Empty || _email == string.Empty)
                throw new AccountException();

            Utility u = new Utility();
            if (!u.IsValidEmail(_email))
                throw new EmailException();

            AdministratorModel admin = new AdministratorModel(_nume, _prenume, _adresa, _telefon, _email);
            return admin;
        }

        public override PersoanaModel LoginClient(string _username, string _password)
        {

            var user = db.Persoanas.SingleOrDefault(u => u.Username == _username && u.Parola == _password);
            if (user != null)
            {

                var admin_db = db.Administrators.SingleOrDefault(a => a.ID_Persoana == user.ID); 
                if (admin_db!=null)
                {
                    AdministratorModel admin = new AdministratorModel(admin_db.ID, admin_db.ID_Persoana.GetValueOrDefault(), 
                        admin_db.Persoana.Nume, admin_db.Persoana.Prenume, admin_db.Persoana.Username,
                        admin_db.Persoana.Parola, admin_db.Persoana.Email, admin_db.Persoana.Adresa,
                        admin_db.Persoana.Telefon, admin_db.Persoana.DataNasterii.GetValueOrDefault());

                    return admin;
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