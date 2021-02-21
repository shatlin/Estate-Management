using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Donation
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int? PromotionDetailId { get; set; }
        public DateTime DonatedOn { get; set; }
        public string DonorNotes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberUser Member { get; set; }
        public virtual PromotionDetail PromotionDetail { get; set; }
    }
    public partial class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.DonatedOn).HasColumnType("datetime");

                builder.Property(e => e.DonorNotes)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.Donation)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donation_Member");

                builder.HasOne(d => d.PromotionDetail)
                    .WithMany(p => p.Donation)
                    .HasForeignKey(d => d.PromotionDetailId)
                    .HasConstraintName("FK_Donation_PromotionDetail");
        }

    }
    public static partial class Seeder
    {
        public static void SeedDonation(this ModelBuilder modelBuilder)
        {

        }
    }
}



