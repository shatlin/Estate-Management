using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PaymentSettingAllowedCard
    {
        public int Id { get; set; }
        public int PaymentSettingId { get; set; }
        public int PaymentCardId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual PaymentCard PaymentCard { get; set; }
        public virtual PaymentSetting PaymentSetting { get; set; }
    }

    public partial class PaymentSettingAllowedCardConfiguration : IEntityTypeConfiguration<PaymentSettingAllowedCard>
    {
        public void Configure(EntityTypeBuilder<PaymentSettingAllowedCard> builder)
        {

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.HasOne(d => d.PaymentCard)
                    .WithMany(p => p.PaymentSettingAllowedCard)
                    .HasForeignKey(d => d.PaymentCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentSettingAllowedCard_PaymentCard");

                builder.HasOne(d => d.PaymentSetting)
                    .WithMany(p => p.PaymentSettingAllowedCard)
                    .HasForeignKey(d => d.PaymentSettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentSettingAllowedCard_PaymentSetting");
        }

    }
    public static partial class Seeder
    {
        public static void SeedPaymentSettingAllowedCard(this ModelBuilder modelBuilder)
        {

        }
    }
}
