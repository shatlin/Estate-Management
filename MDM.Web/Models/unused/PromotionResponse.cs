using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PromotionResponse
    {
        public int Id { get; set; }
        public int PromotionMasterId { get; set; }
        public int MemberId { get; set; }
        public int PromotionResponseType { get; set; }
        public DateTime ResponseDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberUser Member { get; set; }
        public virtual PromotionMaster PromotionMaster { get; set; }
        public virtual PromotionResponseType PromotionResponseTypeNavigation { get; set; }
    }
    public partial class PromotionResponseConfiguration : IEntityTypeConfiguration<PromotionResponse>
    {
        public void Configure(EntityTypeBuilder<PromotionResponse> builder)
        {
   builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.ResponseDate).HasColumnType("datetime");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.PromotionResponse)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionResponse_Member");

                builder.HasOne(d => d.PromotionMaster)
                    .WithMany(p => p.PromotionResponse)
                    .HasForeignKey(d => d.PromotionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionResponse_PromotionMaster");

                builder.HasOne(d => d.PromotionResponseTypeNavigation)
                    .WithMany(p => p.PromotionResponse)
                    .HasForeignKey(d => d.PromotionResponseType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionResponse_PromotionResponseType");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPromotionResponse(this ModelBuilder modelBuilder)
        {

        }
    }
}
