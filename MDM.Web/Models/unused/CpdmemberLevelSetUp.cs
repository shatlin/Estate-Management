using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CpdmemberLevelSetUp
    {
        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public int RelatedRecordId { get; set; }
        public int? MemberLevelId { get; set; }
        public int Cpdcount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberLevel MemberLevel { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class CpdmemberLevelSetUpConfiguration : IEntityTypeConfiguration<CpdmemberLevelSetUp>
    {
        public void Configure(EntityTypeBuilder<CpdmemberLevelSetUp> builder)
        {
            builder.ToTable("CPDMemberLevelSetUp");

            builder.Property(e => e.Cpdcount).HasColumnName("CPDCount");

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.MemberLevel)
                .WithMany(p => p.CpdmemberLevelSetUp)
                .HasForeignKey(d => d.MemberLevelId)
                .HasConstraintName("FK_CPDMemberLevelSetUp_MemberLevel");

            builder.HasOne(d => d.RelatedTo)
                .WithMany(p => p.CpdmemberLevelSetUp)
                .HasForeignKey(d => d.RelatedToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPDMemberLevelSetUp_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedCpdmemberLevelSetUp(this ModelBuilder modelBuilder)
        {

        }
    }
}
