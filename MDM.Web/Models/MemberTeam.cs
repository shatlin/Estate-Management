using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberTeam
    {
        public MemberTeam()
        {
            CpdmemberTeamSetUp = new HashSet<CpdmemberTeamSetUp>();
            EventRestrictionList = new HashSet<EventRestrictionList>();
            Member = new HashSet<MemberUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<CpdmemberTeamSetUp> CpdmemberTeamSetUp { get; set; }
        public virtual ICollection<EventRestrictionList> EventRestrictionList { get; set; }
        public virtual ICollection<MemberUser> Member { get; set; }
    }


    public partial class MemberTeamConfiguration : IEntityTypeConfiguration<MemberTeam>
    {
        public void Configure(EntityTypeBuilder<MemberTeam> builder)
        {
    builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberTeam(this ModelBuilder modelBuilder)
        {

        }
    }
}

