using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class Title
    {
        public Title()
        {
            SystemUser = new HashSet<SystemUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<SystemUser> SystemUser { get; set; }
    }

    public partial class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

        }


    }

    public static partial class Seeder
    {
        public static void SeedTitle(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>().HasData(
                new Title { Id = 1, Name = "Mr", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Title { Id = 2, Name = "Mrs", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Title { Id = 3, Name = "Ms", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Title { Id = 4, Name = "Dr", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Title { Id = 5, Name = "Prof", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
             
              );
        }
    }
}
