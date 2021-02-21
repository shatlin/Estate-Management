using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CpdMemberShipGradeSetUp
    {
        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public int RelatedRecordId { get; set; }
        public int? MembershipGradeId { get; set; }
        public int Cpdcount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberShipGrade MembershipGrade { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }

    public partial class CPDMembershipGradeSetUpConfiguration : IEntityTypeConfiguration<CpdMemberShipGradeSetUp>
    {
        public void Configure(EntityTypeBuilder<CpdMemberShipGradeSetUp> builder)
        {
  builder.ToTable("CPDMembershipGradeSetUp");

                builder.Property(e => e.Cpdcount).HasColumnName("CPDCount");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.MembershipGrade)
                    .WithMany(p => p.CPDMembershipGradeSetUp)
                    .HasForeignKey(d => d.MembershipGradeId)
                    .HasConstraintName("FK_CPDMembershipGradeSetUp_MembershipGrade");

                builder.HasOne(d => d.RelatedTo)
                    .WithMany(p => p.CPDMembershipGradeSetUp)
                    .HasForeignKey(d => d.RelatedToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPDMembershipGradeSetUp_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedCPDMembershipGradeSetUp(this ModelBuilder modelBuilder)
        {

        }
    }
}
