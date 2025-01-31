using BibliotecaElectronica.Exceptions;
using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Utilities
{
    public class NotificariBackgroundWorker
    {
        private Timer _timer;
        private readonly TimeSpan _interval = TimeSpan.FromHours(24);
        private BibliotecaElectronicaClassesDataContext db;

        private static readonly Lazy<NotificariBackgroundWorker> _instance =
         new Lazy<NotificariBackgroundWorker>(() => new NotificariBackgroundWorker());

        public static NotificariBackgroundWorker Instance => _instance.Value;

        private NotificariBackgroundWorker() { }

        private static readonly object _lock = new object();

        private void VerificaNotificari(object state)
        {
            lock (_lock)
            {
                try
                {
                        var db = new BibliotecaElectronicaClassesDataContext();
                        var returnariIntarziate = (from imprumut in db.Imprumuts
                                                   join cititor in db.Cititors on imprumut.ID_Cititor equals cititor.ID
                                                   where imprumut.DataReturnare == null && imprumut.TermenLimita < DateTime.Now
                                                   select new
                                                   {
                                                       Imprumut = imprumut,
                                                       Cititor = cititor
                                                   }).ToList();


                        foreach (var item in returnariIntarziate)
                        {
                            var carte = db.Cartes.Where(c => c.ID == item.Imprumut.ID_Carte).FirstOrDefault();
                            var notificare = new Notificare
                            {
                                ID_Cititor = item.Imprumut.ID_Cititor,
                                Tip_Notificare = "Returnare intarziata",
                                Mesaj = $"Ați întârziat cu returnarea cărții  {carte.Titlu}, de {carte.Autor}. Vă rugăm să o returnați cât mai curând!",
                                DataTrimitere = DateTime.Now,
                                Stare = "Necitit"
                            };

                            db.Notificares.InsertOnSubmit(notificare);

                        }

                        UpdateLastRunTime();
                        db.SubmitChanges();
                    
                   
                }
                catch (Exception ex)
                {
                    throw new DataBaseException();
                }
            }
        }


        public void Start()
        {
            if (_timer != null)
                return;
            db = new BibliotecaElectronicaClassesDataContext();
            var lastRunTime = GetLastRunTime();
            var elapsed = DateTime.Now - lastRunTime;

            if (lastRunTime == DateTime.MinValue)
            {
                VerificaNotificari(null);
            }

            var initialDelay = elapsed >= _interval ? TimeSpan.Zero : _interval - elapsed;

          //  _timer = new Timer(VerificaNotificari, null, initialDelay, _interval);
        }

        private DateTime GetLastRunTime()
        {
           
            var taskLog = db.TaskLogs.FirstOrDefault(t => t.TaskName == "Verificare Returnari");
            if(taskLog==null)
            {
                taskLog = new TaskLog
                {
                    TaskName = "Verificare Returnari",
                    LastRunTime = DateTime.Now
                };
                db.TaskLogs.InsertOnSubmit(taskLog);
                db.SubmitChanges();
                return DateTime.MinValue;

            }
            return taskLog.LastRunTime;
        }

        private void UpdateLastRunTime()
        {
            var taskLog = db.TaskLogs.FirstOrDefault(t => t.TaskName == "Verificare Returnari");
            if (taskLog != null)
            {
                taskLog.LastRunTime = DateTime.Now;
            }
            else
            {
               db.TaskLogs.InsertOnSubmit(new TaskLog
                {
                    TaskName = "Verificare Returnari",
                    LastRunTime = DateTime.Now
                });
            }
            db.SubmitChanges();
            return;
        }

        //private void VerificaNotificari(object state)
        //{
        //    try
        //    {
        //        var db = new BibliotecaElectronicaClassesDataContext();
        //        var returnariIntarziate = (from imprumut in db.Imprumuts
        //                                   join cititor in db.Cititors on imprumut.ID_Cititor equals cititor.ID
        //                                   where imprumut.DataReturnare == null && imprumut.TermenLimita < DateTime.Now
        //                                   select new
        //                                   {
        //                                       Imprumut = imprumut,
        //                                       Cititor = cititor
        //                                   }).ToList();


        //        foreach (var item in returnariIntarziate)
        //        {
        //            var carte = db.Cartes.Where(c => c.ID == item.Imprumut.ID_Carte).FirstOrDefault();
        //            var notificare = new Notificare
        //            {
        //                ID_Cititor = item.Imprumut.ID_Cititor,
        //                Tip_Notificare="Returnare intarziata",
        //                Mesaj = $"Ați întârziat cu returnarea cărții  {carte.Titlu}, de {carte.Autor}. Vă rugăm să o returnați cât mai curând!",
        //                DataTrimitere = DateTime.Now,
        //                Stare = "Necitit"
        //            };

        //            db.Notificares.InsertOnSubmit(notificare);
   
        //        }

        //        UpdateLastRunTime();
        //        db.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DataBaseException();
        //    }
        //}

        public void Stop()
        {
            _timer?.Dispose();
        }
    }
}
