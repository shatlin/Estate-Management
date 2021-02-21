using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class BillingCommunication
    {
        public int Id { get; set; }
        public int BillingId { get; set; }
        public bool? Reminder1Sent { get; set; }
        public DateTime? Reminder1SentDate { get; set; }
        public DateTime? Reminder1ScheduledDate { get; set; }
        public bool? Reminder2Sent { get; set; }
        public DateTime? Reminder2SentDate { get; set; }
        public DateTime? Reminder2ScheduledDate { get; set; }
        public bool? Reminder3Sent { get; set; }
        public DateTime? Reminder3SentDate { get; set; }
        public DateTime? Reminder3ScheduledDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual Billing Billing { get; set; }
    }
    public partial class BillingCommunicationConfiguration : IEntityTypeConfiguration<BillingCommunication>
    {
        public void Configure(EntityTypeBuilder<BillingCommunication> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Reminder1ScheduledDate).HasColumnType("datetime");

            builder.Property(e => e.Reminder1SentDate).HasColumnType("datetime");

            builder.Property(e => e.Reminder2ScheduledDate).HasColumnType("datetime");

            builder.Property(e => e.Reminder2SentDate).HasColumnType("datetime");

            builder.Property(e => e.Reminder3ScheduledDate).HasColumnType("datetime");

            builder.Property(e => e.Reminder3SentDate).HasColumnType("datetime");

            builder.HasOne(d => d.Billing)
                .WithOne(p => p.BillingCommunication)
                .HasForeignKey<BillingCommunication>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentCommunication_Payment");

        }

    }
    public static partial class Seeder
    {
        public static void SeedBillingCommunication(this ModelBuilder modelBuilder)
        {

        }
    }
}
