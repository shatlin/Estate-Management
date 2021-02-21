using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PromotionMaster
    {
        public PromotionMaster()
        {
            PromotionDetail = new HashSet<PromotionDetail>();
            PromotionResponse = new HashSet<PromotionResponse>();
        }

        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BenefitStartDate { get; set; }
        public DateTime BenefitEndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual RelatedTo RelatedTo { get; set; }

        public virtual ICollection<PromotionDetail> PromotionDetail { get; set; }
        public virtual ICollection<PromotionResponse> PromotionResponse { get; set; }
    }

public partial class PromotionMasterConfiguration : IEntityTypeConfiguration<PromotionMaster>
{
    public void Configure(EntityTypeBuilder<PromotionMaster> builder)
    {
    builder.Property(e => e.BenefitEndDate).HasColumnType("datetime");

                builder.Property(e => e.BenefitStartDate).HasColumnType("datetime");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description).HasMaxLength(1000);

                builder.Property(e => e.EndDate).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(200);

                builder.Property(e => e.StartDate).HasColumnType("datetime");
    }

}
public static partial class Seeder
{
    public static void SeedPromotionMaster(this ModelBuilder modelBuilder)
    {

    }
}
}

