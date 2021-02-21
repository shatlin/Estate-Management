using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Billing
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public int MemberId { get; set; }
        public int RelatedToId { get; set; }
        public int RelatedRecordId { get; set; }
        public int PaymentGatewayId { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string PaymentItem { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public string CommentsForPayer { get; set; }
        public string InternalNotes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual MemberUser Member { get; set; }
        public virtual PaymentGateway PaymentGateway { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
        public virtual BillingCommunication BillingCommunication { get; set; }
    }

    public partial class BillingConfiguration : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.Property(e => e.CommentsForPayer).HasMaxLength(1000);

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.InternalNotes).HasMaxLength(1000);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PaidDate).HasColumnType("datetime");

            builder.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.PaymentDueDate).HasColumnType("datetime");

            builder.Property(e => e.PaymentItem)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(d => d.Invoice)
                .WithMany(p => p.Billing)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_Payment_Invoice");

            builder.HasOne(d => d.Member)
                .WithMany(p => p.Billing)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Member");

            builder.HasOne(d => d.PaymentGateway)
                .WithMany(p => p.Billing)
                .HasForeignKey(d => d.PaymentGatewayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_PaymentGateway");

            builder.HasOne(d => d.RelatedTo)
                .WithMany(p => p.Billing)
                .HasForeignKey(d => d.RelatedToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Billing_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedBilling(this ModelBuilder modelBuilder)
        {

        }
    }
}

