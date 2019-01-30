using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSMS.EntityModels
{
  public class SchoolDayEventConfig : IEntityTypeConfiguration<SchoolDayEvent>
  {
    public void Configure(EntityTypeBuilder<SchoolDayEvent> builder)
    {
      builder.HasKey(e => e.SchoolDayEventId);

      builder.ToTable("schoolDayEvents");

      builder.Property(e => e.SchoolDayEventId)
                .HasColumnName("schoolDayEventId")
                .ValueGeneratedNever();

      builder.Property(e => e.DayId).HasColumnName("dayId");

      builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType("time(0)");

      builder.Property(e => e.EventNameAr)
                .HasColumnName("eventNameAr")
                .HasMaxLength(50);

      builder.Property(e => e.EventNameEn)
                .HasColumnName("eventNameEn")
                .HasMaxLength(50);

      builder.Property(e => e.StageId).HasColumnName("stageId");

      builder.Property(e => e.StartTime)
                .HasColumnName("startTime")
                .HasColumnType("time(0)");

      builder.Property(e => e.IsDeleted).HasColumnName("isDeleted");

      builder.HasOne(d => d.Stage)
                .WithMany(p => p.SchoolDayEvents)
                .HasForeignKey(d => d.StageId)
                .HasConstraintName("FK_schoolDayEvents_stages");

    }
  }
}