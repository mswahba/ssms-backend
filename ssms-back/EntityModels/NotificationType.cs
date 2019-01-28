using System.Collections.Generic;

namespace SSMS.EntityModels
{
    public class NotificationType
    {
        public NotificationType()
        {
            Notifications = new HashSet<Notification>();
            NotificationTypesUsers = new HashSet<NotificationTypeUser>();
        }

        public short NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public string MessageAr { get; set; }
        public string MessageEn { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<NotificationTypeUser> NotificationTypesUsers { get; set; }
    }
}
