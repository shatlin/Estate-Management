using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MarketingProfileXref
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int MarketingProfileId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MarketingProfile MarketingProfile { get; set; }
        public virtual MemberUser Member { get; set; }
    }
    public partial class MarketingProfileXrefConfiguration : IEntityTypeConfiguration<MarketingProfileXref>
    {
        public void Configure(EntityTypeBuilder<MarketingProfileXref> builder)
        {
builder.ToTable("MarketingProfileXRef");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.MarketingProfile)
                    .WithMany(p => p.MarketingProfileXref)
                    .HasForeignKey(d => d.MarketingProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketingProfileXRef_MarketingProfile");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MarketingProfileXref)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketingProfileXRef_Member");
        }

    }
    public static partial class Seeder
    {
        public static void SeedMarketingProfileXref(this ModelBuilder modelBuilder)
        {

        }
    }
}