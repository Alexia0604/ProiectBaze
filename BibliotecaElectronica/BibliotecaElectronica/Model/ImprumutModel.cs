﻿using BibliotecaElectronica.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Model
{
    public class ImprumutModel:INotifyPropertyChanged
    {
        private int idImprumut;
        private int idCarte;
        private int idCititor;
        private DateTime dataImprumut;
        private DateTime dataLimita;
        private DateTime dataReturnare;
        private string stare;

        private bool _isPopupOpen;
        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                _isPopupOpen = value;
                OnPropertyChanged(nameof(IsPopupOpen));
            }
        }

        private bool isImprumutActiv;

        public int IDImprumut
        {
            get => idImprumut;
            set => idImprumut = value;
        }
        public bool IsImprumutActiv
        {
            get { return isImprumutActiv; }
            set
            {
                isImprumutActiv = value;
                OnPropertyChanged(nameof(IsImprumutActiv));
            }
        }
        public DateTime DataImprumut
        {
            get => dataImprumut;
            set => dataImprumut=value;
        }
        public string Stare
        {
            get => stare;
            set {
                stare = value;
                OnPropertyChanged(nameof(Stare));
            }
        }
        public DateTime DataReturnare
        {
            get { return dataReturnare; }
            set { dataReturnare = value;
                OnPropertyChanged(nameof(DataReturnare));
            }
        }

        private string _dataReturnareAfisata;
        public string DataReturnareAfisata
        {
            get
            {
                if (dataReturnare == DateTime.MinValue)
                {
                    return string.Empty; 
                }
                _dataReturnareAfisata= dataReturnare.ToString("dd.MM.yyyy"); 
                return _dataReturnareAfisata;
            }
            set
            {
                _dataReturnareAfisata = value;
                OnPropertyChanged(nameof(DataReturnareAfisata));
            }
        }
        public DateTime DataLimita
        {
            get => dataLimita;
            set
            {
                dataLimita = value;
                OnPropertyChanged(nameof(DataLimita));
            }
        }

        public ImprumutModel() { }

        public void finalizareImprumut()
        {
            this.DataReturnare = DateTime.Now;
            this.DataReturnareAfisata = dataReturnare.ToString("dd.MM.yyyy");
            this.Stare = "Finalizat";
            this.IsImprumutActiv = false;
        }

        public bool updateTermenLimita(DateTime newDate)
        {
            var db = new BibliotecaElectronicaClassesDataContext();
            var imprumut = db.Imprumuts.Where(i => i.ID == this.idImprumut).FirstOrDefault();
            if(imprumut!=null)
            {
               
                imprumut.TermenLimita=newDate;
                try
                {
                    db.SubmitChanges();
                    this.DataLimita = newDate;
                    return true;
                }
                catch (Exception e)
                {
                    throw new DataBaseException();
                }
            }
            return false;
        }
        
        public static  ImprumutModel getImprumuturi(int ID_imprumut)
        {
            var db = new BibliotecaElectronicaClassesDataContext();
            var imprumut = db.Imprumuts.Where(i => i.ID==ID_imprumut).FirstOrDefault();
            if (imprumut != null)
            {
                ImprumutModel imprumutModel = new ImprumutModel()
                {
                    idImprumut = imprumut.ID,
                    idCititor = imprumut.ID_Cititor.GetValueOrDefault(),
                    idCarte = imprumut.ID_Carte.GetValueOrDefault(),
                    dataImprumut = imprumut.DataImprumut,
                    dataLimita = imprumut.TermenLimita,
                    dataReturnare = imprumut.DataReturnare.GetValueOrDefault(),
                    stare = imprumut.Stare
                   
                };
                if (imprumutModel.stare == "Activ")
                    imprumutModel.isImprumutActiv = true;
                else
                    imprumutModel.isImprumutActiv = false;
                return imprumutModel;

            }
            return null;
        }

        public static bool adaugaImprumut(CarteModel carte,PersoanaModel persoana)
        {
            var db = new BibliotecaElectronicaClassesDataContext();

            int idCititor = db.Cititors.Where(c => c.ID_Persoana == persoana.IdPerson).FirstOrDefault().ID;

            ImprumutModel imprumut = new ImprumutModel();
            imprumut.dataImprumut = DateTime.Now;
            imprumut.dataLimita = imprumut.dataImprumut.AddDays(21);
            imprumut.idCititor = idCititor;
            imprumut.idCarte = carte.IdBook;
            imprumut.stare = "Activ";
            Imprumut imprumut1 = new Imprumut()
            {
                DataImprumut = imprumut.DataImprumut,
                TermenLimita = imprumut.dataLimita,
                ID_Carte = imprumut.idCarte,
                ID_Cititor = imprumut.idCititor,
                Stare = imprumut.stare
            };
            carte.NrExemplare--;
            db.Imprumuts.InsertOnSubmit(imprumut1);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new DataBaseException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}