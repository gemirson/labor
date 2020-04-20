using System;

namespace labor.Domain.Notifications
{
    public class Notification 
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
       

        public Notification(Guid domainNotificationId, string key, string value)
        {
            DomainNotificationId = domainNotificationId;
            Key = key;
            Value = value;
           
        }
    }
}
