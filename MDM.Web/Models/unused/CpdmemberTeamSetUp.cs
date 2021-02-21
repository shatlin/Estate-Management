using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CpdmemberTeamSetUp
    {
        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public int RelatedRecordId { get; set; }
        public int? MemberTeamId { get; set; }
        public int Cpdcount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberTeam MemberTeam { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }

    public partial class CpdmemberTeamSetUpConfiguration : IEntityTypeConfiguration<CpdmemberTeamSetUp>
    {
        public void Configure(EntityTypeBuilder<CpdmemberTeamSetUp> builder)
        {
builder.ToTable("CPDMemberTeamSetUp");

                builder.Property(e => e.Cpdcount).HasColumnName("CPDCount");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.MemberTeam)
                    .WithMany(p => p.CpdmemberTeamSetUp)
                    .HasForeignKey(d => d.MemberTeamId)
                    .HasConstraintName("FK_CPDMemberTeamSetUp_MemberTeam");

                builder.HasOne(d => d.RelatedTo)
                    .WithMany(p => p.CpdmemberTeamSetUp)
                    .HasForeignKey(d => d.RelatedToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPDMemberTeamSetUp_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedCpdmemberTeamSetUp(this ModelBuilder modelBuilder)
        {

        }
    }
}

