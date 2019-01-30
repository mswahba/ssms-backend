using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
  {
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
      builder.HasKey(e => e.TokenId);

      builder.ToTable("refreshTokens");

      builder.Property(e => e.TokenId).HasColumnName("tokenId");

      builder.Property(e => e.Token)
            .HasColumnName("token")
            .HasMaxLength(32);

      builder.Property(e => e.DeviceInfo)
                .HasColumnName("deviceInfo")
                .HasColumnType("varchar(MAX)");

      builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasMaxLength(10);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .HasConstraintName("FK_users_refreshTokens");

    }
  }
}