using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CorrespondenceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
    public partial class CorrespondenceTypeConfiguration : IEntityTypeConfiguration<CorrespondenceType>
    {
        public void Configure(EntityTypeBuilder<CorrespondenceType> builder)
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
        public static void SeedCorrespondenceType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorrespondenceType>().HasData(
                                    new CorrespondenceType { Id = 1, Name = "Internal", Description = "Internal Correspondance", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                                    new CorrespondenceType { Id = 2, Name = "External", Description = "External Correspondance", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                                    new CorrespondenceType { Id = 3, Name = "Sales", Description = "Sales Correspondance", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                                    new CorrespondenceType { Id = 4, Name = "Personal", Description = "Reminders, Statements Invoices to Members", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                                    new CorrespondenceType { Id = 5, Name = "Circular", Description = "Common messages", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                                    new CorrespondenceType { Id = 6, Name = "Confidential", Description = "Private Messages", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
    
                              );
        }
    }
}
