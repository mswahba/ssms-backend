using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StudentProcedureConfig : IEntityTypeConfiguration<StudentProcedure>
  {
    public void Configure(EntityTypeBuilder<StudentProcedure> builder)
    {
      builder.HasKey(e => e.StudentProcedureId);

      builder.ToTable("studentsProcedures");

      builder.Property(e => e.StudentProcedureId).HasColumnName("studentProcedureId").ValueGeneratedNever();

      builder.Property(e => e.ProcedureId).HasColumnName("procedureId");
      builder.Property(e => e.StudentViolationId).HasColumnName("studentViolationId");
      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");
      builder.Property(e => e.ProcedureDate).HasColumnName("procedureDate").HasColumnType("smalldatetime");

      builder.HasOne(d => d._StudentViolation)
                .WithMany(p => p.StudentsProcedures)
                .HasForeignKey(d => d.StudentViolationId)
                .HasConstraintName("FK_studentsViolations_studentsProcedures");

      builder.HasOne(d => d._Procedure)
                .WithMany(p => p.StudentsProcedures)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("FK_procedures_studentsProcedures");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.StudentsProcedures)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_employeesJobs_studentsProcedures");

      builder.HasOne(e => e._User)
              .WithMany(u => u.StudentsProcedures)
              .HasForeignKey(e => e.IssuerId)
              .HasConstraintName("FK_users_studentsProcedures");

    }
  }
}