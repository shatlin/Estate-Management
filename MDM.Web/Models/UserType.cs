using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<ApplicationUser> User { get; set; }
    }


    public partial class UserTypeConfiguration: IEntityTypeConfiguration<UserType>
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
                new UserType { Id = 1, Name = "Admin", Description = "Admin", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new UserType { Id = 2, Name = "Member", Description = "Member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new UserType { Id = 3, Name = "Contact", Description = "Contact", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                 );

        }
    }
}
