using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PlanDetail
    {
        public PlanDetail()
        {
            MemberPlanHistory = new HashSet<MemberPlanHistory>();
        }

        public int Id { get; set; }
        public int PlanMasterId { get; set; }
        public int CurrencyId { get; set; }
        public int PlanFrequencyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual PlanFrequency PlanFrequency { get; set; }
        public virtual PlanMaster PlanMaster { get; set; }
        public virtual ICollection<MemberPlanHistory> MemberPlanHistory { get; set; }
    }

    public partial class PlanDetailConfiguration : IEntityTypeConfiguration<PlanDetail>
    {
        public void Configure(EntityTypeBuilder<PlanDetail> builder)
        {

   builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Currency)
                    .WithMany(p => p.PlanDetail)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanDetail_Currency");

                builder.HasOne(d => d.PlanFrequency)
                    .WithMany(p => p.PlanDetail)
                    .HasForeignKey(d => d.PlanFrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanDetail_PlanFrequency");

                builder.HasOne(d => d.PlanMaster)
                    .WithMany(p => p.PlanDetail)
                    .HasForeignKey(d => d.PlanMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanDetail_PlanMaster");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPlanDetail(this ModelBuilder modelBuilder)
        {

        }
    }
}
