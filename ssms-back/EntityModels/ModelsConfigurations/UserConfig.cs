using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class UserConfig : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(e => e.UserId);

      builder.ToTable("users");

      builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasColumnType("char(10)")
                .ValueGeneratedNever();

      builder.Property(e => e.AccountStatusId).HasColumnName("accountStatusId");

      builder.Property(e => e.LastActive)
                .HasColumnName("lastActive")
                .HasColumnType("datetime");

      builder.Property(e => e.SubscribeDate)
                .HasColumnName("subscribeDate")
                .HasColumnType("smalldatetime");

      builder.Property(e => e.PasswordHash)
                .HasColumnName("passwordHash")
                .HasMaxLength(50);

      builder.Property(e => e.PasswordSalt)
                .HasColumnName("passwordSalt")
                .HasMaxLength(50);

      builder.Property(e => e.UserTypeId).HasColumnName("userTypeId");
      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(u => u._User)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.IssuerId)
                .HasConstraintName("FK_usersA_usersB");

      builder.HasOne(u => u.UserType)
                .WithMany(uType => uType.Users)
                .HasForeignKey(u => u.UserTypeId)
                .HasConstraintName("FK_users_userTypes");

      builder.HasOne(u => u.AccountStatus)
                .WithMany(acc => acc.Users)
                .HasForeignKey(u => u.AccountStatusId)
                .HasConstraintName("FK_users_accountStatus");
    }
  }
}