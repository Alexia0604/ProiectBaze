using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BibliotecaElectronica
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {

        public RegisterWindow(Window parentWindow)
        {
           // DataContext = this;
            Owner=parentWindow;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
                 var db = new BibliotecaElectronicaClassesDataContext();
                Cititor cititor = new Cititor();
                cititor.Persoana = new Persoana();
                cititor.Persoana.Nume=tbNume.txtInput.Text;
                cititor.Persoana.Prenume=tbPrenume.txtInput.Text;
                cititor.Persoana.Adresa=TbAdresa.txtInput.Text;
                cititor.Persoana.Telefon=tbTelefon.txtInput.Text;
                cititor.Persoana.Email=tbEmail.txtInput.Text;
                RegisterWindow2 registerWindow2 = new RegisterWindow2(this, db,cititor);
                this.Hide();
                registerWindow2.Show();
        }
    }
}
