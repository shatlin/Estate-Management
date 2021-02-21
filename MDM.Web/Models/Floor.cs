using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class Floor
    {
        public Floor()
        {
            Unit = new HashSet<Unit>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }

    }

    public partial class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
        }


    }

    public static partial class Seeder
    {
        public static void SeedFloor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Floor>().HasData(
                new Floor { Id = 1, Name = "Ground", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Floor { Id = 2, Name = "First", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Floor { Id = 3, Name = "Second", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
              );
        }
    }
}
