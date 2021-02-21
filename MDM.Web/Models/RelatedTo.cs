using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class RelatedTo
    {
        public RelatedTo()
        {
            Billing = new HashSet<Billing>();
            Cpd = new HashSet<Cpd>();
            CPDMembershipTypeSetUp = new HashSet<CpdmembershipTypeSetUp>();
            CpdmemberLevelSetUp = new HashSet<CpdmemberLevelSetUp>();
            CpdmemberTeamSetUp = new HashSet<CpdmemberTeamSetUp>();
            CPDMembershipGradeSetUp = new HashSet<CpdMemberShipGradeSetUp>();
            Invoice = new HashSet<Invoice>();
            Refund = new HashSet<Refund>();
            Address = new HashSet<Address>();
            MemberNotesXref = new HashSet<MemberNotesXref>();
            MemberFileXref = new HashSet<MemberFileXref>();
            MemberEmailXref = new HashSet<MemberEmailXref>();
            MemberRefereeXref = new HashSet<MemberRefereeXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<Cpd> Cpd { get; set; }
        public virtual ICollection<CpdmembershipTypeSetUp> CPDMembershipTypeSetUp { get; set; }
        public virtual ICollection<CpdmemberLevelSetUp> CpdmemberLevelSetUp { get; set; }
        public virtual ICollection<CpdmemberTeamSetUp> CpdmemberTeamSetUp { get; set; }
        public virtual ICollection<CpdMemberShipGradeSetUp> CPDMembershipGradeSetUp { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }
        public virtual ICollection<MemberNotesXref> MemberNotesXref { get; set; }
        public virtual ICollection<MemberFileXref> MemberFileXref { get; set; }
        public virtual ICollection<MemberEmailXref> MemberEmailXref { get; set; }
        public virtual ICollection<MemberRefereeXref> MemberRefereeXref { get; set; }

    }
    public partial class RelatedToConfiguration : IEntityTypeConfiguration<RelatedTo>
    {
        public void Configure(EntityTypeBuilder<RelatedTo> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(30);
        }
    }
    public static partial class Seeder
    {
        public static void SeedRelatedTo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatedTo>().HasData(
                    new RelatedTo { Id = 1, Name = "Member", Description = "Member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new RelatedTo { Id = 2, Name = "Organization", Description = "Organization", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new RelatedTo { Id = 3, Name = "Event", Description = "Event", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new RelatedTo { Id = 4, Name = "CPD", Description = "CPD", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new RelatedTo { Id = 5, Name = "Contact", Description = "Contact", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new RelatedTo { Id = 6, Name = "Staff", Description = "Staff", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new RelatedTo { Id = 7, Name = "Note", Description = "Note", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                    );
        }
    }
}
