using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class RelatedTo : BaseModel
    {
        public RelatedTo()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       

        public virtual ICollection<Address> Address { get; set; }
      

    }
    public partial class RelatedToConfiguration : IEntityTypeConfiguration<RelatedTo>
    {
        public void Configure(EntityTypeBuilder<RelatedTo> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(30);
        }
    }
    public static partial class Seeder
    {
        public static void SeedRelatedTo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatedTo>().HasData(
              
                 new RelatedTo { Id = 1, Name = "Trustee", Description = "Tenant", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                 new RelatedTo { Id = 2, Name = "Owner", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                  new RelatedTo { Id = 3, Name = "Tenant", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                   new RelatedTo { Id = 4, Name = "Estate Manager", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                     new RelatedTo { Id = 5, Name = "Estate Management Vendor", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                      new RelatedTo { Id = 6, Name = "Garden Vendor", Description = "Tenant", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                 new RelatedTo { Id = 7, Name = "Security Vendor", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                
                   new RelatedTo { Id = 8, Name = "Service Provider", Description = "Service Provider", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }

                  );


          
  
    }
    }
}
