using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class BehavioralViolationConfig : IEntityTypeConfiguration<BehavioralViolation>
  {
    public void Configure(EntityTypeBuilder<BehavioralViolation> builder)
    {
      builder.HasKey(e => e.ViolationId);

      builder.ToTable("behavioralViolations");

      builder.Property(e => e.ViolationId)
                .HasColumnName("violationId")
                .ValueGeneratedNever();

      builder.Property(e => e.CategoryId).HasColumnName("categoryId");

      builder.Property(e => e.ViolationNameAr)
                .HasColumnName("violationNameAr")
                .HasMaxLength(150);

      builder.Property(e => e.ViolationNameEn)
                .HasColumnName("violationNameEn")
                .HasMaxLength(150);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}