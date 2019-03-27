using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ParentAddressConfig : IEntityTypeConfiguration<ParentAddress>
  {
    public void Configure(EntityTypeBuilder<ParentAddress> builder)
    {
      builder.HasKey(e => e.AddressId);

      builder.ToTable("parentsAddresses");

      builder.Property(e => e.AddressId).HasColumnName("addressId");
      builder.Property(e => e.ParentId).HasColumnName("parentId").HasMaxLength(10);
      builder.Property(e => e.CityId).HasColumnName("cityId");
      builder.Property(e => e.DistrictId).HasColumnName("districtId");
      builder.Property(e => e.StreetName).HasColumnName("streetName");
      builder.Property(e => e.HouseNumber).HasColumnName("houseNumber");
      builder.Property(e => e.ExtraDetails).HasColumnName("extraDetails");
      builder.Property(e => e.Coords).HasColumnName("coords").HasMaxLength(50);
      builder.Property(e => e.Phone).HasColumnName("phone").HasMaxLength(20);
      builder.Property(e => e.IsMain).HasColumnName("isMain");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.HasOne(d => d._Parent)
          .WithMany(p => p.ParentsAddresses)
          .HasForeignKey(d => d.ParentId)
          .HasConstraintName("FK_parents_parentsAddresses");

      builder.HasOne(e => e._City)
          .WithMany(c => c.ParentsAddresses)
          .HasForeignKey(e => e.CityId)
          .HasConstraintName("FK_cities_parentsAddresses");

      builder.HasOne(d => d._District)
          .WithMany(d => d.ParentsAddresses)
          .HasForeignKey(d => d.DistrictId)
          .HasConstraintName("FK_districts_parentsAddresses");

      builder.HasOne(e => e._User)
          .WithMany(u => u.ParentsAddresses)
          .HasForeignKey(e => e.IssuerId)
          .HasConstraintName("FK_users_parentsAddresses");
    }
  }
}