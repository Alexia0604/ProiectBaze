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
    public partial class RegisterWindow2 : Window
    {
        private Cititor cititor1;
        private BibliotecaElectronicaClassesDataContext context;

        public RegisterWindow2(Window parentWindow, BibliotecaElectronicaClassesDataContext db, Cititor cititor)
        {
            Owner = parentWindow;
            InitializeComponent();
            cititor1 = cititor;
            context = db;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            cititor1.Persoana.Parola = tbPassword.txtInput.Text;
            cititor1.Persoana.Username=tbUsername.txtInput.Text;
            cititor1.DataInregistrare=DateTime.Now;
            
            context.Persoanas.InsertOnSubmit(cititor1.Persoana); 
            context.Cititors.InsertOnSubmit(cititor1);
            context.SubmitChanges();

            MessageBoxResult result = MessageBox.Show("Te-ai înregistrat cu succes!", "Mesaj înregistrare", MessageBoxButton.OK, MessageBoxImage.Information);
            if(result==MessageBoxResult.OK)
            {
                Owner.Owner.Show();
                this.Close();
            }
        }
    }
}
