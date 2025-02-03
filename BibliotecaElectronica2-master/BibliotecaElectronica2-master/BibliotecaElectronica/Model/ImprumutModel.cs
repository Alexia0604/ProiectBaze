using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.ViewModel;
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
        private DateTime dataCerereReturnare;
        private string stare;
        private string cititor;

        public DateTime DataCerereReturnare
        {
            get => dataCerereReturnare;
            set
            {
                dataCerereReturnare = value;
                OnPropertyChanged(nameof(DataCerereReturnare));
            }
        }
        public int IDCititor
        {
            get => idCititor;
            set
            {
                idCititor = value;
                OnPropertyChanged(nameof(IDCititor));
            }
        }

        public string Cititor
        {
            get => cititor;
            set
            {
                cititor = value;
                OnPropertyChanged(nameof(Cititor));
            }
        }

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

        private bool _isButtonVisible = true;
        public bool IsButtonVisible
        {
            get { return _isButtonVisible; }
            set
            {
                _isButtonVisible = value;
                OnPropertyChanged(nameof(IsButtonVisible)); 
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

        private string _dataCerereReturnareAfisata;
        public string DataCerereReturnareAfisata
        {
            get
            {
                if (dataCerereReturnare == DateTime.MinValue)
                {
                    return string.Empty;
                }
                _dataCerereReturnareAfisata = dataCerereReturnare.ToString("dd.MM.yyyy");

                return _dataCerereReturnareAfisata;
            }
            set
            {
                _dataCerereReturnareAfisata = value;
                OnPropertyChanged(nameof(DataCerereReturnareAfisata));
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
           // this.DataReturnare = DateTime.Now;
          //  this.DataReturnareAfisata = dataReturnare.ToString();
            this.dataCerereReturnare= DateTime.Now;
            this.Stare = "Returnare în așteptare";
            this.IsImprumutActiv = false;
        }
       
        public void respingereFinalizareImprumut()
        {
         //   this.DataReturnare =null;
          //  this.DataReturnareAfisata = string.Empty;
          this.IsButtonVisible = false;
            this.Stare = "Activ";
            this.IsImprumutActiv = true;
        }
        public void finalizareImprumutByBibliotecar()
        {
            this.DataReturnare = DateTime.Now;
            this.DataReturnareAfisata = dataReturnare.ToString("dd.MM.yyyy");
            this.Stare = "Finalizat";
            this.IsButtonVisible = false;
            this.IsImprumutActiv = false;
        }
        public bool updateTermenLimita(DateTime newDate)
        {
            var db = new BibliotecaElectronicaEntities3();
            var imprumut = db.Imprumuts.Where(i => i.ID == this.idImprumut).FirstOrDefault();
            if(imprumut!=null)
            {
               
                imprumut.TermenLimita=newDate;
                try
                {
                    db.SaveChanges();
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
            var db = new BibliotecaElectronicaEntities3();
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
                    stare = imprumut.Stare,
                    dataCerereReturnare=imprumut.DataCerereReturnare.GetValueOrDefault()
                   
                };
                var numeCititor = db.Cititors.Where(c => c.ID == imprumutModel.idCititor).FirstOrDefault().Persoana.Nume;
                var prenumeCititor = db.Cititors.Where(c => c.ID == imprumutModel.idCititor).FirstOrDefault().Persoana.Prenume;
                if (numeCititor != null)
                    imprumutModel.Cititor=numeCititor+" "+prenumeCititor;
                if (imprumutModel.stare == "Activ")
                    imprumutModel.isImprumutActiv = true;
                else
                    imprumutModel.isImprumutActiv = false;
                return imprumutModel;

            }
            return null;
        }

        public static bool verificaImprumut(int idBook, int IdPerson)
        {
            var db = new BibliotecaElectronicaEntities3();
            int id_cititor = db.Cititors.Where(c=>c.ID_Persoana==IdPerson).FirstOrDefault().ID;
            return db.Imprumuts.Any(i => i.ID_Carte == idBook && i.ID_Cititor == id_cititor && i.Stare=="Activ");
        }
        public static bool adaugaImprumut(CarteModel carte,PersoanaModel persoana)
        {
            var db = new BibliotecaElectronicaEntities3();

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
            db.Imprumuts.Add(imprumut1);
            try
            {
                db.SaveChanges();
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
