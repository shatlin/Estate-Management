using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CustomFieldLookUp
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int? FieldIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public partial class CustomFieldLookUpConfiguration : IEntityTypeConfiguration<CustomFieldLookUp>
    {
        public void Configure(EntityTypeBuilder<CustomFieldLookUp> builder)
        {
 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description).HasMaxLength(50);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(50);

                builder.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50);
        }

    }
    public static partial class Seeder
    {
        public static void SeedCustomFieldLookUp(this ModelBuilder modelBuilder)
        {

        }
    }
}
