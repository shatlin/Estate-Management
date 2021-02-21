using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class UserType
    {
        public UserType()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }


    public partial class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

        }


    }

    public static partial class Seeder
    {
        public static void SeedUserType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
                new UserType { Id = 1, Name = "Trustee", Description = "Trustee", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new UserType { Id = 2, Name = "Owner", Description = "Owner", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new UserType { Id = 3, Name = "Tenant", Description = "Tenant", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new UserType { Id = 4, Name = "Service Provider", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
                 );

        }
    }
}
