using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class SchoolConfig : IEntityTypeConfiguration<School>
  {
    public void Configure(EntityTypeBuilder<School> builder)
    {
      builder.HasKey(e => e.SchoolId);

      builder.ToTable("schools");

      builder.Property(e => e.SchoolId).HasColumnName("schoolID");

      builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(250);

      builder.Property(e => e.ComNum)
                .HasColumnName("comNum")
                .HasMaxLength(50);

      builder.Property(e => e.IsActive).HasColumnName("isActive");

      builder.Property(e => e.SchoolNameAr)
                .HasColumnName("schoolNameAr")
                .HasMaxLength(150);

      builder.Property(e => e.SchoolNameEn)
                .HasColumnName("schoolNameEn")
                .HasMaxLength(150);

      builder.Property(e => e.StartDate)
                .HasColumnName("startDate")
                .HasColumnType("date");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}