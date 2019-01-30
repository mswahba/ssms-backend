using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class EmployeeActionConfig : IEntityTypeConfiguration<EmployeeAction>
  {
    public void Configure(EntityTypeBuilder<EmployeeAction> builder)
    {
      builder.HasKey(e => new { e.EmpJobId, e.ActionId });

      builder.ToTable("employeesActions");

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.ActionId).HasColumnName("actionId");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Action)
                .WithMany(p => p.EmployeesActions)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesActions_actions");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.EmployeesActions)
                .HasForeignKey(d => d.EmpJobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employeesActions_employeesJobs");

    }
  }
}