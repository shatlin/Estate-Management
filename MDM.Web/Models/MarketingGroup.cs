using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MarketingGroup
    {
        public MarketingGroup()
        {
            MarketingGroupXref = new HashSet<MarketingGroupXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MarketingGroupXref> MarketingGroupXref { get; set; }
    }

public partial class MarketingGroupConfiguration : IEntityTypeConfiguration<MarketingGroup>
{
    public void Configure(EntityTypeBuilder<MarketingGroup> builder)
    {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
    }

}
public static partial class Seeder
{
    public static void SeedMarketingGroup(this ModelBuilder modelBuilder)
    {

    }
}
}
