using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class NotifierService : INotifier
    {
        private List<Notifier> _notifications;

        public NotifierService()
        {
            _notifications = new List<Notifier>();
        }

        public void Handle(Notifier notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<Notifier> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
