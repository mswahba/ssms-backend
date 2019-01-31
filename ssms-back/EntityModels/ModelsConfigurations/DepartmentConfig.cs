using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class DepartmentConfig : IEntityTypeConfiguration<Department>
  {
    public void Configure(EntityTypeBuilder<Department> builder)
    {
      builder.HasKey(e => e.DepartmentId);

      builder.ToTable("departments");

      builder.Property(e => e.DepartmentId).HasColumnName("departmentId");

      builder.Property(e => e.DepartmentNameAr).HasColumnName("departmentNameAr").HasMaxLength(100);

      builder.Property(e => e.DepartmentNameEn).HasColumnName("departmentNameEn").HasMaxLength(100);

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.Departments)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_departments");
    }
  }
}