using labor.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace labor.Domain.Interface.Notification
{
    public interface INotification
    {
        IList<object> List { get; }
        bool HasNotifications { get; }

        bool Includes(Description error);
        void Add(Description error);
    }
}
