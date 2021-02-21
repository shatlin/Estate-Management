using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class OrganizationBusinessXref
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? BusinessId { get; set; }

        [NotMapped]
        public bool? IsSelected { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Business Business { get; set; }
        public virtual Organization Organization { get; set; }
    }

    public partial class OrganizationBusinessXrefConfiguration : IEntityTypeConfiguration<OrganizationBusinessXref>
    {
        public void Configure(EntityTypeBuilder<OrganizationBusinessXref> builder)
        {
            builder.ToTable("OrganizationBusinessXref");

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.Business)
                .WithMany(p => p.OrganizationBusinessXref)
                .HasForeignKey(d => d.BusinessId)
                .HasConstraintName("FK_OrganizationBusinessXref_Business");

            builder.HasOne(d => d.Organization)
                .WithMany(p => p.OrganizationBusinessXref)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_OrganizationBusinessXref_Organization");

        }

    }
    public static partial class Seeder
    {
        public static void SeedOrganizationBusinessXref(this ModelBuilder modelBuilder)
        {

        }
    }
}
