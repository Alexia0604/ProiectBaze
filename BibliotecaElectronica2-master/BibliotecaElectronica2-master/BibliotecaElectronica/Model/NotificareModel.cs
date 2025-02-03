using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Model
{
    public class NotificareModel : INotifyPropertyChanged
    {
        int id;
        int id_Cititor;
        string tip_notificare;
        string mesaj;
        DateTime dataTrimitere;
        string stare;

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
        public int ID
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public int ID_Cititor
        {
            get { return id_Cititor; }
            set { id_Cititor = value;
                OnPropertyChanged(nameof(ID_Cititor));
            }
        }

        public string Tip_Notificare
        {
            get { return tip_notificare; }
            set { tip_notificare = value;
                OnPropertyChanged(nameof(Tip_Notificare));
            }
        }

        public string Mesaj
        {
            get { return mesaj; }
            set { mesaj = value;
                OnPropertyChanged(nameof(Mesaj));
            }
        }

        public DateTime DataTrimitere
        {
            get { return dataTrimitere; }
            set { dataTrimitere = value;
                OnPropertyChanged(nameof(DataTrimitere));
            }
        }

        public string Stare
        {
            get { return stare; }
            set { stare = value;
                OnPropertyChanged(nameof(Stare));
            }
        }

        string _dataTrimitereAfisata;
        public string DataTrimitereAfisata
        {
            get
            {
                if (dataTrimitere == DateTime.MinValue)
                {
                    return string.Empty;
                }
                _dataTrimitereAfisata = dataTrimitere.ToString("dd.MM.yyyy HH:mm");
                return _dataTrimitereAfisata;
            }
            set
            {
                _dataTrimitereAfisata = value;
                OnPropertyChanged(nameof(DataTrimitereAfisata));
            }
            
        }

        public NotificareModel() {  }

        public void schimbaStareNotificare()
        {
            this.Stare = "Citit";
            this.IsPopupOpen = false;
            var db = new BibliotecaElectronicaEntities3();
            var notificare = db.Notificares.Where(n => n.ID == this.ID).FirstOrDefault();
            notificare.Stare = "Citit";
            db.SaveChanges();
        }

        public static int getNrMesajeNecitite(int userID)
        {
            var db = new BibliotecaElectronicaEntities3();

            var bibliotecar = db.Bibliotecars.FirstOrDefault(b => b.ID_Persoana == userID);

            if (bibliotecar != null)
            {
                
                int numar= db.Imprumuts.Count(i => i.Stare == "Returnare în așteptare");
                
                return numar;
            }

            int cititorID = db.Cititors.Where(c => c.ID_Persoana == userID).FirstOrDefault().ID;

            var notificari = db.Notificares.Where(n => n.ID_Cititor == cititorID && n.Stare=="Necitit").ToList();

            int nrNotificari=notificari.Count();
            
            return nrNotificari;
        }
        public static ObservableCollection<NotificareModel> getNotifications(int userID)
        {
            var db = new BibliotecaElectronicaEntities3();

            int cititorID = db.Cititors.Where(c => c.ID_Persoana == userID).FirstOrDefault().ID;

            var notificari = db.Notificares.Where(n => n.ID_Cititor == cititorID).ToList();

            var allNotificari = new ObservableCollection<NotificareModel>(notificari.Select(c => new NotificareModel
            {
                ID=c.ID,
                ID_Cititor=c.ID_Cititor.GetValueOrDefault(),
                Mesaj=c.Mesaj,
                Tip_Notificare=c.Tip_Notificare,
                DataTrimitere=c.DataTrimitere,
                Stare=c.Stare

            }));
            
            return allNotificari;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
