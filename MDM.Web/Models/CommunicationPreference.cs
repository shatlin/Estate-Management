using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CommunicationPreference
    {
        public int Id { get; set; }
        public int CommunicationTypeId { get; set; }
        public TimeSpan? PreferredTimeFrom { get; set; }
        public TimeSpan? PreferredTimeTo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual CommunicationType CommunicationType { get; set; }
    }
    public partial class CommunicationPreferenceConfiguration : IEntityTypeConfiguration<CommunicationPreference>
    {
        public void Configure(EntityTypeBuilder<CommunicationPreference> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.CommunicationType)
                .WithMany(p => p.CommunicationPreference)
                .HasForeignKey(d => d.CommunicationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunicationPreference_CommunicationType");
        }

    }
    public static partial class Seeder
    {
        public static void SeedCommunicationPreference(this ModelBuilder modelBuilder)
        {

        }
    }
}
