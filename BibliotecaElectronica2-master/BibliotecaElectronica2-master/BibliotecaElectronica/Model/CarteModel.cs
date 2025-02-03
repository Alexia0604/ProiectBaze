using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BibliotecaElectronica.Model
{
    public class CarteModel : INotifyPropertyChanged
    {
        public int idBook;
        public string title;
        public string author;
        public int year;
        public string isbn;
        public int idCategory;
        public byte[] image;
        private string description;
        private ObservableCollection<RecenzieModel> recenzii;
        private int nrPagini;
        private string dimensiune;
        private string editura;
        private int nrExemplare;
        private string categorie;
        public double nota;
      
        public int NrExemplare
        {
            get => nrExemplare;
            set
            {
                nrExemplare = value;
                OnPropertyChanged(nameof(NrExemplare));
            }
        }

        public double Nota
        {
            get => nota;
            set
            {
                nota = value;
                OnPropertyChanged(nameof(Nota));
            }
        }
        public int IdBook
        {
            get => idBook;
            set => idBook = value;
        }
         public int NrPagini
        {
            get { return nrPagini; }
            set { nrPagini = value; }
        }

        public string Dimensiune
        {
            get { return dimensiune; }
            set => dimensiune = value;
        }
         public string Editura
        {
            get { return editura; }
            set {  editura = value; }
        }


        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        public string Isbn
        {
            get => isbn;
            set => isbn = value;
        }

        public int IdCategory
        {
            get => idCategory;
            set => idCategory = value;
        }

        public byte[] Image
        {
            get => image;
            set
            {
                image = value;
                BitmapImage = ConvertToBitmapImage(value);
            }
        }

        public string Categorie
        {
            get { return categorie; }
            set => categorie = value;
        }

        public BitmapImage BitmapImage { get; private set; }

        private BitmapImage ConvertToBitmapImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            using (var stream = new MemoryStream(imageData))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                bitmap.Freeze();
                return bitmap;
            }
        }

        public bool returneazaCarteCititor(int idimprumut)
        {
            var db = new BibliotecaElectronicaEntities3();
            var imprumut=db.Imprumuts.Where(i=>i.ID== idimprumut).FirstOrDefault();
            if(imprumut!=null)
            {
                imprumut.Stare = "Returnare în așteptare";
                imprumut.DataCerereReturnare = DateTime.Now;
                try
                {
                    db.SaveChanges();
                   // this.NrExemplare++;
                    return true;
                }
                catch (Exception e)
                {
                    throw new DataBaseException();
                }
            }
            return false;
        }

        public bool aprobaReturnareCarte(int idimprumut)
        {
            var db = new BibliotecaElectronicaEntities3();
            var imprumut = db.Imprumuts.Where(i => i.ID == idimprumut).FirstOrDefault();
            if (imprumut != null)
            {
                imprumut.Stare = "Finalizat";
               // imprumut.IsButtonVisible = false;
                imprumut.DataReturnare = DateTime.Now;
                try
                {
                    db.SaveChanges();
                    this.NrExemplare++;
                    return true;
                }
                catch (Exception e)
                {
                    throw new DataBaseException();
                }
            }
            return false;
        }

        public bool respingeReturnareCarte(int idimprumut)
        {
            var db = new BibliotecaElectronicaEntities3();   
            var imprumut = db.Imprumuts.Where(i => i.ID == idimprumut).FirstOrDefault();
            if (imprumut != null)
            {
                imprumut.Stare = "Activ";
             //   imprumut.DataReturnare = null;
                try
                {
                    db.SaveChanges();
                   // this.NrExemplare++;
                    return true;
                }
                catch (Exception e)
                {
                    throw new DataBaseException();
                }
            }
            return false;
        }

        public ObservableCollection<RatingDistributionItem> getRatingDistributions()
        {
            var db = new            BibliotecaElectronicaEntities3();
            ObservableCollection<RatingDistributionItem> ratings = new ObservableCollection<RatingDistributionItem>
                        {
                            new RatingDistributionItem { Key = 5, Value = db.Recenzies.Where(r=>r.ID_Carte==this.IdBook && r.Nota==5).Count() },
                            new RatingDistributionItem { Key = 4, Value =  db.Recenzies.Where(r=>r.ID_Carte==this.IdBook && r.Nota==4).Count() },
                            new RatingDistributionItem { Key = 3, Value =  db.Recenzies.Where(r=>r.ID_Carte == this.IdBook && r.Nota == 3).Count() },
                            new RatingDistributionItem { Key = 2, Value =  db.Recenzies.Where(r=>r.ID_Carte == this.IdBook && r.Nota == 2).Count() },
                            new RatingDistributionItem { Key = 1, Value =  db.Recenzies.Where(r=>r.ID_Carte == this.IdBook && r.Nota == 1).Count() }
                        };
            return ratings;
        }
        public CarteModel(int _idBook, string _title, string _author, int _year, string _isbn, int _idCategory, byte[] _image)
        {
            idBook = _idBook;
            title = _title;
            author = _author;
            year = _year;
            isbn = _isbn;
            idCategory = _idCategory;
            image = _image;
        }

        public CarteModel(string _title, string _author, byte[] _image)
        {
            title = _title;
            author = _author;
            image=_image;
        }

        public CarteModel() { }

        public static ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> getCartiReturnate()
        {
            var db = new BibliotecaElectronicaEntities3();
            var imprumuturi_db = db.Imprumuts.Where(i => i.Stare == "Returnare în așteptare").ToList();

            var books = new List<Carte>();
            List<ImprumutModel> imprumuturi = new List<ImprumutModel>();
            foreach (var item in imprumuturi_db)
            {
                var book = db.Cartes.FirstOrDefault(b => b.ID == item.ID_Carte);
                if (book != null)
                {
                    ImprumutModel imprumut = ImprumutModel.getImprumuturi(item.ID);
                    imprumuturi.Add(imprumut);
                    books.Add(book);
                }
            }

            var allBooks = new List<CarteModel>(books.Select(c => new CarteModel
            {
                Title = c.Titlu,
                Author = c.Autor,
                Image = c.Imagine.ToArray()
            }));

            ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> cartiReturnate = new ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>>();
            for (int i = 0; i < allBooks.Count; i++)
            {
                cartiReturnate.Add(new KeyValuePair<CarteModel, ImprumutModel>(allBooks[i], imprumuturi[i]));
            }

            return cartiReturnate;
        }

        public static ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> getCartiDeReturnatAstazi()
        {
            var db = new BibliotecaElectronicaEntities3();
            var imprumuturi_db = db.Imprumuts.Where(i => i.Stare == "Activ" && i.TermenLimita==DateTime.Today).ToList();

            var books = new List<Carte>();
            List<ImprumutModel> imprumuturi = new List<ImprumutModel>();
            foreach (var item in imprumuturi_db)
            {
                var book = db.Cartes.FirstOrDefault(b => b.ID == item.ID_Carte);
                if (book != null)
                {
                    ImprumutModel imprumut = ImprumutModel.getImprumuturi(item.ID);
                    imprumuturi.Add(imprumut);
                    books.Add(book);
                }
            }

            var allBooks = new List<CarteModel>(books.Select(c => new CarteModel
            {
                Title = c.Titlu,
                Author = c.Autor,
                Image = c.Imagine.ToArray()
            }));

            ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>> cartiReturnate = new ObservableCollection<KeyValuePair<CarteModel, ImprumutModel>>();
            for (int i = 0; i < allBooks.Count; i++)
            {
                cartiReturnate.Add(new KeyValuePair<CarteModel, ImprumutModel>(allBooks[i], imprumuturi[i]));
            }

            return cartiReturnate;
        }
        public static  Dictionary<CarteModel,ImprumutModel> getCartiImprumutate(int userID)
        {
            var db = new BibliotecaElectronicaEntities3();
            int cititorID=db.Cititors.Where(c=>c.ID_Persoana==userID).FirstOrDefault().ID;
        

            var imprumuturi_db = db.Imprumuts.Where(i => i.ID_Cititor ==cititorID).ToList();
            var books = new List<Carte>();
            List<ImprumutModel> imprumuturi= new List<ImprumutModel>();
            foreach (var item in imprumuturi_db)
            {
                var book = db.Cartes.FirstOrDefault(b => b.ID == item.ID_Carte);
                if (book != null)
                {
                    ImprumutModel imprumut = ImprumutModel.getImprumuturi(item.ID);
                    imprumuturi.Add(imprumut);
                    books.Add(book);
                }
            }

            var allBooks = new List<CarteModel>(books.Select(c => new CarteModel
            {
                Title = c.Titlu,
                Author = c.Autor,
                Image = c.Imagine.ToArray() }));

            Dictionary<CarteModel, ImprumutModel> cartiImprumutate = new Dictionary<CarteModel, ImprumutModel>();
            for(int i =0;i< allBooks.Count;i++)
            {
                cartiImprumutate.Add(allBooks[i], imprumuturi[i]);
            }
                
            return cartiImprumutate;
        }

        public static ObservableCollection<CarteModel>  LoadAllBooks()
        {
            var db = new BibliotecaElectronicaEntities3();
            var allBooksData =db.Cartes
                                .Select(c => new
                                {
                                    Dimensiune=c.Dimensiune,
                                    Editura=c.Editura,
                                    NrPagini=c.NumarPagini,
                                    ISBn=c.ISBN,
                                    ID=c.ID,
                                    Titlu = c.Titlu,
                                    Autor = c.Autor,
                                    Descriere=c.Descriere,
                                    Imagine = c.Imagine
                                }).ToList();

            var allBooks = allBooksData.Select(c => new CarteModel
            {
                Title = c.Titlu,
                Author = c.Autor,
                Image = c.Imagine,
                Description=c.Descriere,
                idBook=c.ID,
                Isbn=c.ISBn,
                NrPagini=c.NrPagini.GetValueOrDefault(),
                Dimensiune=c.Dimensiune,
                Editura=c.Editura
               
            }).ToList();
             ObservableCollection<CarteModel> carti=new ObservableCollection<CarteModel>();
            foreach(var carte in allBooks)
            {
                carte.getNrExemplare();
                carti.Add(carte);
            }
            return carti;
        }
        public string getDataImprumut()
        {
            var db = new BibliotecaElectronicaEntities3();
            var dataImprumut = db.Imprumuts.Where(i => i.ID_Carte == this.IdBook).FirstOrDefault().DataImprumut;
            return dataImprumut.ToString();
        }
        public ObservableCollection<RecenzieModel> populeazaRecenziile()
        {
            this.recenzii=RecenzieModel.getAllRewies(this.IdBook);

            return this.recenzii;
        }

        public int getNrRecenzii()
        {
            return this.recenzii.Count;
        }

        private void getNrExemplare()
        {
            var db = new BibliotecaElectronicaEntities3();
            int nr=db.Stocs.Where(s=>s.ID_Carte==this.IdBook).FirstOrDefault().NrExemplare;
            this.nrExemplare = nr;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool AddCarte(string title, string author, int year, string isbn, string categorie, byte[] image, string description, int nrPagini, string dimensiune, string editura, int nrExemplare)
        {
            var db = new BibliotecaElectronicaEntities3();
            try
            {
                if (IsIsbnExists(isbn))
                {
                    MessageBox.Show("O carte cu acest ISBN există deja în baza de date.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false; 
                }

                var newCarte = new Carte
                {
                    Titlu = title,
                    Autor = author,
                    AnPublicare = year,
                    ISBN = isbn,
                    Categorie = categorie,
                    Imagine = image,
                    Descriere = description,
                    NumarPagini = nrPagini,
                    Dimensiune = dimensiune,
                    Editura = editura
                };

              
                db.Cartes.Add(newCarte);
                db.SaveChanges();

            
                var newStoc = new Stoc
                {
                    ID_Carte = newCarte.ID,
                    NrExemplare = nrExemplare
                };

                db.Stocs.Add(newStoc);
                db.SaveChanges();

                return true; 
            }
            catch (Exception ex)
            {
                throw new DataBaseException("Eroare la adăugarea cărții în baza de date.", ex);
            }
        }

        public static ObservableCollection<CarteModel> LoadTopRatedBooks()
        {
            var db = new BibliotecaElectronicaEntities3();
            db.Database.ExecuteSqlCommand("exec ActualizeazaMediaNotelor");

            var topBooksData = db.Cartes
                .Select(c => new
                {
                    Carte = c,
                    Nota = c.Nota
                })
                .OrderByDescending(c => c.Nota)
                .Take(3)
                .ToList();


            var topBooks = new ObservableCollection<CarteModel>(
                topBooksData.Select(c => new CarteModel
                {
                    Title = c.Carte.Titlu,
                    Author = c.Carte.Autor,
                    Image = c.Carte.Imagine.ToArray(),
                    Description = c.Carte.Descriere,
                    idBook = c.Carte.ID,
                    Isbn = c.Carte.ISBN,
                    NrPagini = c.Carte.NumarPagini.GetValueOrDefault(),
                    Dimensiune = c.Carte.Dimensiune,
                    Editura = c.Carte.Editura,
                    Nota=c.Nota
                })
            );


            return topBooks;
        }

        public static ObservableCollection<CarteModel> LoadTopBooks()
        {
            var db = new BibliotecaElectronicaEntities3();

         
            var topBooksData = db.Cartes
                .Select(c => new
                {
                    Carte = c,
                    NrImprumuturi = c.Imprumuts.Count() 
                })
                .OrderByDescending(c => c.NrImprumuturi) 
                .Take(3)
                .ToList();

            
            var topBooks = new ObservableCollection<CarteModel>(
                topBooksData.Select(c => new CarteModel
                {
                    Title = c.Carte.Titlu,
                    Author = c.Carte.Autor,
                    Image = c.Carte.Imagine.ToArray(),
                    Description = c.Carte.Descriere,
                    idBook = c.Carte.ID,
                    Isbn = c.Carte.ISBN,
                    NrPagini = c.Carte.NumarPagini.GetValueOrDefault(),
                    Dimensiune = c.Carte.Dimensiune,
                    Editura = c.Carte.Editura
                })
            );

         
            return topBooks;
        }

        public bool IsIsbnExists(string isbn)   
        {
            var db = new BibliotecaElectronicaEntities3();

            return db.Cartes.Any(c => c.ISBN == isbn);
        }

    }
}
