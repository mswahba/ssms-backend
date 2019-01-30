using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class MajorConfig : IEntityTypeConfiguration<Major>
  {
    public void Configure(EntityTypeBuilder<Major> builder)
    {
      builder.HasKey(e => e.MajorId);

      builder.ToTable("majors");

      builder.Property(e => e.MajorId).HasColumnName("majorId");

      builder.Property(e => e.MajorNameAr)
                .HasColumnName("majorNameAr")
                .HasMaxLength(50);

      builder.Property(e => e.MajorNameEn)
                .HasColumnName("majorNameEn")
                .HasMaxLength(50);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}