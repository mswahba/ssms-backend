using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ClassStudentConfig : IEntityTypeConfiguration<ClassStudent>
  {
    public void Configure(EntityTypeBuilder<ClassStudent> builder)
    {
      builder.HasKey(e => e.ClassStudentId);

      builder.ToTable("classesStudents");

      builder.Property(e => e.ClassStudentId)
                .HasColumnName("classStudentId")
                .ValueGeneratedNever();

      builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

      builder.Property(e => e.EndDate)
                .HasColumnName("endDate")
                .HasColumnType("date");

      builder.Property(e => e.StartDate)
                .HasColumnName("startDate")
                .HasColumnType("date");

      builder.Property(e => e.StudentId)
                .IsRequired()
                .HasColumnName("studentId")
                .HasColumnType("char(10)");

      builder.Property(e => e.YearId).HasColumnName("yearId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Classroom)
                .WithMany(p => p.ClassesStudents)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK_classesStudents_classrooms");

      builder.HasOne(d => d.Student)
                .WithMany(p => p.ClassesStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_classesStudents_students");

      builder.HasOne(d => d.Year)
                .WithMany(p => p.ClassesStudents)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_classesStudents_academicYears");

    }
  }
}