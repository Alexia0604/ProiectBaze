using BibliotecaElectronica.Exceptions;
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
    public class RecenzieModel : INotifyPropertyChanged
    {
        private int ID;
        private int IdCititor;
        private int IdCarte;
        private int nota;
        private string cometariu;
        private DateTime dataComentariu;
        private string numeUtilizator;
        private int like;
        private int dislike;

        public IEnumerable<bool> StarsArray
        {
            get
            {
                return Enumerable.Range(1, 5).Select(i => i <= Nota);
            }
        }

        public int Nota
        {
            set { nota = value;
            OnPropertyChanged(nameof(Nota));}
            get { return nota; }
        }
        public int Like
        {
            set { this.like = value;
                OnPropertyChanged(nameof(Like));
            }
            get { return this.like; }
        }

        public int Dislike
        {
            set { this.dislike = value;
                OnPropertyChanged(nameof(Dislike));
            }
            get { return this.dislike; }
        }

        public string Comentariu
        {
            get { return cometariu; }
            set { cometariu = value; }
        }

        public string NumeUtilizator
        {
            get { return numeUtilizator;}
            set { numeUtilizator = value;}
        }
        public RecenzieModel() { }
        public RecenzieModel(int idCititor, int idCarte, int nota, string cometariu)
        {

            IdCititor = idCititor;
            IdCarte = idCarte;
            this.nota = nota;
            this.cometariu = cometariu;
            this.dataComentariu = DateTime.Now;
        }

        public static ObservableCollection<RecenzieModel> getAllRewies(int idBook)
        {
            var db = new BibliotecaElectronicaEntities3();
            var recenzii_db=db.Recenzies.Where(r=>r.ID_Carte==idBook).ToList();

            ObservableCollection<RecenzieModel> recenzii=new ObservableCollection<RecenzieModel>();
           

            foreach(var item in  recenzii_db)
            {
             
                var recenzie = new RecenzieModel()
                {
                    ID = item.ID,
                    IdCarte = item.ID_Carte.GetValueOrDefault(),
                    IdCititor = item.ID_Cititor.GetValueOrDefault(),
                    nota = item.Nota.GetValueOrDefault(),
                    cometariu = item.Comentariu,
                    dataComentariu = item.DataRecenzie
                };
                recenzie.Like = db.Feedbacks.Where(f => f.ID_Recenzie == recenzie.ID).FirstOrDefault().NrLike;
                recenzie.Dislike = db.Feedbacks.Where(f => f.ID_Recenzie == recenzie.ID).FirstOrDefault().NrDislike;
                recenzie.getNameUser();
                recenzii.Add(recenzie);
            }
            return recenzii;
        }

        public bool addNewReview()
        {
            var db = new BibliotecaElectronicaEntities3();
            Recenzie recenzie = new Recenzie()
            {
                ID_Cititor = this.IdCititor,
                ID_Carte = this.IdCarte,
                Nota = this.Nota,
                Comentariu = this.Comentariu,
                DataRecenzie = this.dataComentariu
            };
            db.Recenzies.Add(recenzie);
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
        public void getNameUser()
        {
            var db = new BibliotecaElectronicaEntities3();
            var user=db.Cititors.Where(c=>c.ID==this.IdCititor).First();
            string userLastName = db.Persoanas.Where(p => p.ID == user.ID_Persoana).First().Nume;
            string userFirstName = db.Persoanas.Where(p => p.ID == user.ID_Persoana).First().Prenume;
            this.NumeUtilizator = userFirstName + " " + userLastName;
        }

        public bool addLike()
        {
            var db = new BibliotecaElectronicaEntities3();
            var feedback = db.Feedbacks.Where(f => f.ID_Recenzie == this.ID).FirstOrDefault();
            feedback.NrLike++;
            Like++;
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

        public bool decrementLike()
        {
            var db = new BibliotecaElectronicaEntities3();
            var feedback = db.Feedbacks.Where(f => f.ID_Recenzie == this.ID).FirstOrDefault();
            feedback.NrLike--;
            Like--;
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

        public bool addDislike()
        {
            var db = new BibliotecaElectronicaEntities3();
            var feedback = db.Feedbacks.Where(f => f.ID_Recenzie == this.ID).FirstOrDefault();
            feedback.NrDislike++;
            Dislike++;
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
        public bool decrementDislike()
        {
            var db = new BibliotecaElectronicaEntities3();
            var feedback = db.Feedbacks.Where(f => f.ID_Recenzie == this.ID).FirstOrDefault();
            feedback.NrDislike--;
            Dislike--;
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
