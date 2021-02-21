using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventPreRequisiteEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int PreRequisiteEventId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual Event PreRequisiteEvent { get; set; }
    }



public partial class EventPreRequisiteEventConfiguration : IEntityTypeConfiguration<EventPreRequisiteEvent>
{
    public void Configure(EntityTypeBuilder<EventPreRequisiteEvent> builder)
    {
         builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventPreRequisiteEventEvent)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPreRequisiteEvent_Event");

                builder.HasOne(d => d.PreRequisiteEvent)
                    .WithMany(p => p.EventPreRequisiteEventPreRequisiteEvent)
                    .HasForeignKey(d => d.PreRequisiteEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPreRequisiteEvent_PreRequisiteEventId_Event");

    }

}
public static partial class Seeder
{
    public static void SeedEventPreRequisiteEvent(this ModelBuilder modelBuilder)
    {

    }
}
}