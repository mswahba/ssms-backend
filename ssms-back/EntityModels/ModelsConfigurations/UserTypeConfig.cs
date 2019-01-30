using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class UserTypeConfig : IEntityTypeConfiguration<UserType>
  {
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
      builder.HasKey(e => e.UserTypeId);

      builder.ToTable("userTypes");

      builder.Property(e => e.UserTypeId).HasColumnName("userTypeId");

      builder.Property(e => e.UserTypeName)
                .HasColumnName("userTypeName")
                .HasMaxLength(25);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    }
  }
}