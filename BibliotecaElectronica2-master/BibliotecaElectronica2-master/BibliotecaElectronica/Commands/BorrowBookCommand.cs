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
        private readonly Action _onBorrowSuccess;
        public BorrowBookCommand(CarteModel carte, PersoanaModel persoana, Action onBorrowSuccess)
        {
            _carte = carte;
            _persoana = persoana;
            _onBorrowSuccess = onBorrowSuccess;
        }

        public override void Execute(object parameter)
        {
            try
            {
                ImprumutModel.adaugaImprumut(_carte, _persoana);
                _onBorrowSuccess?.Invoke();
                MessageBox.Show("Carte împrumutată cu succes!\nTe așteptăm să o ridici!", "Mesaj împrumut", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch(DataBaseException e)
            {
                MessageBox.Show("Împrumut eșuat!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
