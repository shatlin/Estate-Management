using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PaymentGateway
    {
        public PaymentGateway()
        {
            Billing = new HashSet<Billing>();
            Invoice = new HashSet<Invoice>();
            Refund = new HashSet<Refund>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientIdForMerchant { get; set; }
        public string ClientPasswordForMerchant { get; set; }
        public string ClientApicodeForMerchant { get; set; }
        public string MerchantNumber { get; set; }
        public string MerchantName { get; set; }
        public string MerchantLocation { get; set; }
        public decimal? CommisionPercentage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }
    }
    public partial class PaymentGatewayConfiguration : IEntityTypeConfiguration<PaymentGateway>
    {
        public void Configure(EntityTypeBuilder<PaymentGateway> builder)
        {
  builder.Property(e => e.ClientApicodeForMerchant)
                    .HasColumnName("ClientAPICodeForMerchant")
                    .HasMaxLength(100);

                builder.Property(e => e.ClientIdForMerchant).HasMaxLength(100);

                builder.Property(e => e.ClientPasswordForMerchant).HasMaxLength(100);

                builder.Property(e => e.CommisionPercentage).HasColumnType("decimal(6, 3)");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.MerchantLocation).HasMaxLength(100);

                builder.Property(e => e.MerchantName).HasMaxLength(100);

                builder.Property(e => e.MerchantNumber).HasMaxLength(100);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedPaymentGateway(this ModelBuilder modelBuilder)
        {

        }
    }
}