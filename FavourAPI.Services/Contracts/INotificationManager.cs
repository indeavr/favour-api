
using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Helpers
{
    public interface INotificationManager
    {
        Task SendNotification(string target, Message message);
    }
}
