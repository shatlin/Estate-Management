using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PromotionDetail
    {
        public PromotionDetail()
        {
            Donation = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public int PromotionMasterId { get; set; }
        public int? MembershipGradeId { get; set; }
        public int? MemberLevelId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberLevel MemberLevel { get; set; }
        public virtual MemberShipGrade MembershipGrade { get; set; }
        public virtual PromotionMaster PromotionMaster { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
    }


    public partial class PromotionDetailConfiguration : IEntityTypeConfiguration<PromotionDetail>
    {
        public void Configure(EntityTypeBuilder<PromotionDetail> builder)
        {
builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.DiscountPercentage).HasColumnType("decimal(9, 3)");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.MemberLevel)
                    .WithMany(p => p.PromotionDetail)
                    .HasForeignKey(d => d.MemberLevelId)
                    .HasConstraintName("FK_PromotionDetail_MemberLevel");

                builder.HasOne(d => d.MembershipGrade)
                    .WithMany(p => p.PromotionDetail)
                    .HasForeignKey(d => d.MembershipGradeId)
                    .HasConstraintName("FK_PromotionDetail_MembershipGrade");

                builder.HasOne(d => d.PromotionMaster)
                    .WithMany(p => p.PromotionDetail)
                    .HasForeignKey(d => d.PromotionMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionDetail_PromotionMaster");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPromotionDetail(this ModelBuilder modelBuilder)
        {

        }
    }
}
