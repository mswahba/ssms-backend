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

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.EmployeesActions)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_employeesActions");

      builder.HasOne(d => d.Action)
                .WithMany(p => p.EmployeesActions)
                .HasForeignKey(d => d.ActionId)
                .HasConstraintName("FK_employeesActions_actions");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.EmployeesActions)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_employeesActions_employeesJobs");

    }
  }
}