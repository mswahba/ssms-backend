using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class EmployeeJobConfig : IEntityTypeConfiguration<EmployeeJob>
  {
    public void Configure(EntityTypeBuilder<EmployeeJob> builder)
    {
      builder.HasKey(e => e.EmpJobId);

      builder.ToTable("employeesJobs");

      builder.Property(e => e.EmpJobId)
                .HasColumnName("empJobId")
                .ValueGeneratedNever();

      builder.Property(e => e.BranchId).HasColumnName("branchId");

      builder.Property(e => e.DepartmentId).HasColumnName("departmentId");

      builder.Property(e => e.EmpId)
                .IsRequired()
                .HasColumnName("empId")
                .HasColumnType("char(10)");

      builder.Property(e => e.EndDate)
                .HasColumnName("endDate")
                .HasColumnType("date");

      builder.Property(e => e.JobId).HasColumnName("jobId");

      builder.Property(e => e.StartDate)
                .HasColumnName("startDate")
                .HasColumnType("date");
      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.EmployeesJobs)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_employeesJobs");

      builder.HasOne(d => d.Department)
                .WithMany(p => p.EmployeesJobs)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_employeesJobs_departments");

      builder.HasOne(d => d.Emp)
                .WithMany(p => p.EmployeesJobs)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_employeesJobs_employees");

      builder.HasOne(d => d.Job)
                .WithMany(p => p.EmployeesJobs)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_employeesJobs_jobs");
    }
  }
}