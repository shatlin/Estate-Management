using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Role
    {
        public Role()
        {
            EmailCcrule = new HashSet<EmailCcrule>();
            RolePermissionXref = new HashSet<RolePermissionXref>();
            User = new HashSet<ClientUser>();
            UserRoleXref = new HashSet<UserRoleXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<EmailCcrule> EmailCcrule { get; set; }
        public virtual ICollection<RolePermissionXref> RolePermissionXref { get; set; }
        public virtual ICollection<ClientUser> User { get; set; }
        public virtual ICollection<UserRoleXref> UserRoleXref { get; set; }
    }
    public partial class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "No administrative privileges", Description = "Select this option to remove admin access for existing administrators  ", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Role { Id = 2, Name = "Account administrator", Description = "Grants full access to all administrative functions. Take care when granting this level of access since full admins can delete other admins and even the entire site.", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Role { Id = 3, Name = "Account administrator (Read-only access)", Description = "Allows viewing of everything in the admin backend without being able to make any changes.  ", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Role { Id = 4, Name = "Limited administrator", Description = "Provides administrative access to selected Wild Apricot modules. Use this option if you have dedicated personnel in charge of events, memberships, editing webpages, or managing donations. With this option selected, you can limit access to selected Functions", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
            );
        }
    }
}
