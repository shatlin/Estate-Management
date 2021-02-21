using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class ClientOrganizationType
    {
        public ClientOrganizationType()
        {
            ClientOrganization = new HashSet<ClientOrganization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<ClientOrganization> ClientOrganization { get; set; }
    }


    public partial class ClientOrganizationTypeConfiguration : IEntityTypeConfiguration<ClientOrganizationType>
    {
        public void Configure(EntityTypeBuilder<ClientOrganizationType> builder)
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
        public static void SeedClientOrganizationType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientOrganizationType>().HasData(
                new ClientOrganizationType { Id = 1, Name = "Association - Business / Trade", Description = "Association - Business / Trade", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 2, Name = "Association - Chamber of commerce", Description = "Association - Chamber of commerce", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 3, Name = "Association - Community / HOA", Description = "Association - Community / HOA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 4, Name = "Association - Professional", Description = "Association - Professional", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 5, Name = "Association - Health", Description = "Association - Health", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 6, Name = "Association - Business / Trade", Description = "Association - Business / Trade", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 7, Name = "Association - Student/Alumni/PTA", Description = "Association - Student/Alumni/PTA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 8, Name = "Association - Teachers", Description = "Association - Teachers", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 9, Name = "Church or Religious Community", Description = "Church or Religious Community", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 10, Name = "Club - Service", Description = "Club - Service", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 11, Name = "Club - Special Interest or Social", Description = "Club - Special Interest or Social", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 12, Name = " COVID - 19", Description = " COVID - 19", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 13, Name = "Event / Conference", Description = "Event / Conference", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 14, Name = "Foundation or Charity", Description = "Foundation or Charity", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 15, Name = "Other(blank template)", Description = "Other(blank template)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 16, Name = "Political / Advocacy", Description = "Political / Advocacy", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 17, Name = "Subscription Site", Description = "Subscription Site", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ClientOrganizationType { Id = 18, Name = "Support / Assistance Services", Description = "Support / Assistance Services", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                 );

        }
    }
}

