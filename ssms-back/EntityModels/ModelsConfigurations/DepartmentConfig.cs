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

      builder.Property(e => e.DepartmentNameAr)
                .HasColumnName("departmentNameAr")
                .HasMaxLength(100);

      builder.Property(e => e.DepartmentNameEn)
                .HasColumnName("departmentNameEn")
                .HasMaxLength(100);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}