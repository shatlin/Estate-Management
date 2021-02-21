using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventRestrictionList
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int? MemberLevelId { get; set; }
        public int? MemberTeamId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Event Event { get; set; }
        public virtual MemberLevel MemberLevel { get; set; }
        public virtual MemberTeam MemberTeam { get; set; }
    }
    public partial class EventRestrictionListConfiguration : IEntityTypeConfiguration<EventRestrictionList>
    {
        public void Configure(EntityTypeBuilder<EventRestrictionList> builder)
        {

 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventRestrictionList)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRestrictionList_Event");

                builder.HasOne(d => d.MemberLevel)
                    .WithMany(p => p.EventRestrictionList)
                    .HasForeignKey(d => d.MemberLevelId)
                    .HasConstraintName("FK_EventRestrictionList_MemberLevel");

                builder.HasOne(d => d.MemberTeam)
                    .WithMany(p => p.EventRestrictionList)
                    .HasForeignKey(d => d.MemberTeamId)
                    .HasConstraintName("FK_EventRestrictionList_MemberTeam");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEventRestrictionList(this ModelBuilder modelBuilder)
        {

        }
    }
}