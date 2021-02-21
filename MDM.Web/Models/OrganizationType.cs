using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            Organization = new HashSet<Organization>();
            OrganizationMemberShipHistory = new HashSet<OrganizationMemberShipHistory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<OrganizationMemberShipHistory> OrganizationMemberShipHistory { get; set; }
    }
    public partial class OrganizationTypeConfiguration : IEntityTypeConfiguration<OrganizationType>
    {
        public void Configure(EntityTypeBuilder<OrganizationType> builder)
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
        public static void SeedOrganizationType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationType>().HasData(
                new OrganizationType { Id = 1, Name = "Private", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationType { Id = 2, Name = "Non-Individual Member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationType { Id = 3, Name = "Water Service Provider", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationType { Id = 4, Name = "Municipality", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationType { Id = 5, Name = "Professional Member Association", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationType { Id = 6, Name = "Government Department", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                 new OrganizationType { Id = 7, Name = "Educational Institution", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
               );



        }
    }
}

