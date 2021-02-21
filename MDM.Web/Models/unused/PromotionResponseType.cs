using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PromotionResponseType
    {
        public PromotionResponseType()
        {
            PromotionResponse = new HashSet<PromotionResponse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<PromotionResponse> PromotionResponse { get; set; }
    }

    public partial class PromotionResponseTypeConfiguration : IEntityTypeConfiguration<PromotionResponseType>
    {
        public void Configure(EntityTypeBuilder<PromotionResponseType> builder)
        {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
        }

    }
    public static partial class Seeder
    {
        public static void SeedPromotionResponseType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromotionResponseType>().HasData(
                          new PromotionResponseType { Id = 1, Name = "Call", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PromotionResponseType { Id = 2, Name = "Email", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PromotionResponseType { Id = 3, Name = "SMS", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                          );
        }
    }
}

