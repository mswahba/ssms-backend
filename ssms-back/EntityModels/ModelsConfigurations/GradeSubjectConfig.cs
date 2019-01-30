using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class GradeSubjectConfig : IEntityTypeConfiguration<GradeSubject>
  {
    public void Configure(EntityTypeBuilder<GradeSubject> builder)
    {
      builder.HasKey(e => e.GradeSubjectId);

      builder.ToTable("gradesSubjects");

      builder.HasIndex(e => new { e.GradeId, e.SubjectId })
                .HasName("ucGradeSubject")
                .IsUnique();

      builder.Property(e => e.GradeSubjectId)
                .HasColumnName("gradeSubjectId")
                .ValueGeneratedNever();

      builder.Property(e => e.GradeId).HasColumnName("gradeId");

      builder.Property(e => e.PeriodsCount).HasColumnName("periodsCount");

      builder.Property(e => e.SubjectId).HasColumnName("subjectId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Grade)
                .WithMany(p => p.GradesSubjects)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gradesSubjects_grades");

      builder.HasOne(d => d.Subject)
                .WithMany(p => p.GradesSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gradesSubjects_subjects");

    }
  }
}