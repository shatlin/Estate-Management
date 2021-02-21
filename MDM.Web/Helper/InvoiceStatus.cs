using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }

    public partial class InvoiceStatusConfiguration : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
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
        public static void SeedInvoiceStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceStatus>().HasData(
                          new InvoiceStatus { Id = 1, Name = "Draft", Description = "Incomplete Invoice", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 2, Name = "Send", Description = "Send to Member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 3, Name = "Viewed", Description = "Viewed by member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 4, Name = "Due", Description = "Due for payment", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 5, Name = "Overdue", Description = "Outstanding payment", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 6, Name = "Paid", Description = "Payment made", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 7, Name = "Partial", Description = "Partial payment", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 8, Name = "Void", Description = "Incorrect / Dispute Invoice", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 9, Name = "Canceled", Description = "Canceled Invoice", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new InvoiceStatus { Id = 10, Name = "Write Off", Description = "Uncollectible Invoice", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                          );
        }
    }
}
