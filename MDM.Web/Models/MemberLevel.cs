using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberLevel
    {
        public MemberLevel()
        {
            CpdmemberLevelSetUp = new HashSet<CpdmemberLevelSetUp>();
            EventRestrictionList = new HashSet<EventRestrictionList>();
            Member = new HashSet<MemberUser>();
             Organization = new HashSet<Organization>();
            PromotionDetail = new HashSet<PromotionDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<CpdmemberLevelSetUp> CpdmemberLevelSetUp { get; set; }
        public virtual ICollection<EventRestrictionList> EventRestrictionList { get; set; }
        public virtual ICollection<MemberUser> Member { get; set; }
         public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<PromotionDetail> PromotionDetail { get; set; }
    }
    public partial class MemberLevelConfiguration : IEntityTypeConfiguration<MemberLevel>
    {
        public void Configure(EntityTypeBuilder<MemberLevel> builder)
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
        public static void SeedMemberLevel(this ModelBuilder modelBuilder)
        {

        }
    }
}

