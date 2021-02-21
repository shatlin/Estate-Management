using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{
    public partial class Tax
    {
        public int Id { get; set; }

        [Display(Name = "Tax Code", Prompt = "Please enter tax code")]
        [Required(ErrorMessage = "Tax Code is required")]
        public string TaxCode { get; set; }

        [Display(Name = "Tax Rate", Prompt = "Please enter tax rate")]
        [Required(ErrorMessage = "Tax Code is required")]
        public int Rate { get; set; }

        [Display(Name = "Tax Name", Prompt = "Please enter tax name")]
        [Required(ErrorMessage = "Tax Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description", Prompt = "Please enter desccription")]
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public partial class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
               builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);

                builder.Property(e => e.TaxCode)
                    .IsRequired()
                    .HasMaxLength(50);

        }

    }
    public static partial class Seeder
    {
        public static void SeedTax(this ModelBuilder modelBuilder)
        {

        }
    }
}


