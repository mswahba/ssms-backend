using System;

namespace SSMS.EntityModels
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public short? NotificationTypeId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public NotificationType NotificationType { get; set; }
        public User User { get; set; }
    }
}
