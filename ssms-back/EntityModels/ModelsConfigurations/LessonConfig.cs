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

      builder.Property(e => e.LessonTitle).HasColumnName("lessonTitle").HasMaxLength(150);

      builder.Property(e => e.SemesterId).HasColumnName("semesterId");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.Lessons)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_lessons");

    }
  }
}