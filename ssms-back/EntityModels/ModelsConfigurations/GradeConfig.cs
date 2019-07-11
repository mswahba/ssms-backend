using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class GradeConfig : IEntityTypeConfiguration<Grade>
  {
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
      builder.HasKey(e => e.GradeId);

      builder.ToTable("grades");

      builder.Property(e => e.GradeId).HasColumnName("gradeId");

      builder.Property(e => e.GradeNameAr)
                .HasColumnName("gradeNameAr")
                .HasMaxLength(25);

      builder.Property(e => e.GradeNameEn)
                .HasColumnName("gradeNameEn")
                .HasMaxLength(25);

      builder.Property(e => e.StageId).HasColumnName("stageId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(g => g._Department)
                .WithMany(d => d.Grades)
                .HasForeignKey(d => d.StageId)
                .HasConstraintName("FK_Departments_grades");

    }
  }
}