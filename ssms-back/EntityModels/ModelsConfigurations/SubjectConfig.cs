using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class SubjectConfig : IEntityTypeConfiguration<Subject>
  {
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
      builder.HasKey(e => e.SubjectId);

      builder.ToTable("subjects");

      builder.Property(e => e.SubjectId).HasColumnName("subjectId");

      builder.Property(e => e.MajorId).HasColumnName("majorId");

      builder.Property(e => e.ShortNameAr)
                .HasColumnName("shortNameAr")
                .HasMaxLength(5);

      builder.Property(e => e.ShortNameEn)
                .HasColumnName("shortNameEn")
                .HasMaxLength(5);

      builder.Property(e => e.SubjectNameAr)
                .HasColumnName("subjectNameAr")
                .HasMaxLength(25);

      builder.Property(e => e.SubjectNameEn)
                .HasColumnName("subjectNameEn")
                .HasMaxLength(25);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Major)
                .WithMany(p => p.Subjects)
                .HasForeignKey(d => d.MajorId)
                .HasConstraintName("FK_subjects_majors");

    }
  }
}