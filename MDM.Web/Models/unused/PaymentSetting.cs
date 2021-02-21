using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PaymentSetting
    {
        public PaymentSetting()
        {
            PaymentSettingAllowedCard = new HashSet<PaymentSettingAllowedCard>();
            PlanMaster = new HashSet<PlanMaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CurrencyId { get; set; }
        public string GeneralInstructions { get; set; }
        public string EventsInstructions { get; set; }
        public string ApplicationInstructions { get; set; }
        public int? ClientPayPalConnectionModeId { get; set; }
        public string PayPalAccountId { get; set; }
        public string PayPalPdtidentityToken { get; set; }
        public int? DefaultCountryId { get; set; }
        public string PayPalApiuserName { get; set; }
        public string PayPalApipassword { get; set; }
        public string PayPalApisignature { get; set; }
        public int? PayPalPreferredPaymentGatewayId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ICollection<PaymentSettingAllowedCard> PaymentSettingAllowedCard { get; set; }
        public virtual ICollection<PlanMaster> PlanMaster { get; set; }
    }
    public partial class PaymentSettingConfiguration : IEntityTypeConfiguration<PaymentSetting>
    {
        public void Configure(EntityTypeBuilder<PaymentSetting> builder)
        {
    builder.Property(e => e.ApplicationInstructions).HasMaxLength(2000);

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description).HasMaxLength(200);

                builder.Property(e => e.EventsInstructions).HasMaxLength(2000);

                builder.Property(e => e.GeneralInstructions).HasMaxLength(2000);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);

                builder.Property(e => e.PayPalAccountId).HasMaxLength(200);

                builder.Property(e => e.PayPalApipassword)
                    .HasColumnName("PayPalAPIPassword")
                    .HasMaxLength(50);

                builder.Property(e => e.PayPalApisignature)
                    .HasColumnName("PayPalAPISignature")
                    .HasMaxLength(200);

                builder.Property(e => e.PayPalApiuserName)
                    .HasColumnName("PayPalAPIUserName")
                    .HasMaxLength(50);

                builder.Property(e => e.PayPalPdtidentityToken)
                    .HasColumnName("PayPalPDTIdentityToken")
                    .HasMaxLength(200);

                builder.HasOne(d => d.Currency)
                    .WithMany(p => p.PaymentSetting)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_PaymentSetting_Currency");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPaymentSetting(this ModelBuilder modelBuilder)
        {

        }
    }
}
