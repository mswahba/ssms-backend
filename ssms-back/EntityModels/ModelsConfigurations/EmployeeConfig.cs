using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class EmployeeConfig : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.EmpId);

        builder.ToTable("employees");

        builder.Property(e => e.EmpId)
                  .HasColumnName("empId")
                  .HasColumnType("char(10)")
                  .ValueGeneratedNever();

        builder.Property(e => e.AddressHome).HasColumnName("addressHome");

        builder.Property(e => e.AddressKsa).HasColumnName("addressKsa");

        builder.Property(e => e.BirthDateG)
                  .HasColumnName("birthDateG")
                  .HasColumnType("date");

        builder.Property(e => e.BirthDateH)
                  .HasColumnName("birthDateH")
                  .HasColumnType("nchar(10)");

        builder.Property(e => e.BirthPlace)
                  .HasColumnName("birthPlace")
                  .HasMaxLength(50);

        builder.Property(e => e.CertificateDate)
                  .HasColumnName("certificateDate")
                  .HasColumnType("nchar(7)");

        builder.Property(e => e.CertificateDegree).HasColumnName("certificateDegree");

        builder.Property(e => e.CertificateGrade).HasColumnName("certificateGrade");

        builder.Property(e => e.CertificateMajor)
                  .HasColumnName("certificateMajor")
                  .HasMaxLength(50);

        builder.Property(e => e.CertificateName).HasColumnName("certificateName");

        builder.Property(e => e.CountryId).HasColumnName("countryId");

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

        builder.Property(e => e.Gender).HasColumnName("gender");

        builder.Property(e => e.HasDrivingLicense).HasColumnName("hasDrivingLicense");

        builder.Property(e => e.IdExpireDateG).HasColumnType("date");

        builder.Property(e => e.IdExpireDateH)
                  .HasColumnName("idExpireDateH")
                  .HasColumnType("nchar(10)");

        builder.Property(e => e.IdIssuePlace).HasMaxLength(50);

        builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        builder.Property(e => e.IsHandicapped).HasColumnName("isHandicapped");

        builder.Property(e => e.MaritalStatus)
                  .HasColumnName("maritalStatus")
                  .HasMaxLength(10);

        builder.Property(e => e.Mobile)
                  .HasColumnName("mobile")
                  .HasMaxLength(15);

        builder.Property(e => e.Mobile2)
                  .HasColumnName("mobile2")
                  .HasMaxLength(15);

        builder.Property(e => e.PassportExpireDateG)
                  .HasColumnName("passportExpireDateG")
                  .HasColumnType("date");

        builder.Property(e => e.PassportExpireDateH)
                  .HasColumnName("passportExpireDateH")
                  .HasColumnType("nchar(10)");

        builder.Property(e => e.PassportNum)
                  .HasColumnName("passportNum")
                  .HasMaxLength(15);

        builder.Property(e => e.Phone)
                  .HasColumnName("phone")
                  .HasMaxLength(15);

        builder.Property(e => e.PoBox)
                  .HasColumnName("poBox")
                  .HasMaxLength(10);

        builder.Property(e => e.PoCode)
                  .HasColumnName("poCode")
                  .HasMaxLength(10);

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

        builder.Property(e => e.Religion)
                  .HasColumnName("religion")
                  .HasMaxLength(15);

        builder.Property(e => e.SpecialNeeds).HasColumnName("specialNeeds");
        builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
        builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
        builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

        builder.HasOne(e => e._User)
                  .WithMany(u => u.Employees)
                  .HasForeignKey(e => e.IssuerId)
                  .HasConstraintName("FK_users_employees");

        builder.HasOne(e => e.Emp)
                  .WithOne(u => u._Employee)
                  .HasForeignKey<Employee>(e => e.EmpId)
                  .HasConstraintName("FK_employees_users");

        builder.HasOne(e => e.Country)
                  .WithMany(c => c.Employees)
                  .HasForeignKey(e => e.CountryId)
                  .HasConstraintName("FK_employees_countries");
    }
  }
}