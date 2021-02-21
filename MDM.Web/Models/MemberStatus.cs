using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{
    public partial class MemberStatus
    {
        public MemberStatus()
        {
            MemberUser = new HashSet<MemberUser>();
            Organization = new HashSet<Organization>();
            IndividualMemberShipHistory = new HashSet<IndividualMemberShipHistory>();
            OrganizationMemberShipHistory = new HashSet<OrganizationMemberShipHistory>();
        }

        public int Id { get; set; }

        [Display(Name = "Membership Status", Prompt = "Select Membership Status")]
        //[Required(ErrorMessage = "Membership Status is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberUser> MemberUser { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<IndividualMemberShipHistory> IndividualMemberShipHistory { get; set; }
        public virtual ICollection<OrganizationMemberShipHistory> OrganizationMemberShipHistory { get; set; }
       
        
    }



    public partial class MemberStatusConfiguration : IEntityTypeConfiguration<MemberStatus>
    {
        public void Configure(EntityTypeBuilder<MemberStatus> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberStatus>().HasData(
               new MemberStatus { Id = 1, Name = "Application Cancelled", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberStatus { Id = 2, Name = "Applicant", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberStatus { Id = 3, Name = "Active", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberStatus { Id = 4, Name = "Deceased", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberStatus { Id = 5, Name = "Resigned", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberStatus { Id = 6, Name = "Cancelled", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new MemberStatus { Id = 7, Name = "Suspended", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
             
             );
        }
    }
}

