using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class DisabilityLevel
    {
        public DisabilityLevel()
        {
            DisabilityMemberXref = new HashSet<DisabilityMemberXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<DisabilityMemberXref> DisabilityMemberXref { get; set; }
    }

    public partial class DisabilityLevelConfiguration : IEntityTypeConfiguration<DisabilityLevel>
    {
        public void Configure(EntityTypeBuilder<DisabilityLevel> builder)
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
        public static void SeedDisabilityLevel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisabilityLevel>().HasData(
                new DisabilityLevel { Id = 1, Name = "No Difficulty", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DisabilityLevel { Id = 2, Name = "Some Difficulty", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DisabilityLevel { Id = 3, Name = "A lot of Difficulty", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DisabilityLevel { Id = 4, Name = "Cannot do at all", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DisabilityLevel { Id = 5, Name = "Cannot yet be determined", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );
        }
    }
}
