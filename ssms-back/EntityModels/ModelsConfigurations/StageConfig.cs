using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StageConfig : IEntityTypeConfiguration<Stage>
  {
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
      builder.HasKey(e => e.StageId);

      builder.ToTable("stages");

      builder.Property(e => e.StageId).HasColumnName("stageId");

      builder.Property(e => e.BranchId).HasColumnName("branchId");

      builder.Property(e => e.StageNameAr)
                .HasColumnName("stageNameAr")
                .HasMaxLength(25);

      builder.Property(e => e.StageNameEn)
                .HasColumnName("stageNameEn")
                .HasMaxLength(25);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Branch)
                .WithMany(p => p.Stages)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_stages_branches");

    }
  }
}