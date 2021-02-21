using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MarketingGroupXref
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int MarketingGroupId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MarketingGroup MarketingGroup { get; set; }
        public virtual MemberUser Member { get; set; }
    }


    public partial class MarketingGroupXrefConfiguration : IEntityTypeConfiguration<MarketingGroupXref>
    {
        public void Configure(EntityTypeBuilder<MarketingGroupXref> builder)
        {
 builder.ToTable("MarketingGroupXRef");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.MarketingGroup)
                    .WithMany(p => p.MarketingGroupXref)
                    .HasForeignKey(d => d.MarketingGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketingGroupXRef_MarketingGroup");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MarketingGroupXref)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketingGroupXRef_Member");
        }

    }
    public static partial class Seeder
    {
        public static void SeedMarketingGroupXref(this ModelBuilder modelBuilder)
        {

        }
    }
}
