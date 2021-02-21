using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventCost
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int EventCostItemId { get; set; }
        public bool IsActive { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventCostItem EventCostItem { get; set; }

    }


public partial class EventCostConfiguration : IEntityTypeConfiguration<EventCost>
{
    public void Configure(EntityTypeBuilder<EventCost> builder)
    {
 builder.Property(e => e.Amount).HasColumnType("decimal(10, 3)");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
    }

}
public static partial class Seeder
{
    public static void SeedEventCost(this ModelBuilder modelBuilder)
    {

    }
}
}
