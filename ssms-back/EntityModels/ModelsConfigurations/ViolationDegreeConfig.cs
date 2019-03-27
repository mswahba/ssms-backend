using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ViolationDegreeConfig : IEntityTypeConfiguration<ViolationDegree>
  {
    public void Configure(EntityTypeBuilder<ViolationDegree> builder)
    {
      builder.HasKey(e => e.DegreeId);

      builder.ToTable("violationsDegrees");

      builder.Property(e => e.DegreeId).HasColumnName("degreeId");
      builder.Property(e => e.DegreeNameAr).HasColumnName("degreeNameAr").HasMaxLength(50).IsRequired();
      builder.Property(e => e.DegreeNameEn).HasColumnName("degreeNameEn").HasMaxLength(50).IsRequired();
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}