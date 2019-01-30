using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class NotificationTypeUserConfig : IEntityTypeConfiguration<NotificationTypeUser>
  {
    public void Configure(EntityTypeBuilder<NotificationTypeUser> builder)
    {
      builder.HasKey(e => e.NotificationTypeUserId);

      builder.ToTable("notificationTypesUsers");

      builder.Property(e => e.NotificationTypeUserId).HasColumnName("notificationTypeUserId");

      builder.Property(e => e.NotificationTypeId).HasColumnName("notificationTypeId");

      builder.Property(e => e.UserId).HasColumnName("userId").HasMaxLength(10);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(n => n.NotificationType)
                .WithMany(nType => nType.NotificationTypesUsers)
                .HasForeignKey(n => n.NotificationTypeId)
                .HasConstraintName("FK_notificationTypes_notificationTypesUsers");

      builder.HasOne(n => n.User)
                .WithMany(u => u.NotificationTypesUsers)
                .HasForeignKey(n => n.UserId)
                .HasConstraintName("FK_users_notificationTypesUsers");

    }
  }
}