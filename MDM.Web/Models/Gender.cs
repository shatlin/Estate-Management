using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class Gender : BaseModel
    {
        public Gender()
        {
            SystemUser = new HashSet<SystemUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public virtual ICollection<SystemUser> SystemUser { get; set; }
    }
    public partial class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
    builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedGender(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, Name = "Male", Description = "Male", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
             new Gender { Id = 2, Name = "Female", Description = "Female", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
             new Gender { Id = 3, Name = "Other", Description = "Other", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
              
           );
           
        }
    }
}

