using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ViolationTypeConfig : IEntityTypeConfiguration<ViolationType>
  {
    public void Configure(EntityTypeBuilder<ViolationType> builder)
    {
      builder.HasKey(e => e.TypeId);

      builder.ToTable("violationsTypes");

      builder.Property(e => e.TypeId).HasColumnName("typeId");
      builder.Property(e => e.TypeNameAr).HasColumnName("typeNameAr").HasMaxLength(50).IsRequired();
      builder.Property(e => e.TypeNameEn).HasColumnName("typeNameEn").HasMaxLength(50).IsRequired();
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}