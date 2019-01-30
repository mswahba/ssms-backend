using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StudentViolationConfig : IEntityTypeConfiguration<StudentViolation>
  {
    public void Configure(EntityTypeBuilder<StudentViolation> builder)
    {
      builder.HasKey(e => e.StudentViolationId);

      builder.ToTable("studentsViolations");

      builder.Property(e => e.StudentViolationId)
                .HasColumnName("studentViolationId")
                .ValueGeneratedNever();

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.StudentId)
                .HasColumnName("studentId")
                .HasColumnType("char(10)");

      builder.Property(e => e.ViolationDate)
                .HasColumnName("violationDate")
                .HasColumnType("smalldatetime");

      builder.Property(e => e.ViolationId).HasColumnName("violationId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_studentsViolations_employeesJobs");

      builder.HasOne(d => d.Student)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_studentsViolations_students");

      builder.HasOne(d => d.Violation)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.ViolationId)
                .HasConstraintName("FK_studentsViolations_behavioralViolations");

    }
  }
}