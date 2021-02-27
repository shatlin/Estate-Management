using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class AddressType : BaseModel
    {
        public AddressType()
        {
            Address = new HashSet<Address>();
          
        }

        public int Id { get; set; }
        public string Name { get; set; }
       

        public virtual ICollection<Address> Address { get; set; }
       
    }




    public partial class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

           

            builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedAddressType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressType>().HasData(
              new AddressType { Id = 1, Name = "Postal Address", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
              new AddressType { Id = 2, Name = "Physical Address",  CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
              new AddressType { Id = 3, Name = "Billing Address", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
              new AddressType { Id = 4, Name = "Business Address",  CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
              new AddressType { Id = 5, Name = "Shipping Address", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
              new AddressType { Id = 6, Name = "Contact Address",  CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
               new AddressType { Id = 7, Name = "Venue", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
              );
        }
    }
}

