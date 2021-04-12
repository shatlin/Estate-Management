using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MDM.Models
{
    public partial class TrustAccount : BaseModel
    {
        public TrustAccount()
        {
            InvoiceFiles = new HashSet<InvoiceFiles>();
        }
        public int Id { get; set; }

        [JsonPropertyName("month")]
        public DateTime Month { get; set; }
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        [JsonPropertyName("debtorcreditor")]
        public string DebtorCreditor { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("amount")]
        public decimal amount { get; set; }
       
        [JsonPropertyName("organization")]
        public string Organization { get; set; }

        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("invoiceneeded")]
        public string isInvoiceNeeded { get; set; }

        [JsonPropertyName("runningtotal")]
        [NotMapped]
        public decimal runningtotal { get; set; }

        [JsonPropertyName("invoicesadded")]
        [NotMapped]
        public string InvoicesAdded { get; set; }

        public virtual ICollection<InvoiceFiles> InvoiceFiles { get; set; }
    }

    public partial class TrustAccountConfiguration : IEntityTypeConfiguration<TrustAccount>
    {
        public void Configure(EntityTypeBuilder<TrustAccount> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Month).HasColumnType("datetime");

            builder.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(500);

   
            builder.Property(e => e.DebtorCreditor)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.Property<decimal>("amount")
                .HasColumnType("decimal(18, 2)");
        }


    }


    public static partial class Seeder
    {
        public static void SeedTrustAccount(this ModelBuilder modelBuilder)
        {
      
        }
    }
}
