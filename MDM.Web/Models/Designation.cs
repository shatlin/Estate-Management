using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Designation
    {
        public Designation()
        {
            User = new HashSet<ClientUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<ClientUser> User { get; set; }
    }
    public partial class DesignationConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Description)
               .IsRequired(false)
               .HasMaxLength(200);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedDesignation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>().HasData(
            new Designation { Id = 1, Name = "Operations manager", Description = "Operations manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 2, Name = "Quality control, safety, environmental manager", Description = "Quality control, safety, environmental manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 3, Name = "Accountant, bookkeeper, controller", Description = "Accountant, bookkeeper, controller", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 4, Name = "Office manager", Description = "Office manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 5, Name = "Receptionist", Description = "Receptionist", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 6, Name = "Foreperson, supervisor, lead person", Description = "Foreperson, supervisor, lead person", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 7, Name = "Marketing manager", Description = "Marketing manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 8, Name = "Purchasing manager", Description = "Purchasing manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 9, Name = "Shipping and receiving person or manager", Description = "Shipping and receiving person or manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 10, Name = "Professional staff", Description = "Professional staff", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 11, Name = "Production Manager", Description = "Production Manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 12, Name = "Chief Financial Officer (CFO)", Description = "Chief Financial Officer (CFO)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 13, Name = "Vice President of Marketing or Marketing Manager", Description = "Vice President of Marketing or Marketing Manager", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 14, Name = "Chief Operating Officer (COO)", Description = "Chief Operating Officer (COO)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
            new Designation { Id = 15, Name = "Chief Executive Officer (CEO) or President", Description = "Chief Executive Officer (CEO) or President" }
            );
        }
    }
}
