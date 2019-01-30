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

      builder.Property(e => e.StudentProcedureId)
                .HasColumnName("studentProcedureId")
                .ValueGeneratedNever();

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.ProcedureDate)
                .HasColumnName("procedureDate")
                .HasColumnType("smalldatetime");

      builder.Property(e => e.ProcedureId).HasColumnName("procedureId");

      builder.Property(e => e.StudentViolationId).HasColumnName("studentViolationId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.StudentsProcedures)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_studentsProcedures_employeesJobs");

      builder.HasOne(d => d.Procedure)
                .WithMany(p => p.StudentsProcedures)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("FK_studentsProcedures_remedialProcedures");

      builder.HasOne(d => d.StudentViolation)
                .WithMany(p => p.StudentsProcedures)
                .HasForeignKey(d => d.StudentViolationId)
                .HasConstraintName("FK_studentsProcedures_studentsViolations");

    }
  }
}