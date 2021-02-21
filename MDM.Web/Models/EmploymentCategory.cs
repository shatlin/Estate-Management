using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class EmploymentCategory
    {
        public EmploymentCategory()
        {
            EmploymentMemberXref = new HashSet<EmploymentMemberXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

      public virtual ICollection<EmploymentMemberXref> EmploymentMemberXref { get; set; }
    }

    public partial class EmploymentCategoryConfiguration : IEntityTypeConfiguration<EmploymentCategory>
    {
        public void Configure(EntityTypeBuilder<EmploymentCategory> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
        }
    }

    public static partial class Seeder
    {
        public static void SeedEmploymentCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmploymentCategory>().HasData(
                new EmploymentCategory { Id = 1, Name = "Current Employer",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new EmploymentCategory { Id = 2, Name = "Previous Employer", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              
              );
        }
    }
}
