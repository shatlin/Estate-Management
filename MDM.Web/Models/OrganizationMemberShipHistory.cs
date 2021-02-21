using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class OrganizationMemberShipHistory
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }

        public bool IsActive { get; set; }
        public int? MemberShipChangeReasonId { get; set; }
        public virtual MemberShipChangeReason MemberShipChangeReason { get; set; }



        public int? OrganizationTypeId { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }

        public int? OrganizationGradeId { get; set; }
        public virtual OrganizationGrade OrganizationGrade { get; set; }
        public bool IsCurrentPlan { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Organization Organization { get; set; }

    }

    public partial class OrganizationMemberShipHistoryConfiguration : IEntityTypeConfiguration<OrganizationMemberShipHistory>
    {
        public void Configure(EntityTypeBuilder<OrganizationMemberShipHistory> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.EndDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Notes).HasMaxLength(1000);

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.HasOne(d => d.Organization)
                .WithMany(p => p.OrganizationMemberShipHistory)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_OrganizationMemberShipHistory_Organization");

            builder.HasOne(d => d.MemberShipChangeReason)
                .WithMany(p => p.OrganizationMemberShipHistory)
                .HasForeignKey(d => d.MemberShipChangeReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationMemberShipHistory_MemberShipChangeReason");

            builder.HasOne(d => d.OrganizationType)
              .WithMany(p => p.OrganizationMemberShipHistory)
              .HasForeignKey(d => d.OrganizationTypeId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_OrganizationMemberShipHistory_OrganizationType");

            builder.HasOne(d => d.OrganizationGrade)
              .WithMany(p => p.OrganizationMemberShipHistory)
              .HasForeignKey(d => d.OrganizationGradeId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_OrganizationMemberShipHistory_OrganizationGrade");

        }

    }
    public static partial class Seeder
    {
        public static void SeedOrganizationMemberShipHistory(this ModelBuilder modelBuilder)
        {

        }
    }
}

