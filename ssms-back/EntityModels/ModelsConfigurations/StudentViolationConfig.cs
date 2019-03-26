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

      builder.Property(e => e.ViolationId).HasColumnName("violationId");
      builder.Property(e => e.StudentId).HasColumnName("studentId").HasColumnType("char(10)");
      builder.Property(e => e.StudentClassId).HasColumnName("studentClassId");
      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.ViolationDate).HasColumnName("violationDate").HasColumnType("smalldatetime");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.HasOne(d => d._Violation)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.ViolationId)
                .HasConstraintName("FK_violations_studentsViolations");

      builder.HasOne(d => d._Student)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_students_studentsViolations");

      builder.HasOne(d => d._StudentClass)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.StudentClassId)
                .HasConstraintName("FK_studentsClasses_studentsViolations");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.StudentsViolations)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_employeesJobs_studentsViolations");

      builder.HasOne(e => e._User)
              .WithMany(u => u.StudentsViolations)
              .HasForeignKey(e => e.IssuerId)
              .HasConstraintName("FK_users_studentsViolations");
    }
  }
}