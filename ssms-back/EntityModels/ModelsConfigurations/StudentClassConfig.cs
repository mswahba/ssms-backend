using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StudentClassConfig : IEntityTypeConfiguration<StudentClass>
  {
    public void Configure(EntityTypeBuilder<StudentClass> builder)
    {
      builder.HasKey(e => e.StudentClassId);

      builder.ToTable("studentsClasses");

      builder.Property(e => e.StudentClassId)
                .HasColumnName("classStudentId")
                .ValueGeneratedNever();

      builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

      builder.Property(e => e.StudentId)
                .IsRequired()
                .HasColumnName("studentId")
                .HasColumnType("char(10)");

      builder.Property(e => e.YearId).HasColumnName("yearId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.HasOne(d => d._Classroom)
                .WithMany(p => p.StudentsClasses)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_classrooms_studentsClasses");

      builder.HasOne(d => d._Student)
                .WithMany(p => p.StudentsClasses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_students_studentsClasses");

      builder.HasOne(d => d.Year)
                .WithMany(p => p.StudentsClasses)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_academicYears_studentsClasses");

      builder.HasOne(e => e._User)
              .WithMany(u => u.StudentsClasses)
              .HasForeignKey(e => e.IssuerId)
              .HasConstraintName("FK_users_studentsClasses");

    }
  }
}