using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class Involvement
    {
        public Involvement()
        {
            InvolvementMemberXref = new HashSet<InvolvementMemberXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<InvolvementMemberXref> InvolvementMemberXref { get; set; }
    }

    public partial class InvolvementConfiguration : IEntityTypeConfiguration<Involvement>
    {
        public void Configure(EntityTypeBuilder<Involvement> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

        }


    }

    public static partial class Seeder
    {
        public static void SeedInvolvement(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Involvement>().HasData(
                new Involvement { Id = 1, Name = "Branch/Division Committee member", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 2, Name = "Logistics", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 3, Name = "Promotions and Marketing", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 4, Name = "Writing articles for publication in WISA and main stream media", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 5, Name = "Being a mentor and/or specialist advisor", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 6, Name = "Visit schools and universities to promote WISA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 7, Name = "Visit businesses and government departments to promote WISA", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 8, Name = "Man a \"membership desk or exhibition stand\" at WISA events hosted by other parties in the water sector to promote WISA membership and answer enquiries regarding WISA ", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 9, Name = "Community outreach projects", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 10, Name = "Media mentor - reporting to WISA HQ all the news that is relevant to the Water sector and that needs our attention ", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new Involvement { Id = 11, Name = "Assist in obtaining sponsorship ", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );
        }
    }
}
