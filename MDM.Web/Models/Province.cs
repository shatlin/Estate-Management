using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class Province
    {
        public Province()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    
    }
    public partial class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasOne(d => d.Country)
                .WithMany(p => p.State)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Province_Country");
        }

    }
    public static partial class Seeder
    {
        public static void SeedProvince(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(

                new Province { Id = 1, Name = "Eastern Cape", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 2, Name = "Free State", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 3, Name = "Gauteng", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 4, Name = "KwaZulu-Natal", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 5, Name = "Limpopo", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 6, Name = "Mpumalanga", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 7, Name = "North West", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 8, Name = "Northern Cape", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 9, Name = "Western Cape", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Province { Id = 10, Name = "Other", CountryId = 1, CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
           
                );
        }
    }
}

