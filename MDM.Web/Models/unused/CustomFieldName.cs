using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class CustomFieldName
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public int? FieldIndex { get; set; }
        public string DataType { get; set; }
        public string Label { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }

public partial class CustomFieldNameConfiguration : IEntityTypeConfiguration<CustomFieldName>
{
    public void Configure(EntityTypeBuilder<CustomFieldName> builder)
    {
 builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.DataType).HasMaxLength(50);

                builder.Property(e => e.Label).HasMaxLength(50);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50);
    }

}
public static partial class Seeder
{
    public static void SeedCustomFieldName(this ModelBuilder modelBuilder)
    {

    }
}
}
