using BibliotecaElectronica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BibliotecaElectronica.Commands
{
    public class AddBooksClickButtonCommand : CommandBase
    {
        private readonly LibrarianViewModel _librarianViewModel;

        public AddBooksClickButtonCommand(LibrarianViewModel librarianViewMode)
        {
            _librarianViewModel = librarianViewMode;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _librarianViewModel.CurrentRightViewModel = new AddBooksViewModel(_librarianViewModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la deschiderea formularului de adăugare cărți: {ex.Message}",
                              "Eroare",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}