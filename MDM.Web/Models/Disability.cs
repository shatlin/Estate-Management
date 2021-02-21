using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class Disability
    {
        public Disability()
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

    public partial class DisabilityConfiguration : IEntityTypeConfiguration<Disability>
    {
        public void Configure(EntityTypeBuilder<Disability> builder)
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
        public static void SeedDisability(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disability>().HasData(
                new Disability { Id = 1, Name = "Hearing", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Disability { Id = 2, Name = "Communication", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Disability { Id = 3, Name = "Seeing", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Disability { Id = 4, Name = "Walking", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Disability { Id = 5, Name = "Self-care", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Disability { Id = 6, Name = "Remembering", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );
        }
    }
}
