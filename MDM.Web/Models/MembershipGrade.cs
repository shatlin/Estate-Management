using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace MM.ClientModels
{
    //This is same as membership Grade
    public partial class MemberShipGrade
    {
        public MemberShipGrade()
        {
            CPDMembershipGradeSetUp = new HashSet<CpdMemberShipGradeSetUp>();
            LandingPage = new HashSet<LandingPage>();
            MemberUser = new HashSet<MemberUser>();
            Organization = new HashSet<Organization>();
            PromotionDetail = new HashSet<PromotionDetail>();
            IndividualMemberShipHistory = new HashSet<IndividualMemberShipHistory>();
        }

        public int Id { get; set; }

        public int IndividualOrNonIndividualId { get; set; } // Individual is 1 non individual is 2

        [Display(Name = "MemberShip Grade Name", Prompt = "Please enter MemberShip Grade Name")]
        [Required(ErrorMessage = " MemberShip Grade Type Name is required")]
        public string Name { get; set; }

        [Display(Name = "MemberShip Grade Description", Prompt = "Please enter MemberShip Grade Description")]
        [Required(ErrorMessage = "MemberShip Grade Description is required")]
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<CpdMemberShipGradeSetUp> CPDMembershipGradeSetUp { get; set; }
        public virtual ICollection<LandingPage> LandingPage { get; set; }
        public virtual ICollection<MemberUser> MemberUser { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<PromotionDetail> PromotionDetail { get; set; }

        public virtual ICollection<IndividualMemberShipHistory> IndividualMemberShipHistory { get; set; }
    }


    public partial class MembershipGradeConfiguration : IEntityTypeConfiguration<MemberShipGrade>
    {
        public void Configure(EntityTypeBuilder<MemberShipGrade> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
    public static partial class Seeder
    {
        public static void SeedMembershipGrade(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberShipGrade>().HasData(
                new MemberShipGrade { Id = 1, Name = "Professional Process Controller", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 2, Name = "Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 3, Name = "Affiliate", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 4, Name = "Associate Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 5, Name = "Academic Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 6, Name = "Fellow", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 7, Name = "Senior Fellow", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 8, Name = "Student Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 9, Name = "Free Retired", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 10, Name = "Honorary Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 11, Name = "Media Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 12, Name = "Retired Fellow", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 13, Name = "Retired Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 14, Name = "Retired Sen. Fellow", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 15, Name = "Company Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 16, Name = "Educational Institutions", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 17, Name = "Patron Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 18, Name = "Professional Members Association", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 19, Name = "Non-Individual Member", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 20, Name = "Local Authority", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 21, Name = "Municipality", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new MemberShipGrade { Id = 22, Name = "Contact", Description = "", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }


          );
        }
    }
}
