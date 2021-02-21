using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class RelatedTo
    {
        public RelatedTo()
        {
            Address = new HashSet<Address>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Address> Address { get; set; }
      

    }
    public partial class RelatedToConfiguration : IEntityTypeConfiguration<RelatedTo>
    {
        public void Configure(EntityTypeBuilder<RelatedTo> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(30);
        }
    }
    public static partial class Seeder
    {
        public static void SeedRelatedTo(this ModelBuilder modelBuilder)
        {

        }
    }
}
