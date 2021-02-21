using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventAttendance
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public TimeSpan SignInTime { get; set; }
        public TimeSpan SingOutTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class EventAttendanceConfiguration : IEntityTypeConfiguration<EventAttendance>
{
    public void Configure(EntityTypeBuilder<EventAttendance> builder)
    {
         builder.Property(e => e.AttendanceDate).HasColumnType("datetime");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendance)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAttendance_Event");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.EventAttendance)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAttendance_Member");

    }

}
public static partial class Seeder
{
    public static void SeedEventAttendance(this ModelBuilder modelBuilder)
    {

    }
}
}

