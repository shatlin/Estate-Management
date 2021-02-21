using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermissionXref = new HashSet<RolePermissionXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<RolePermissionXref> RolePermissionXref { get; set; }
    }

public partial class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
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
    public static void SeedPermission(this ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Permission>().HasData(
            new Permission { Id = 1, Name = "Membership manager", Description = "Can create new contacts, modify all existing ones  ", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Permission { Id = 2, Name = "Event manager", Description = "Can create and manage all events", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Permission { Id = 3, Name = "Donations manager", Description = "Can manage all donations", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Permission { Id = 4, Name = "Newsletter manager", Description = "Can send manual emails (e.g. newsletters)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Permission { Id = 5, Name = "Website editor", Description = "Can modify your website pages. With this option selected, you can provide access to all pages on your site or to selected pages. When you grant access to a page, you automatically grant access to all of its child or sub pages.", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
            );
        }
}
}
