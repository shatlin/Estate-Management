using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventEquipment
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int EquipmentId { get; set; }
        public int RequiredCount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Event Event { get; set; }
    }

    public partial class EventEquipmentConfiguration : IEntityTypeConfiguration<EventEquipment>
    {
        public void Configure(EntityTypeBuilder<EventEquipment> builder)
        {
builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Equipment)
                    .WithMany(p => p.EventEquipment)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventEquipmentRequirement_Equipment");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventEquipment)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventEquipmentRequirement_Event");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEventEquipment(this ModelBuilder modelBuilder)
        {

        }
    }
}
