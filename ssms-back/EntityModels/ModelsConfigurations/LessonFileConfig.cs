using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class LessonFileConfig : IEntityTypeConfiguration<LessonFile>
  {
    public void Configure(EntityTypeBuilder<LessonFile> builder)
    {
      builder.HasKey(e => e.LessonFileId);

      builder.ToTable("lessonsFiles");

      builder.Property(e => e.LessonFileId)
                .HasColumnName("lessonFileId")
                .ValueGeneratedNever();

      builder.Property(e => e.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("smalldatetime");

      builder.Property(e => e.CreatedBy).HasColumnName("createdBy");

      builder.Property(e => e.DocTypeId).HasColumnName("docTypeId");

      builder.Property(e => e.FilePath).HasColumnName("filePath");

      builder.Property(e => e.IsExternalLink).HasColumnName("isExternalLink");

      builder.Property(e => e.LessonId).HasColumnName("lessonId");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.LessonsFiles)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_lessonsFiles");

      builder.HasOne(d => d.DocType)
                .WithMany(p => p.LessonsFiles)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK_lessonsFiles_docTypes");

      builder.HasOne(d => d.Lesson)
                .WithMany(p => p.LessonsFiles)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK_lessonsFiles_lessons");

    }
  }
}