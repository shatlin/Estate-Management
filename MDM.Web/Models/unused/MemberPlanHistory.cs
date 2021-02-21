using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberPlanHistory
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? OrganizationId { get; set; }
        public int MemberPlanDetailId { get; set; }
        public bool IsCurrentPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberUser Member { get; set; }
        public virtual PlanDetail MemberPlanDetail { get; set; }
        public virtual PlanMaster MemberPlanDetailNavigation { get; set; }
        public virtual Organization Organization { get; set; }
    }

    public partial class MemberPlanHistoryConfiguration : IEntityTypeConfiguration<MemberPlanHistory>
    {
        public void Configure(EntityTypeBuilder<MemberPlanHistory> builder)
        {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.EndDate).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Notes).HasMaxLength(1000);

                builder.Property(e => e.StartDate).HasColumnType("datetime");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MemberPlanHistory)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_MembershipHistory_Member");

                builder.HasOne(d => d.MemberPlanDetail)
                    .WithMany(p => p.MemberPlanHistory)
                    .HasForeignKey(d => d.MemberPlanDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberPlanHistory_PlanDetail");

                builder.HasOne(d => d.MemberPlanDetailNavigation)
                    .WithMany(p => p.MemberPlanHistory)
                    .HasForeignKey(d => d.MemberPlanDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembershipHistory_PlanMaster");

                builder.HasOne(d => d.Organization)
                    .WithMany(p => p.MemberPlanHistory)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_MembershipHistory_Organization");
        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberPlanHistory(this ModelBuilder modelBuilder)
        {

        }
    }
}

