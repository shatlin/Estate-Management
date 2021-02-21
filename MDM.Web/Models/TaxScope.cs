using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class TaxScope
    {
        public int Id { get; set; }
        public string TaxScopeCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public partial class TaxScopeConfiguration : IEntityTypeConfiguration<TaxScope>
    {
        public void Configure(EntityTypeBuilder<TaxScope> builder)
        {
builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.TaxScopeCode)
                    .IsRequired()
                    .HasMaxLength(50);
        }

    }
    public static partial class Seeder
    {
        public static void SeedTaxScope(this ModelBuilder modelBuilder)
        {

        }
    }
}