using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventCommunication
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public bool? Announcement1Sent { get; set; }
        public DateTime? Announcement1SentDate { get; set; }
        public DateTime? Announcement1ScheduledDate { get; set; }
        public bool? Announcement2Sent { get; set; }
        public DateTime? Announcement2SentDate { get; set; }
        public DateTime? Announcement2ScheduledDate { get; set; }
        public bool? Announcement3Sent { get; set; }
        public DateTime? Announcement3SentDate { get; set; }
        public DateTime? Announcement3ScheduledDate { get; set; }
        public bool? Reminder1Sent { get; set; }
        public DateTime? Reminder1SentDate { get; set; }
        public DateTime? Reminder1ScheduledDate { get; set; }
        public bool? Reminder2Sent { get; set; }
        public DateTime? Reminder2SentDate { get; set; }
        public DateTime? Reminder2ScheduledDate { get; set; }
        public bool? Reminder3Sent { get; set; }
        public DateTime? Reminder3SentDate { get; set; }
        public DateTime? Reminder3ScheduledDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
    }
    public partial class EventCommunicationConfiguration : IEntityTypeConfiguration<EventCommunication>
    {
        public void Configure(EntityTypeBuilder<EventCommunication> builder)
        {
builder.Property(e => e.Announcement1ScheduledDate).HasColumnType("datetime");

                builder.Property(e => e.Announcement1SentDate).HasColumnType("datetime");

                builder.Property(e => e.Announcement2ScheduledDate).HasColumnType("datetime");

                builder.Property(e => e.Announcement2SentDate).HasColumnType("datetime");

                builder.Property(e => e.Announcement3ScheduledDate).HasColumnType("datetime");

                builder.Property(e => e.Announcement3SentDate).HasColumnType("datetime");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Reminder1ScheduledDate).HasColumnType("datetime");

                builder.Property(e => e.Reminder1SentDate).HasColumnType("datetime");

                builder.Property(e => e.Reminder2ScheduledDate).HasColumnType("datetime");

                builder.Property(e => e.Reminder2SentDate).HasColumnType("datetime");

                builder.Property(e => e.Reminder3ScheduledDate).HasColumnType("datetime");

                builder.Property(e => e.Reminder3SentDate).HasColumnType("datetime");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventCommunication)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventCommunication_Event");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEventCommunication(this ModelBuilder modelBuilder)
        {

        }
    }
}
