using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class EmployeeHRConfig : IEntityTypeConfiguration<EmployeeHR>
  {
    public void Configure(EntityTypeBuilder<EmployeeHR> builder)
    {
      builder.HasKey(e => e.EmpId);

      builder.ToTable("employeesHR");

      builder.Property(e => e.EmpId)
                .HasColumnName("empId")
                .HasColumnType("char(10)")
                .ValueGeneratedNever();

      builder.Property(e => e.CeoApproval)
                .HasColumnName("ceoApproval")
                .HasColumnType("smalldatetime");

      builder.Property(e => e.ContractType)
                .HasColumnName("contractType")
                .HasMaxLength(15);

      builder.Property(e => e.HrNotes).HasColumnName("hrNotes");

      builder.Property(e => e.JobInId)
                .HasColumnName("jobInId")
                .HasMaxLength(50);

      builder.Property(e => e.NoorRegistered).HasColumnName("noorRegistered");

      builder.Property(e => e.SalahiaDateG).HasColumnType("date");

      builder.Property(e => e.SalahiaDateH).HasColumnType("nchar(10)");

      builder.Property(e => e.SocialSecurityNum).HasColumnName("socialSecurityNum");

      builder.Property(e => e.SocialSecuritySubscription).HasColumnName("socialSecuritySubscription");

      builder.Property(e => e.WorkStatus).HasColumnName("workStatus");

      builder.Property(e => e.WorkStartDateH)
                .HasColumnName("workStartDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.WorkStartDateG)
                .HasColumnName("WorkStartDateG")
                .HasColumnType("date");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Emp)
                .WithOne(p => p.EmployeesHr)
                .HasForeignKey<EmployeeHR>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeesHR_employees");
    }
  }
}