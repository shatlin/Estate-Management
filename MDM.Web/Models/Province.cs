using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Province
    {
        public Province()
        {
            Address = new HashSet<Address>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }

    public partial class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

        

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(100);

            
        }

    }
    public static partial class Seeder
    {
        public static void SeedProvince(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
            new Province { Id = 1, Name = "Eastern Cape", Description = "Eastern Cape", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 2, Name = "Free State", Description = "Free State", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 3, Name = "Gauteng", Description = "Gauteng", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 4, Name = "KwaZulu-Natal", Description = "KwaZulu-Natal", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 5, Name = "Limpopo", Description = "Limpopo", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 6, Name = "Mpumalanga", Description = "Mpumalanga", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 7, Name = "North West", Description = "North West", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) },
            new Province { Id = 8, Name = "Northern Cape", Description = "Northern Cape", CreatedOn = new DateTime(2020, 8, 19), ModifiedOn = new DateTime(2020, 8, 19) }
            
);
        }
    }
}
