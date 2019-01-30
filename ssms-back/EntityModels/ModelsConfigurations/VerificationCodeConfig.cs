using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class VerificationCodeConfig : IEntityTypeConfiguration<VerificationCode>
  {
    public void Configure(EntityTypeBuilder<VerificationCode> builder)
    {
      builder.HasKey(e => e.CodeId);

      builder.ToTable("verificationCodes");

      builder.Property(e => e.CodeId).HasColumnName("codeId");

      builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(10);

      builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasMaxLength(10);

      builder.Property(e => e.SentTime).HasColumnName("sentTime");

      builder.Property(e => e.CodeTypeId).HasColumnName("codeTypeId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(vc => vc.User)
                .WithMany(u => u.VerificationCodes)
                .HasForeignKey(vc => vc.UserId)
                .HasConstraintName("FK_users_verificationCodes");

      builder.HasOne(vc => vc.VerificationCodeType)
                .WithMany(vct => vct.VerificationCodes)
                .HasForeignKey(vc => vc.CodeTypeId)
                .HasConstraintName("FK_verificationCodeTypes_verificationCodes");

    }
  }
}