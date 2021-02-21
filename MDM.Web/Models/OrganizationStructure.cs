using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class OrganizationStructure
    {
        public OrganizationStructure()
        {
            Member = new HashSet<MemberUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LevelOfMember { get; set; }
        public int MaximumNumber { get; set; }
        public int? MaximumTimeInYears { get; set; }
        public bool? ShowMaximumTimeInYears { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberUser> Member { get; set; }
    }
    public partial class OrganizationStructureConfiguration : IEntityTypeConfiguration<OrganizationStructure>
    {
        public void Configure(EntityTypeBuilder<OrganizationStructure> builder)
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
        public static void SeedOrganizationStructure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationStructure>().HasData(

                           new OrganizationStructure { Id = 1, Name = "Executive", Description = "Executive", LevelOfMember = 3, MaximumNumber = 3, MaximumTimeInYears = 2, ShowMaximumTimeInYears = true, CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                           new OrganizationStructure { Id = 2, Name = "Manager", Description = "Manager", LevelOfMember = 2, MaximumNumber = 10, MaximumTimeInYears = 3, ShowMaximumTimeInYears = true, CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                           new OrganizationStructure { Id = 3, Name = "Associate", Description = "Associate", LevelOfMember = 1, MaximumNumber = 100, MaximumTimeInYears = 5, ShowMaximumTimeInYears = true, CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                           );
        }
    }
}
