using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ClassroomsConfig : IEntityTypeConfiguration<Classrooms>
  {
    public void Configure(EntityTypeBuilder<Classrooms> builder)
    {
      builder.HasKey(e => e.ClassroomId);

      builder.ToTable("classrooms");

      builder.Property(e => e.ClassroomId)
                .HasColumnName("classroomId")
                .ValueGeneratedNever();

      builder.Property(e => e.ClassNameAr)
                .HasColumnName("classNameAr")
                .HasMaxLength(25);

      builder.Property(e => e.ClassNameEn)
                .HasColumnName("classNameEn")
                .HasMaxLength(25);

      builder.Property(e => e.GradeId).HasColumnName("gradeId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Grade)
                .WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_classrooms_grades");

    }
  }
}