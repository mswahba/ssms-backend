using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class ParentConfig : IEntityTypeConfiguration<Parent>
  {
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
      builder.HasKey(e => e.ParentId);

      builder.ToTable("parents");

      builder.Property(e => e.ParentId)
                .HasColumnName("parentId")
                .HasColumnType("char(10)")
                .ValueGeneratedNever();

      builder.Property(e => e.CityId).HasColumnName("cityId");

      builder.Property(e => e.District).HasColumnName("district");

      builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(50);

      builder.Property(e => e.FNameAr)
                .HasColumnName("fNameAr")
                .HasMaxLength(20);
      builder.Property(e => e.MNameAr)
                .HasColumnName("mNameAr")
                .HasMaxLength(20);
      builder.Property(e => e.GNameAr)
                .HasColumnName("gNameAr")
                .HasMaxLength(20);
      builder.Property(e => e.LNameAr)
                .HasColumnName("lNameAr")
                .HasMaxLength(20);

      builder.Property(e => e.FNameEn)
                .HasColumnName("fNameEn")
                .HasMaxLength(20);
      builder.Property(e => e.MNameEn)
                .HasColumnName("mNameEn")
                .HasMaxLength(20);
      builder.Property(e => e.GNameEn)
                .HasColumnName("gNameEn")
                .HasMaxLength(20);
      builder.Property(e => e.LNameEn)
                .HasColumnName("lNameEn")
                .HasMaxLength(20);

      builder.Property(e => e.HouseNum)
                .HasColumnName("houseNum")
                .HasMaxLength(5);

      builder.Property(e => e.IdExpireDateG).HasColumnType("date");

      builder.Property(e => e.IdExpireDateH)
                .HasColumnName("idExpireDateH")
                .HasColumnType("nchar(10)");

      builder.Property(e => e.IdIssuePlace).HasMaxLength(50);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.Property(e => e.Job).HasColumnName("job");

      builder.Property(e => e.Mobile1)
                .HasColumnName("mobile1")
                .HasMaxLength(15);

      builder.Property(e => e.Mobile2)
                .HasColumnName("mobile2")
                .HasMaxLength(15);

      builder.Property(e => e.CountryId)
                .HasColumnName("countryId")
                .HasMaxLength(15);

      builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(15);

      builder.Property(e => e.RelativeAddress).HasColumnName("relativeAddress");

      builder.Property(e => e.RelativeMobile)
                .HasColumnName("relativeMobile")
                .HasMaxLength(15);

      builder.Property(e => e.RelativeName)
                .HasColumnName("relativeName")
                .HasMaxLength(60);

      builder.Property(e => e.RelativePhone)
                .HasColumnName("relativePhone")
                .HasMaxLength(15);

      builder.Property(e => e.RelativeRelation)
                .HasColumnName("relativeRelation")
                .HasMaxLength(50);

      builder.Property(e => e.Street).HasColumnName("street");

      builder.Property(e => e.WorkAddress).HasColumnName("workAddress");

      builder.Property(e => e.WorkPhone)
                .HasColumnName("workPhone")
                .HasMaxLength(15);

      builder.HasOne(p => p._Parent)
                .WithOne(u => u._Parent)
                .HasForeignKey<Parent>(p => p.ParentId)
                .HasConstraintName("FK_parents_users");

      builder.HasOne(p => p.Country)
                .WithMany(c => c.Parents)
                .HasForeignKey(p => p.CountryId)
                .HasConstraintName("FK_parents_countries");

    }
  }
}