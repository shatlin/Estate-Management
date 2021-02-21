using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Affliation
    {
        public Affliation()
        {
            MemberAffliationXref = new HashSet<MemberAffliationXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberAffliationXref> MemberAffliationXref { get; set; }
    }

public partial class AffliationConfiguration : IEntityTypeConfiguration<Affliation>
{
    public void Configure(EntityTypeBuilder<Affliation> builder)
    {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
        }

}
public static partial class Seeder
{
    public static void SeedAffliation(this ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Affliation>().HasData(
               new Affliation { Id = 1, Name = "ECSA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new Affliation { Id = 2, Name = "IMESA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new Affliation { Id = 3, Name = "IWA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new Affliation { Id = 4, Name = "SACNASP", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new Affliation { Id = 5, Name = "SAICE", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
               new Affliation { Id = 6, Name = "Other", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
             );
        }
}
}
