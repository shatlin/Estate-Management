using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PayPalPreferredPaymentGateway
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }



public partial class PayPalPreferredPaymentGatewayConfiguration : IEntityTypeConfiguration<PayPalPreferredPaymentGateway>
{
    public void Configure(EntityTypeBuilder<PayPalPreferredPaymentGateway> builder)
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
    public static void SeedPayPalPreferredPaymentGateway(this ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<PayPalPreferredPaymentGateway>().HasData(
                              new PayPalPreferredPaymentGateway { Id = 1, Name = "Pay Flow", Description = "Pay Flow Gateway", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                              new PayPalPreferredPaymentGateway { Id = 2, Name = "Paypal Payments Pro", Description = "Paypal Payments Pro", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                              );
        }
}
}