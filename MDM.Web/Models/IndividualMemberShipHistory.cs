using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class IndividualMemberShipHistory
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? MemberId { get; set; }
        public virtual MemberUser Member { get; set; }

        public int? MemberShipChangeReasonId { get; set; }
        public virtual MemberShipChangeReason MemberShipChangeReason { get; set; }


        public int? MembershipTypeId { get; set; }
        public virtual MembershipType MembershipType { get; set; }

        public int? MemberShipGradeId { get; set; }
        public virtual MemberShipGrade MemberShipGrade { get; set; }

        public bool IsCurrentPlan { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }




    }

    public partial class IndividualMemberShipHistoryConfiguration : IEntityTypeConfiguration<IndividualMemberShipHistory>
    {
        public void Configure(EntityTypeBuilder<IndividualMemberShipHistory> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.EndDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Notes).HasMaxLength(1000);

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.HasOne(d => d.Member)
                .WithMany(p => p.IndividualMemberShipHistory)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_IndividualMemberShipHistory_Member");

            builder.HasOne(d => d.MemberShipChangeReason)
                .WithMany(p => p.IndividualMemberShipHistory)
                .HasForeignKey(d => d.MemberShipChangeReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IndividualMemberShipHistory_MemberShipChangeReason");

            builder.HasOne(d => d.MembershipType)
             .WithMany(p => p.IndividualMemberShipHistory)
             .HasForeignKey(d => d.MembershipTypeId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_IndividualMemberShipHistory_MembershipType");

            builder.HasOne(d => d.MemberShipGrade)
              .WithMany(p => p.IndividualMemberShipHistory)
              .HasForeignKey(d => d.MemberShipGradeId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_IndividualMemberShipHistory_MembershipGrade");

        }

    }
    public static partial class Seeder
    {
        public static void SeedIndividualMemberShipHistory(this ModelBuilder modelBuilder)
        {

        }
    }
}

