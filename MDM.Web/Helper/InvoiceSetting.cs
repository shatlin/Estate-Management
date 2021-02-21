using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class InvoiceSetting
    {
        public int Id { get; set; }
        public int NextInvoiceNumber { get; set; }
        public bool SendInvForPendingPayments { get; set; }
        public bool CopyInvToOrgContact { get; set; }
        public bool SendRecToPayer { get; set; }
        public bool CopyRecToOrgContact { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public partial class InvoiceSettingConfiguration : IEntityTypeConfiguration<InvoiceSetting>
    {
        public void Configure(EntityTypeBuilder<InvoiceSetting> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
        }

    }
    public static partial class Seeder
    {
        public static void SeedInvoiceSetting(this ModelBuilder modelBuilder)
        {

        }
    }
}

