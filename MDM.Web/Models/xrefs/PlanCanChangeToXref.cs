using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PlanCanChangeToXref
    {
        public int Id { get; set; }
        public int FromPlanMasterId { get; set; }
        public int ToPlanMasterId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual PlanMaster FromPlanMaster { get; set; }
        public virtual PlanMaster ToPlanMaster { get; set; }
    }


    public partial class PlanCanChangeToXrefConfiguration : IEntityTypeConfiguration<PlanCanChangeToXref>
    {
        public void Configure(EntityTypeBuilder<PlanCanChangeToXref> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.FromPlanMaster)
                .WithMany(p => p.PlanCanChangeToXrefFromPlanMaster)
                .HasForeignKey(d => d.FromPlanMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberPlanCanChangeTo_PlanMaster");

            builder.HasOne(d => d.ToPlanMaster)
                .WithMany(p => p.PlanCanChangeToXrefToPlanMaster)
                .HasForeignKey(d => d.ToPlanMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberPlanCanChangeTo_PlanMaster2");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPlanCanChangeToXref(this ModelBuilder modelBuilder)
        {

        }
    }
}

