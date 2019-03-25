using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ViolationConfig : IEntityTypeConfiguration<Violation>
  {
    public void Configure(EntityTypeBuilder<Violation> builder)
    {
      builder.HasKey(e => e.ViolationId);

      builder.ToTable("violations");

      builder.Property(e => e.ViolationId)
                .HasColumnName("violationId")
                .ValueGeneratedNever();

      builder.Property(e => e.ViolationNameAr).HasColumnName("violationNameAr");
      builder.Property(e => e.ViolationNameEn).HasColumnName("violationNameEn");
      builder.Property(e => e.DegreeId).HasColumnName("degreeId");
      builder.Property(e => e.TypeId).HasColumnName("typeId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(v => v._ViolationDegree)
                .WithMany(vd => vd.Violations)
                .HasForeignKey(v => v.DegreeId)
                .HasConstraintName("FK_violationsDegrees_violations");
      builder.HasOne(v => v._ViolationType)
                .WithMany(vd => vd.Violations)
                .HasForeignKey(v => v.TypeId)
                .HasConstraintName("FK_violationsTypes_violations");

    }
  }
}