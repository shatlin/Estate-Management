using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventAccess
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public bool? AdminOnly { get; set; }
        public bool? Anyone { get; set; }
        public bool? RestrictedList { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
    }
    public partial class EventAccessConfiguration : IEntityTypeConfiguration<EventAccess>
    {
        public void Configure(EntityTypeBuilder<EventAccess> builder)
        {
   builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventAccess)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAccess_Event");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEventAccess(this ModelBuilder modelBuilder)
        {

        }
    }
}
