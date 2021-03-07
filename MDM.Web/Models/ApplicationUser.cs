using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Models
{

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string Photo { get; set; }


        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }


       



        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
            set { }
        }






        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }


    }

    public partial class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FirstName).IsRequired(true).HasMaxLength(100);

            builder.Property(e => e.LastName).IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.Photo).IsRequired(false).HasMaxLength(700);

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
           

            builder.HasOne(d => d.UserType).WithMany(p => p.ApplicationUser).HasForeignKey(d => d.UserTypeId).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_User_UserType");
        }


    }

}
