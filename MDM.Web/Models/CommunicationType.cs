using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CommunicationType
    {
        public CommunicationType()
        {
            CommunicationPreference = new HashSet<CommunicationPreference>();
            MemberCommunicationPreference = new HashSet<MemberCommunicationPreference>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<CommunicationPreference> CommunicationPreference { get; set; }
        public virtual ICollection<MemberCommunicationPreference> MemberCommunicationPreference { get; set; }
    }
    public partial class CommunicationTypeConfiguration : IEntityTypeConfiguration<CommunicationType>
    {
        public void Configure(EntityTypeBuilder<CommunicationType> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedCommunicationType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicationType>().HasData(
                          new CommunicationType { Id = 1, Name = "Email", Description = "Email Message", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new CommunicationType { Id = 2, Name = "Fax", Description = "Fax Message", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new CommunicationType { Id = 3, Name = "Phone", Description = "Mobile / Phone Call", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new CommunicationType { Id = 4, Name = "Post", Description = "Postal Letter", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new CommunicationType { Id = 5, Name = "SMS", Description = "Text Message", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new CommunicationType { Id = 6, Name = "Any", Description = "No Preferences", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                          );

        }
    }
}
