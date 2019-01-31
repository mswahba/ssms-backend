using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class TimeTableConfig : IEntityTypeConfiguration<TimeTable>
  {
    public void Configure(EntityTypeBuilder<TimeTable> builder)
    {
        builder.ToTable("timeTables");

        builder.Property(e => e.TimeTableId)
                  .HasColumnName("timeTableId")
                  .ValueGeneratedNever();

        builder.Property(e => e.ClassroomId).HasColumnName("classroomId");

        builder.Property(e => e.EmpJobId).HasColumnName("empJobId");

        builder.Property(e => e.GradeSubjectId).HasColumnName("gradeSubjectId");

        builder.Property(e => e.SchoolDayEventId).HasColumnName("schoolDayEventId");

        builder.Property(e => e.IssuerId).HasColumnName("issuerId").HasMaxLength(10);
        builder.Property(e => e.SysStartTime).HasColumnName("sysStartTime");
        builder.Property(e => e.SysEndTime).HasColumnName("sysEndTime");

        builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        builder.HasOne(e => e._User)
              .WithMany(u => u.TimeTables)
              .HasForeignKey(e => e.IssuerId)
              .HasConstraintName("FK_users_timeTables");

        builder.HasOne(d => d.EmpJob)
                  .WithMany(p => p.TimeTable)
                  .HasForeignKey(d => d.EmpJobId)
                  .HasConstraintName("FK_timeTable_employeesJobs");

        builder.HasOne(d => d.GradeSubject)
                  .WithMany(p => p.TimeTable)
                  .HasForeignKey(d => d.GradeSubjectId)
                  .HasConstraintName("FK_timeTable_gradesSubjects");

        builder.HasOne(d => d.SchoolDayEvent)
                  .WithMany(p => p.TimeTable)
                  .HasForeignKey(d => d.SchoolDayEventId)
                  .HasConstraintName("FK_timeTable_schoolDayEvents");

    }
  }
}