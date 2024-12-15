using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace BibliotecaElectronica.Model
{
    public class CarteModel
    {
        public int idBook;
        public string title;
        public string author;
        public int year;
        public string isbn;
        public int idCategory;
        public byte[] image;

        public int IdBook
        {
            get => idBook;
            set => idBook = value;
        }

        public string Title
        {
            get => title;
            set => title = value;
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
                bitmap.Freeze(); // Important pentru a evita problemele cu threading-ul în WPF
                return bitmap;
            }
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
    }
}
