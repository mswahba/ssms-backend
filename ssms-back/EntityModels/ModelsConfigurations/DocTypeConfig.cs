using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class DocTypeConfig : IEntityTypeConfiguration<DocType>
  {
    public void Configure(EntityTypeBuilder<DocType> builder)
    {
      builder.HasKey(e => e.DocTypeId);

      builder.ToTable("docTypes");

      builder.Property(e => e.DocTypeId).HasColumnName("docTypeId");

      builder.Property(e => e.DocTypeAr)
                .HasColumnName("docTypeAr")
                .HasMaxLength(50);

      builder.Property(e => e.DocTypeEn)
                .HasColumnName("docTypeEn")
                .HasMaxLength(50);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}