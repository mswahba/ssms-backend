namespace SSMS.EntityModels
{
    public class NotificationTypeUser
    {
        public int NotificationTypeUserId { get; set; }
        public short? NotificationTypeId { get; set; }
        public string UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public NotificationType NotificationType { get; set; }
        public User User { get; set; }
    }
}
