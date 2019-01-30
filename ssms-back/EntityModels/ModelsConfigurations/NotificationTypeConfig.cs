using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class NotificationTypeConfig : IEntityTypeConfiguration<NotificationType>
  {
    public void Configure(EntityTypeBuilder<NotificationType> builder)
    {
      builder.HasKey(e => e.NotificationTypeId);

      builder.ToTable("notificationTypes");

      builder.Property(e => e.NotificationTypeId).HasColumnName("notificationTypeId");

      builder.Property(e => e.NotificationTypeName).HasColumnName("notificationTypeName");

      builder.Property(e => e.MessageAr).HasColumnName("messageAr");

      builder.Property(e => e.MessageEn).HasColumnName("messageEn");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}