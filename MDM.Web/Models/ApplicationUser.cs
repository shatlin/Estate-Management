using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ClientUser = new HashSet<ClientUser>();
            MemberUser = new HashSet<MemberUser>();
        }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name", Prompt = "Enter Middle Name")]
        //[Required(ErrorMessage = "Middle Name is required")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
            set { }
        }

        [Display(Name = "Date of Birth", Prompt = "Enter Birthday")]
        // [Required(ErrorMessage = "Birth Day is required")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int? GenderId { get; set; }



        public override string NormalizedEmail { get; set; }
        public override string NormalizedUserName { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public int? TitleId { get; set; }
        public int UserTypeId { get; set; }

        [NotMapped]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }

        public bool? IsAdminCreated { get; set; }

        public bool? IsActive { get; set; }


        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Pwd", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPwd { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Title Title { get; set; }
        public virtual UserType UserType { get; set; }

        public virtual ICollection<ClientUser> ClientUser { get; set; }
        public virtual ICollection<MemberUser> MemberUser { get; set; }
    }

    public partial class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {



            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.GenderId)
              .IsRequired(false);
            
            builder.Property(e => e.TitleId)
              .IsRequired(false);
             

            builder.Property(e => e.IsAdminCreated)
                .IsRequired(false);

            builder.Property(e => e.NormalizedUserName)
              .HasMaxLength(100);

            builder.Property(e => e.NormalizedEmail)
              .HasMaxLength(100);

            builder.Property(e => e.MiddleName)
                 .IsRequired(false)
                 .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.BirthDay).IsRequired(false).HasColumnType("datetime");

            builder.HasOne(d => d.Gender)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Gender");

            builder.HasOne(d => d.Title)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Title");

            builder.HasOne(d => d.UserType)
               .WithMany(p => p.User)
               .HasForeignKey(d => d.UserTypeId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_User_UserType");
        }


    }
}
