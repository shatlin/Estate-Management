using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventMinute
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string Minute { get; set; }
        public int RaisedBy { get; set; }
        public int AssignedTo { get; set; }
        public int MinuteStatusId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventMinuteStatus MinuteStatus { get; set; }
    }
    public partial class EventMinuteConfiguration : IEntityTypeConfiguration<EventMinute>
    {
        public void Configure(EntityTypeBuilder<EventMinute> builder)
        {
             builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Heading).HasMaxLength(50);

                builder.Property(e => e.Minute)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.SubHeading).HasMaxLength(50);

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventMinute)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventMinute_Event");

                builder.HasOne(d => d.MinuteStatus)
                    .WithMany(p => p.EventMinute)
                    .HasForeignKey(d => d.MinuteStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventMinute_EventMinuteStatus");

        }

    }
    public static partial class Seeder
    {
        public static void SeedEventMinute(this ModelBuilder modelBuilder)
        {

        }
    }
}
