using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class AccountStatusConfig : IEntityTypeConfiguration<AccountStatus>
  {
    public void Configure(EntityTypeBuilder<AccountStatus> builder)
    {
      builder.HasKey(e => e.StatusId);

      builder.ToTable("accountStatus");

      builder.Property(e => e.StatusId).HasColumnName("statusId");

      builder.Property(e => e.StatusEn)
                .HasColumnName("statusEn")
                .HasMaxLength(20);

      builder.Property(e => e.StatusAr)
                .HasColumnName("statusAr")
                .HasMaxLength(20);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}