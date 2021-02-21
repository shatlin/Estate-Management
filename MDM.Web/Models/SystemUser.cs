using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Models
{
    public partial class SystemUser
    {
        public SystemUser()
        {
            TaskItemAssignee = new HashSet<TaskItemAssignee>();
            Board = new HashSet<Board>();
            ServiceProviderTrusteeApproval = new HashSet<ServiceProviderTrusteeApproval>();
            TaskItemFile = new HashSet<TaskItemFile>();
            TaskItemComment = new HashSet<TaskItemComment>();
        }

        public virtual ICollection<Board> Board { get; set; }
        public virtual ICollection<TaskItemAssignee> TaskItemAssignee { get; set; }
        public virtual ICollection<ServiceProviderTrusteeApproval> ServiceProviderTrusteeApproval { get; set; }
        public virtual ICollection<TaskItemFile> TaskItemFile { get; set; }
        public virtual ICollection<TaskItemComment> TaskItemComment { get; set; }
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public string ApplicaitonUserId { get; set; }

        [Display(Name = "Home Language", Prompt = "Enter Home Language")]
        [Required(ErrorMessage = "Home Language is required")]
        public int? HomeLanguageId { get; set; }
        public virtual Language HomeLanguage { get; set; }


        [Display(Name = "Ethnicity", Prompt = "Select Ethnicity")]
        [Required(ErrorMessage = "Ethnicity is required")]
        public int? EthnicityId { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }

        [Display(Name = "Occupation", Prompt = "Select Occupation")]
        [Required(ErrorMessage = "Occupation is required")]
        public int? OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }


        [Display(Name = "Initials", Prompt = "Enter Initials")]
        //[Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }

        [Display(Name = "Mobile Phone", Prompt = "Enter Mobile Phone")]
        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }

        [Display(Name = "Notes", Prompt = "Enter Notes")]
        //[Required(ErrorMessage = "Business Phone Number is required")]
        public string Notes { get; set; }

        [Display(Name = "Term Accepted")]
        [Required(ErrorMessage = "Please accept the Terms, to proceed")]
        public bool? TermAccepted { get; set; }

        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }

        public byte[] Photo { get; set; }

        [Display(Name = "ID/Passport Number", Prompt = "Enter ID Number")]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }

        public bool? IsAdminCreated { get; set; }
        [Display(Name = "Date of Birth", Prompt = "Enter Birthday")]
        // [Required(ErrorMessage = "Birth Day is required")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int? GenderId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public int? TitleId { get; set; }


        public virtual Gender Gender { get; set; }
        public virtual Title Title { get; set; }
       

    }


    public partial class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {

            builder.Property(e => e.GenderId)
              .IsRequired(false);

            builder.Property(e => e.TitleId)
              .IsRequired(false);


            builder.Property(e => e.IsAdminCreated)
                .IsRequired(false);

            builder.Property(e => e.BirthDay).IsRequired(false).HasColumnType("datetime");

            builder.Property(e => e.Photo).HasColumnType("blob");

            builder.HasOne(d => d.Gender)
                .WithMany(p => p.SystemUser)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Gender");

            builder.HasOne(d => d.Title)
                .WithMany(p => p.SystemUser)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Title");



            builder.Property(e => e.HomeLanguageId).IsRequired(false);

            builder.Property(e => e.EthnicityId).IsRequired(false);

            builder.Property(e => e.OccupationId).IsRequired(false);



            builder.Property(e => e.IDNumber)
        .IsRequired(false).HasMaxLength(100);




            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

         



            builder.HasOne(d => d.HomeLanguage)
      .WithMany(p => p.SystemUser)
      .HasForeignKey(d => d.HomeLanguageId)
       .OnDelete(DeleteBehavior.ClientSetNull)
      .HasConstraintName("FK_Member_Language");


            builder.HasOne(d => d.Ethnicity)
           .WithMany(p => p.SystemUser)
           .HasForeignKey(d => d.EthnicityId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_Ethnicity");

            builder.HasOne(d => d.Occupation)
           .WithMany(p => p.SystemUser)
           .HasForeignKey(d => d.OccupationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_Occupation");


        }


    }

}
