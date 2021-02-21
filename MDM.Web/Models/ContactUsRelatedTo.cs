using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class ContactUsRelatedTo
    {
        public ContactUsRelatedTo()
        {
            ContactUs = new HashSet<ContactUs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual ICollection<ContactUs> ContactUs { get; set; }
    }

    public partial class ContactUsRelatedToConfiguration : IEntityTypeConfiguration<ContactUsRelatedTo>
    {
        public void Configure(EntityTypeBuilder<ContactUsRelatedTo> builder)
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
        public static void SeedContactUsRelatedTo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactUsRelatedTo>().HasData
                (
                new ContactUsRelatedTo { Id = 1, Name = "Membership", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ContactUsRelatedTo { Id = 2, Name = "Events", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ContactUsRelatedTo { Id = 3, Name = "Registration", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                );
        }
    }
}