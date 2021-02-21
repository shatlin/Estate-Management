using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class Business
    {
        public Business()
        {
            Organization = new HashSet<Organization>();
            OrganizationBusinessXref = new HashSet<OrganizationBusinessXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<OrganizationBusinessXref> OrganizationBusinessXref { get; set; }
    }


    public partial class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(200);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
        }

    }

    public static partial class Seeder
    {
        public static void SeedBusiness(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().HasData(
                new Business { Id = 1, Name = "Consultants", Description = "Consultants", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Business { Id = 2, Name = "Groundwater Management", Description = "Groundwater Management", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Business { Id = 3, Name = "Laboratory Services", Description = "Laboratory Services", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Business { Id = 4, Name = "Research and Development", Description = "Research and Development", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Business { Id = 5, Name = "Water Infrastructure", Description = "Water Infrastructure", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Business { Id = 6, Name = "Water /Waste Water Management", Description = "Water /Waste Water Management", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                 new Business { Id = 7, Name = "Industrial Mine Waer Management", Description = "Industrial Mine Waer Management", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
               );








        }
    }
}

