using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class TeacherEduConfig : IEntityTypeConfiguration<TeacherEdu>
  {
    public void Configure(EntityTypeBuilder<TeacherEdu> builder)
    {
      builder.HasKey(e => new { e.EmpJobId, e.GradeSubjectId });

      builder.ToTable("teachersEdu");

      builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

      builder.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

      builder.Property(e => e.ClassroomIds)
              .HasColumnName("classroomIds")
              .HasMaxLength(150)
              .IsUnicode(false);

      builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
      builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
      builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

    builder.HasOne(e => e._User)
          .WithMany(u => u.TeachersEdu)
          .HasForeignKey(e => e.IssuerId)
          .HasConstraintName("FK_users_employeesFinance");

      builder.HasOne(d => d.EmpJob)
                .WithMany(p => p.TeachersEdu)
                .HasForeignKey(d => d.EmpJobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_teachersEdu_employeesJobs");

      builder.HasOne(d => d.GradeSubject)
                .WithMany(p => p.TeachersEdu)
                .HasForeignKey(d => d.GradeSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_teachersEdu_gradesSubjects");

    }
  }
}