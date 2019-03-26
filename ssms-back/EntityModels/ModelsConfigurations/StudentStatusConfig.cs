using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StudentStatusConfig : IEntityTypeConfiguration<StudentStatus>
  {
    public void Configure(EntityTypeBuilder<StudentStatus> builder)
    {
      builder.HasKey(e => e.StatusId);

      builder.ToTable("studentStatuses");

      builder.Property(e => e.StatusId).HasColumnName("statusId");
      builder.Property(e => e.StatusNameAr).HasColumnName("relationNameAr");
      builder.Property(e => e.StatusNameEn).HasColumnName("relationNameEn");
      builder.Property(e => e.Notes).HasColumnName("notes");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");
    }
  }
}