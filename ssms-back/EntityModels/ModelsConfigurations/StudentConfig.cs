using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class StudentConfig : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder)
    {
      builder.HasKey(e => e.StudentId);

      builder.ToTable("students");

      builder.Property(e => e.StudentId)
                .HasColumnName("studentId")
                .HasColumnType("char(10)")
                .ValueGeneratedNever();

      builder.Property(e => e.BirthDateG).HasColumnName("birthDateG").HasColumnType("date");

      builder.Property(e => e.BirthDateH).HasColumnName("birthDateH").HasColumnType("nchar(10)");

      builder.Property(e => e.BirthPlace).HasColumnName("birthPlace").HasMaxLength(50);

      builder.Property(e => e.Email).HasColumnName("email").HasMaxLength(50);

      builder.Property(e => e.FNameAr).HasColumnName("fNameAr").HasMaxLength(20);
      builder.Property(e => e.MNameAr).HasColumnName("mNameAr").HasMaxLength(20);
      builder.Property(e => e.GNameAr).HasColumnName("gNameAr").HasMaxLength(20);
      builder.Property(e => e.LNameAr).HasColumnName("lNameAr").HasMaxLength(20);

      builder.Property(e => e.FNameEn).HasColumnName("fNameEn").HasMaxLength(20);
      builder.Property(e => e.MNameEn).HasColumnName("mNameEn").HasMaxLength(20);
      builder.Property(e => e.GNameEn).HasColumnName("gNameEn").HasMaxLength(20);
      builder.Property(e => e.LNameEn).HasColumnName("lNameEn").HasMaxLength(20);

      builder.Property(e => e.Gender).HasColumnName("gender");

      builder.Property(e => e.IdExpireDateG).HasColumnType("date");

      builder.Property(e => e.IdExpireDateH).HasColumnName("idExpireDateH").HasColumnType("nchar(10)");

      builder.Property(e => e.IdIssuePlace).HasMaxLength(50);

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.Property(e => e.Mobile).HasColumnName("mobile").HasMaxLength(15);

      builder.Property(e => e.MobileMother).HasColumnName("mobileMother").HasMaxLength(15);

      builder.Property(e => e.ParentId).HasColumnName("parentId").HasColumnType("char(10)");

      builder.Property(e => e.PreviousSchool).HasColumnName("previousSchool").HasMaxLength(100);

      builder.Property(e => e.SpecialNeeds).HasColumnName("specialNeeds");

      builder.Property(e => e.CountryId).HasColumnName("countryId");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(s => s._Student)
                .WithOne(p => p._Student)
                .HasForeignKey<Student>(s => s.StudentId)
                .HasConstraintName("FK_students_users");

      builder.HasOne(e => e._User)
              .WithMany(u => u.Students)
              .HasForeignKey(e => e.IssuerId)
              .HasConstraintName("FK_users_students");

      builder.HasOne(d => d.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_students_parents");

      builder.HasOne(s => s.Country)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CountryId)
                .HasConstraintName("FK_students_countries");
    }
  }
}