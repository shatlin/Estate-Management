using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberCommunicationPreference
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CommunicationTypeId { get; set; }
        public TimeSpan? PreferredTimeFrom { get; set; }
        public TimeSpan? PreferredTimeTo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual CommunicationType CommunicationType { get; set; }
        public virtual MemberUser Member { get; set; }
    }
    public partial class MemberCommunicationPreferenceConfiguration : IEntityTypeConfiguration<MemberCommunicationPreference>
    {
        public void Configure(EntityTypeBuilder<MemberCommunicationPreference> builder)
        {
 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.CommunicationType)
                    .WithMany(p => p.MemberCommunicationPreference)
                    .HasForeignKey(d => d.CommunicationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberCommunicationPreference_CommunicationType");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MemberCommunicationPreference)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberCommunicationPreference_Member");
        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberCommunicationPreference(this ModelBuilder modelBuilder)
        {

        }
    }
}
