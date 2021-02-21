using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class Division
    {
        public Division()
        {
            DivisionMemberXref = new HashSet<DivisionMemberXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<DivisionMemberXref> DivisionMemberXref { get; set; }
    }

    public partial class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
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
        public static void SeedDivision(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>().HasData(
                new Division { Id = 1, Name = "Anaerobic Sludge Processes", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 2, Name = "Community Water Supply and Sanitation", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 3, Name = "Industrial Water", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 4, Name = "Innovations in Water & Sanitation", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 5, Name = "IWA-SA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 6, Name = "Management & Institutional Affairs", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 7, Name = "Membrane Technology", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 8, Name = "Mine Water", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 9, Name = "Process Controllers", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 10, Name = "Small Wastewater Treatment Works", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 11, Name = "Water Distribution", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 12, Name = "Water Reuse", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 13, Name = "Water Science", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 14, Name = "Community Water Supply and Sanitation", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Division { Id = 15, Name = "Young Water Professionals", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                
              );
        }
    }
}
