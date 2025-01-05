using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.Stores;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Commands
{
    public class BorrowBookCommand : CommandBase
    {
        private CarteModel _carte;
        private PersoanaModel _persoana;    
        public BorrowBookCommand(CarteModel carte, PersoanaModel persoana)
        {
            _carte = carte;
            _persoana = persoana;
        }

        public override void Execute(object parameter)
        {
            try
            {
                ImprumutModel.adaugaImprumut(_carte, _persoana);
                MessageBox.Show("Carte împrumutată cu succes!\nTe așteptăm să o ridici!", "Mesaj împrumut", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(DataBaseException e)
            {
                MessageBox.Show("Împrumut eșuat!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
