using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberCodeGenerator
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public int? LastNumber { get; set; }
        public string Suffix { get; set; }
        public string CodeGenerationRule { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }

public partial class MemberCodeGeneratorConfiguration : IEntityTypeConfiguration<MemberCodeGenerator>
{
    public void Configure(EntityTypeBuilder<MemberCodeGenerator> builder)
    {
 builder.Property(e => e.CodeGenerationRule).HasMaxLength(200);

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Prefix).HasMaxLength(50);

                builder.Property(e => e.Suffix).HasMaxLength(50);
    }

}
public static partial class Seeder
{
    public static void SeedMemberCodeGenerator(this ModelBuilder modelBuilder)
    {

    }
}
}
