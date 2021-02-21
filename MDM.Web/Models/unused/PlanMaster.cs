using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PlanMaster
    {
        public PlanMaster()
        {
            MemberPlanHistory = new HashSet<MemberPlanHistory>();
            PlanCanChangeToXrefFromPlanMaster = new HashSet<PlanCanChangeToXref>();
            PlanCanChangeToXrefToPlanMaster = new HashSet<PlanCanChangeToXref>();
            PlanDetail = new HashSet<PlanDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MembershipTypeId { get; set; }
        public bool? IsLimited { get; set; }
        public int? LimitToMemberCount { get; set; }
        public bool ApplyTaxSettings { get; set; }
        public int PaymentMethodId { get; set; }
        public bool CanPublicApply { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual PaymentSetting PaymentMethod { get; set; }
        public virtual ICollection<MemberPlanHistory> MemberPlanHistory { get; set; }
        public virtual ICollection<PlanCanChangeToXref> PlanCanChangeToXrefFromPlanMaster { get; set; }
        public virtual ICollection<PlanCanChangeToXref> PlanCanChangeToXrefToPlanMaster { get; set; }
        public virtual ICollection<PlanDetail> PlanDetail { get; set; }
    }

    public partial class PlanMasterConfiguration : IEntityTypeConfiguration<PlanMaster>
    {
        public void Configure(EntityTypeBuilder<PlanMaster> builder)
        {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);

                builder.HasOne(d => d.MembershipType)
                    .WithMany(p => p.PlanMaster)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanMaster_MembershipType");

                builder.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.PlanMaster)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanMaster_PaymentSetting");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPlanMaster(this ModelBuilder modelBuilder)
        {

        }
    }
}
