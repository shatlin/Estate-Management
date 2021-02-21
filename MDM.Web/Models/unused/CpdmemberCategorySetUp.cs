using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CpdmembershipTypeSetUp
    {
        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public int RelatedRecordId { get; set; }
        public int? MembershipTypeId { get; set; }
        public int Cpdcount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class CPDMembershipTypeSetUpConfiguration : IEntityTypeConfiguration<CpdmembershipTypeSetUp>
    {
        public void Configure(EntityTypeBuilder<CpdmembershipTypeSetUp> builder)
        {
            builder.ToTable("CPDMembershipTypeSetUp");

            builder.Property(e => e.Cpdcount).HasColumnName("CPDCount");

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.MembershipType)
                .WithMany(p => p.CPDMembershipTypeSetUp)
                .HasForeignKey(d => d.MembershipTypeId)
                .HasConstraintName("FK_CPDMembershipTypeSetUp_MembershipType");

            builder.HasOne(d => d.RelatedTo)
                .WithMany(p => p.CPDMembershipTypeSetUp)
                .HasForeignKey(d => d.RelatedToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPDMembershipTypeSetUp_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedCPDMembershipTypeSetUp(this ModelBuilder modelBuilder)
        {

        }
    }
}
