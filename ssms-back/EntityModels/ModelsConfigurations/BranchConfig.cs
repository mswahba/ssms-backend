using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class BranchConfig : IEntityTypeConfiguration<Branch>
  {
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
      builder.HasKey(e => e.BranchId);

      builder.ToTable("branches");

      builder.Property(e => e.BranchId).HasColumnName("branchId");

      builder.Property(e => e.BranchNameAr)
                .HasColumnName("branchNameAr")
                .HasMaxLength(8);

      builder.Property(e => e.BranchNameEn)
                .HasColumnName("branchNameEn")
                .HasMaxLength(8);

      builder.Property(e => e.SchoolId).HasColumnName("schoolId");

      builder.HasOne(d => d.School)
                .WithMany(p => p.Branches)
                .HasForeignKey(d => d.SchoolId)
                .HasConstraintName("FK_branches_schools");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}