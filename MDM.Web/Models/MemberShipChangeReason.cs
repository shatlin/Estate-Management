using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{
    public partial class MemberShipChangeReason
    {
        public MemberShipChangeReason()
        {
           
            IndividualMemberShipHistory = new HashSet<IndividualMemberShipHistory>();
            OrganizationMemberShipHistory = new HashSet<OrganizationMemberShipHistory>();
        }

        public int Id { get; set; }

        [Display(Name = "Membership Change Reason", Prompt = "Select Membership Change Reason")]
        //[Required(ErrorMessage = "Membership Stat Reus is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<IndividualMemberShipHistory> IndividualMemberShipHistory { get; set; }
        public virtual ICollection<OrganizationMemberShipHistory> OrganizationMemberShipHistory { get; set; }


    }



    public partial class MemberShipChangeReasonConfiguration : IEntityTypeConfiguration<MemberShipChangeReason>
    {
        public void Configure(EntityTypeBuilder<MemberShipChangeReason> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberShipChangeReason(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberShipChangeReason>().HasData(
               new MemberShipChangeReason { Id = 1, Name = "Application Cancelled", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 2, Name = "Applicant", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 3, Name = "Active", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 4, Name = "Deceased", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 5, Name = "Resigned", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 6, Name = "Cancelled", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 7, Name = "Suspended – account in arrears", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 8, Name = "Suspended", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 9, Name = "Upgrade", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 10, Name = "Change", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 11, Name = "Inactive-Resigned", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 12, Name = "Inactive-Suspended", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberShipChangeReason { Id = 13, Name = "Inactive-Deceased", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
            
             );
        }
    }
}

