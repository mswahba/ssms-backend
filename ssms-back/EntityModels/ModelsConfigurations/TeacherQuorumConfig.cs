using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class TeacherQuorumConfig : IEntityTypeConfiguration<TeacherQuorum>
  {
    public void Configure(EntityTypeBuilder<TeacherQuorum> builder)
    {
      builder.HasKey(e => e.TeacherQuorumId);

      builder.ToTable("teachersQuorums");

      builder.Property(e => e.TeacherQuorumId)
                .HasColumnName("teacherQuorumId")
                .ValueGeneratedNever();

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.PeriodsQuorum).HasColumnName("periodsQuorum");

      builder.Property(e => e.SemesterId).HasColumnName("semesterId");

      builder.Property(e => e.SubstituteQuorum).HasColumnName("substituteQuorum");

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(e => e._User)
            .WithMany(u => u.TeachersQuorums)
            .HasForeignKey(e => e.IssuerId)
            .HasConstraintName("FK_users_teachersQuorums");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.TeachersQuorums)
                .HasForeignKey(d => d.EmpJobId)
                .HasConstraintName("FK_teachersQuorums_employeesJobs");

      builder.HasOne(d => d.Semester)
                .WithMany(p => p.TeachersQuorums)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK_teachersQuorums_academicSemesters");

    }
  }
}