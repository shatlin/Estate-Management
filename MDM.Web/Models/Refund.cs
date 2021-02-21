using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Refund
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public int MemberId { get; set; }
        public int PaymentGatewayId { get; set; }
        public int? RelatedToId { get; set; }
        public int? RelatedRecordId { get; set; }
        public DateTime RefundDate { get; set; }
        public string RefundItem { get; set; }
        public decimal RefundAmount { get; set; }
        public string CommentsForPayer { get; set; }
        public string InternalNotes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberUser Member { get; set; }
        public virtual PaymentGateway PaymentGateway { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class RefundConfiguration : IEntityTypeConfiguration<Refund>
    {
        public void Configure(EntityTypeBuilder<Refund> builder)
        {
  builder.Property(e => e.CommentsForPayer).HasMaxLength(1000);

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.InternalNotes).HasMaxLength(1000);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");

                builder.Property(e => e.RefundDate).HasColumnType("datetime");

                builder.Property(e => e.RefundItem)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.Refund)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Refund_Member");

                builder.HasOne(d => d.PaymentGateway)
                    .WithMany(p => p.Refund)
                    .HasForeignKey(d => d.PaymentGatewayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Refund_PaymentGateway");

                builder.HasOne(d => d.RelatedTo)
                    .WithMany(p => p.Refund)
                    .HasForeignKey(d => d.RelatedToId)
                    .HasConstraintName("FK_Refund_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedRefund(this ModelBuilder modelBuilder)
        {

        }
    }
}
