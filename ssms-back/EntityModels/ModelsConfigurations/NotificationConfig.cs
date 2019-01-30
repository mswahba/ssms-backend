using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class NotificationConfig : IEntityTypeConfiguration<Notification>
  {
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
      builder.HasKey(e => e.NotificationId);

      builder.ToTable("notifications");

      builder.Property(e => e.NotificationId).HasColumnName("notificationId");

      builder.Property(e => e.NotificationTypeId).HasColumnName("notificationTypeId");

      builder.Property(e => e.CreatedAt).HasColumnName("createdAt");

      builder.Property(e => e.UserId).HasColumnName("userId").HasMaxLength(10);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(n => n.NotificationType)
                .WithMany(nType => nType.Notifications)
                .HasForeignKey(n => n.NotificationTypeId)
                .HasConstraintName("FK_notificationTypes_notifications");

      builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .HasConstraintName("FK_users_notifications");

    }
  }
}