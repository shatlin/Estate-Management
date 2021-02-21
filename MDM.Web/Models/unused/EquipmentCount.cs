using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{
    public partial class EquipmentCount
    {
        public int Id { get; set; }

        [Display(Name = "Equipment Name")]
        [Required(ErrorMessage = "Equipment name is required")]
        public int EquipmentId { get; set; }

        [Display(Name = "Available Count", Prompt = "Please enter available count")]
        [Required(ErrorMessage = "Available count is required")]
        public int AvailableCount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Equipment Equipment { get; set; }
    }

public partial class EquipmentCountConfiguration : IEntityTypeConfiguration<EquipmentCount>
{
    public void Configure(EntityTypeBuilder<EquipmentCount> builder)
    {
 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentCount)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentCount_Equipment");
    }

}
public static partial class Seeder
{
    public static void SeedEquipmentCount(this ModelBuilder modelBuilder)
    {

    }
}
}

