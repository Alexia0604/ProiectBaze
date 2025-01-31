using BibliotecaElectronica.Exceptions;
using BibliotecaElectronica.Model;
using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Commands
{
    public class SubmitReviewCommand : CommandBase
    {
        DetaliiCarteViewModel viewModel;
        public SubmitReviewCommand(DetaliiCarteViewModel _viewModel)
        {
            viewModel = _viewModel;
        }

        public override void Execute(object parameter)
        {
            RecenzieModel recenzie = new RecenzieModel(viewModel._clientViewModel.Persoana.getClientID(), viewModel.SelectedBook.idBook, viewModel.SelectedStars, viewModel.NewReview);
            try
            {
                recenzie.addNewReview();
                viewModel.IsPopupOpen = false;
                MessageBox.Show($"Recenzie adăugată cu succes! Vă mulțumim!","Succes!", MessageBoxButton.OK,MessageBoxImage.Information);
            }
             catch (DataBaseException e)
            {
                MessageBox.Show($"Vă rugăm să încercați mai târziu!", "Error", MessageBoxButton.OKCancel,MessageBoxImage.Error);
            }
        }
    }
}
