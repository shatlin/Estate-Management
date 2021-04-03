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
            TrustAccountInvoiceFiles = new HashSet<TrustAccountInvoiceFiles>();
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
        [JsonPropertyName("runningtotal")]
        [NotMapped]
        public decimal runningtotal { get; set; }
        public virtual ICollection<TrustAccountInvoiceFiles> TrustAccountInvoiceFiles { get; set; }
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
