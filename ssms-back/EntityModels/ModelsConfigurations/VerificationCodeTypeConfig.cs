using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class VerificationCodeTypeConfig : IEntityTypeConfiguration<VerificationCodeType>
  {
    public void Configure(EntityTypeBuilder<VerificationCodeType> builder)
    {
      builder.HasKey(e => e.CodeTypeId);

      builder.ToTable("verificationCodeTypes");

      builder.Property(e => e.CodeTypeId).HasColumnName("codeTypeId");

      builder.Property(e => e.CodeType)
                .HasColumnName("codeType")
                .HasMaxLength(25);

      builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(MAX)");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}