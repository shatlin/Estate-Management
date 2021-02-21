using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventRegistration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public int EventResponseTypeId { get; set; }
        public bool Cancelled { get; set; }
        public bool Paid { get; set; }
        public int? NumberOfGuests { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventResponseType EventResponseType { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
{
    public void Configure(EntityTypeBuilder<EventRegistration> builder)
    {
 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventRegistration)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegistration_Event");

                builder.HasOne(d => d.EventResponseType)
                    .WithMany(p => p.EventRegistration)
                    .HasForeignKey(d => d.EventResponseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegistration_EventResponseType");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.EventRegistration)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRegistration_Member");
    }

}
public static partial class Seeder
{
    public static void SeedEventRegistration(this ModelBuilder modelBuilder)
    {

    }
}
}
