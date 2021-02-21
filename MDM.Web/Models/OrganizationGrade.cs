using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class OrganizationGrade
    {
        public OrganizationGrade()
        {
            Organization = new HashSet<Organization>();
            OrganizationMemberShipHistory = new HashSet<OrganizationMemberShipHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Organization>Organization { get; set; }

        public virtual ICollection<OrganizationMemberShipHistory> OrganizationMemberShipHistory { get; set; }
    }


    public partial class OrganizationGradeConfiguration : IEntityTypeConfiguration<OrganizationGrade>
    {
        public void Configure(EntityTypeBuilder<OrganizationGrade> builder)
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
        public static void SeedOrganizationGrade(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationGrade>().HasData(
                new OrganizationGrade { Id = 1, Name = "Municipality", Description = "Association - Business / Trade", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationGrade { Id = 2, Name = "Company Member", Description = "Association - Chamber of commerce", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationGrade { Id = 3, Name = "Educational Institutions", Description = "Association - Community / HOA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationGrade { Id = 4, Name = "Media Member", Description = "Association - Professional", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationGrade { Id = 5, Name = "Patron Member", Description = "Association - Health", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new OrganizationGrade { Id = 6, Name = "Professional Members Association", Description = "Association - Business / Trade", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new OrganizationGrade { Id = 7, Name = "Water Board", Description = "Water Board", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                    new OrganizationGrade { Id = 8, Name = "Local Authority", Description = "Local Authority", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
               );

        





        }
    }
}

