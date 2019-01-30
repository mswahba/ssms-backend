using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class LessonConfig : IEntityTypeConfiguration<Lesson>
  {
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
      builder.HasKey(e => e.LessonId);

      builder.ToTable("lessons");

      builder.Property(e => e.LessonId)
                .HasColumnName("lessonId")
                .ValueGeneratedNever();

      builder.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

      builder.Property(e => e.LessonObjectives).HasColumnName("lessonObjectives");

      builder.Property(e => e.LessonTitle)
                .HasColumnName("lessonTitle")
                .HasMaxLength(150);

      builder.Property(e => e.SemesterId).HasColumnName("semesterId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}