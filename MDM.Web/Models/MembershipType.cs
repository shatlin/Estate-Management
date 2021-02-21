using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{

    public partial class MembershipType
    {
        public MembershipType()
        {
            CPDMembershipTypeSetUp = new HashSet<CpdmembershipTypeSetUp>();
            PlanMaster = new HashSet<PlanMaster>();
            MemberUser = new HashSet<MemberUser>();
            IndividualMemberShipHistory = new HashSet<IndividualMemberShipHistory>();
        }

        public int Id { get; set; }

        [Display(Name = "Membership Type", Prompt = "Select Membership Type")]
        //[Required(ErrorMessage = "Membership Type is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<CpdmembershipTypeSetUp> CPDMembershipTypeSetUp { get; set; }

        public virtual ICollection<PlanMaster> PlanMaster { get; set; }
        public virtual ICollection<MemberUser> MemberUser { get; set; }

        public virtual ICollection<IndividualMemberShipHistory> IndividualMemberShipHistory { get; set; }
    }
    public partial class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
    {
        public void Configure(EntityTypeBuilder<MembershipType> builder)
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
        public static void SeedMembershipType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>().HasData(
            new MembershipType { Id = 1, Name = "Individual Member", Description = "Individual Member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 2, Name = "Professional Process Controller", Description = "Professional Process Controller", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 3, Name = "Non Individual Member", Description = "Non Individual Member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 4, Name = "Non Members", Description = "Non Members", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 5, Name = "Primary Contact", Description = "Primary Contact", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 6, Name = "Billing Contact", Description = "Billing Contact", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 7, Name = "Contact Person", Description = "Contact Person", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new MembershipType { Id = 8, Name = "Additional Contacts", Description = "Additional Contacts", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
            );
        }
    }
}
