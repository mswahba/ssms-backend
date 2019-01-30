using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class EmployeeFinanceConfig : IEntityTypeConfiguration<EmployeeFinance>
  {
    public void Configure(EntityTypeBuilder<EmployeeFinance> builder)
    {
      builder.HasKey(e => e.EmpId);

      builder.ToTable("employeesFinance");

      builder.Property(e => e.EmpId)
                .HasColumnName("empId")
                .HasColumnType("char(10)")
                .ValueGeneratedNever();

      builder.Property(e => e.BankAccount)
                .HasColumnName("bankAccount")
                .HasMaxLength(50);

      builder.Property(e => e.BankIBAN)
                .HasColumnName("bankIBAN")
                .HasMaxLength(50);

      builder.Property(e => e.BankName)
                .HasColumnName("bankName")
                .HasMaxLength(50);

      builder.Property(e => e.BasicSalary)
                .HasColumnName("basicSalary")
                .HasColumnType("smallmoney");

      builder.Property(e => e.Debts)
                .HasColumnName("debts")
                .HasColumnType("smallmoney");

      builder.Property(e => e.ExperienceAllowance)
                .HasColumnName("experienceAllowance")
                .HasColumnType("smallmoney");

      builder.Property(e => e.HousingAllowance)
                .HasColumnName("housingAllowance")
                .HasColumnType("smallmoney");

      builder.Property(e => e.Loans)
                .HasColumnName("loans")
                .HasColumnType("smallmoney");

      builder.Property(e => e.OtherAllowance)
                .HasColumnName("otherAllowance")
                .HasColumnType("smallmoney");

      builder.Property(e => e.TotalSalary)
                .HasColumnName("totalSalary")
                .HasColumnType("smallmoney");

      builder.Property(e => e.TransportAllowance)
                .HasColumnName("transportAllowance")
                .HasColumnType("smallmoney");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");
      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.EmployeesFinances)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_employeesFinance");

      builder.HasOne(d => d.Emp)
            .WithOne(p => p.EmployeesFinance)
            .HasForeignKey<EmployeeFinance>(d => d.EmpId)
            .HasConstraintName("FK_employeesFinance_employees");
    }
  }
}