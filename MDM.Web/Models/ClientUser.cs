using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class ClientUser
    {
        public ClientUser()
        {
            ClientPlanHistory = new HashSet<ClientPlanHistory>();
            Cpd = new HashSet<Cpd>();
            Event = new HashSet<Event>();
            EventRoleUserXref = new HashSet<EventRoleUserXref>();
            UserRoleXref = new HashSet<UserRoleXref>();
            ContactUs = new HashSet<ContactUs>();
          
          MemberUser = new HashSet<MemberUser>();
        }

        public int Id { get; set; }
        public string ApplicaitonUserId { get; set; }
        public bool PrimaryContact { get; set; }
        public bool BillingContact { get; set; }
        public int? DesignationId { get; set; }
        public int? ReferralTypeId { get; set; }
        public string Notes { get; set; }
        public bool IsInternalUser { get; set; }
        public bool TermsAccepted { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual ReferralType ReferralType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ClientPlanHistory> ClientPlanHistory { get; set; }
        public virtual ICollection<ContactUs> ContactUs { get; set; }
        public virtual ICollection<Cpd> Cpd { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<EventRoleUserXref> EventRoleUserXref { get; set; }
        public virtual ICollection<UserRoleXref> UserRoleXref { get; set; }
           public virtual ICollection<MemberUser> MemberUser { get; set; }
    }

    public partial class ClientUserConfiguration : IEntityTypeConfiguration<ClientUser>
    {
        public void Configure(EntityTypeBuilder<ClientUser> builder)
        {

            builder.Property(e => e.ApplicaitonUserId)
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Notes)
                   .IsRequired(false)
                   .HasMaxLength(1000);

            builder.HasOne(d => d.Designation)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK_User_Designation");

            builder.HasOne(d => d.ReferralType)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.ReferralTypeId)
                .HasConstraintName("FK_User_ReferralType");

            builder.HasOne(d => d.ApplicationUser)
               .WithMany(p => p.ClientUser)
               .HasForeignKey(d => d.ApplicaitonUserId)
               .HasConstraintName("FK_Member_ClientUser");

           

        }
    }
    public static partial class Seeder
    {
        public static void SeedClientUser(this ModelBuilder modelBuilder)
        {
        }
    }

}
