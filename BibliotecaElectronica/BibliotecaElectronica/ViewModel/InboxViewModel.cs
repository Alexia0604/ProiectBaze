using BibliotecaElectronica.Model;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;

namespace BibliotecaElectronica.ViewModel
{
    public class InboxViewModel : ViewModelBase
    {
        private PersoanaModel _persoana;

        private ObservableCollection<NotificareModel> notificari;

        public ObservableCollection<NotificareModel> Notificari
        {
            get { return notificari; }
            set { notificari = value; OnPropertyChanged(nameof(Notificari)); }
        }

        private NotificareModel _notificareSelectata;
        public NotificareModel NotificareSelectata
        {
            get => _notificareSelectata;
            set
            {
                _notificareSelectata = value;
                OnPropertyChanged(nameof(NotificareSelectata));
                if(_notificareSelectata != null)
                {
                    _notificareSelectata.IsPopupOpen = true;
                }
            }
        }
       
        public ICommand ClosePopupCommand { get; }
        public InboxViewModel(PersoanaModel persoana)
        {
            _persoana = persoana;
            
            Notificari = NotificareModel.getNotifications(persoana.IdPerson);
            ClosePopupCommand = new RelayCommand(ClosePopup);

        }
        private void ClosePopup()
        {
            if (NotificareSelectata != null)
            {
                NotificareSelectata.schimbaStareNotificare();
                if(_persoana.NrNotificariNecitite>0)
                        _persoana.NrNotificariNecitite--;
                
            }
        }
    }
}
