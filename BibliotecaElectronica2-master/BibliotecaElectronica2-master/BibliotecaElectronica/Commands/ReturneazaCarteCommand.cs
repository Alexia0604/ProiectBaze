using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Commands
{
    public class ReturneazaCarteCommand : CommandBase
    {
        private CarteModel _Carte;
        private ImprumutModel _imprumut;
        public ReturneazaCarteCommand(CarteModel carte, ImprumutModel imprumut)
        {
            _Carte = carte;
            _imprumut = imprumut;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _Carte.returneazaCarteCititor(_imprumut.IDImprumut);
                MessageBox.Show($"Carte returnată! Vă mulțumim!", "Succes!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(DataBaseException e)
            {
                MessageBox.Show($"S-a întâmpinat o problemă! Vă rugăm să încercați mai târziu!", "Eroare", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

       
    }
}
