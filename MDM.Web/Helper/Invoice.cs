using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Invoice
    {
        public Invoice()
        {
            Billing = new HashSet<Billing>();
        }

        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public int? RelatedToId { get; set; }
        public int? RelatedRecordId { get; set; }
        public int MemberId { get; set; }
        public int InvoiceStatusId { get; set; }
        public int PaymentGatewayId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceItem { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string CommentsForPayer { get; set; }
        public string InternalNotes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual InvoiceStatus InvoiceStatus { get; set; }
        public virtual MemberUser Member { get; set; }
        public virtual PaymentGateway PaymentGateway { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
        public virtual ICollection<Billing> Billing { get; set; }
    }
    public partial class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
                   builder.Property(e => e.CommentsForPayer).HasMaxLength(1000);

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.InternalNotes).HasMaxLength(1000);

                builder.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                builder.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.InvoiceDate).HasColumnType("datetime");

                builder.Property(e => e.InvoiceItem)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.InvoiceStatus)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvoiceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_InvoiceStatus");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Member");

                builder.HasOne(d => d.PaymentGateway)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.PaymentGatewayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_PaymentGateway");

                builder.HasOne(d => d.RelatedTo)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.RelatedToId)
                    .HasConstraintName("FK_Invoice_RelatedTo");

        }

    }
    public static partial class Seeder
    {
        public static void SeedInvoice(this ModelBuilder modelBuilder)
        {

        }
    }
}

