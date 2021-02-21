using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class PlanFrequency
    {
        public PlanFrequency()
        {
            PlanDetail = new HashSet<PlanDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<PlanDetail> PlanDetail { get; set; }
    }

public partial class PlanFrequencyConfiguration : IEntityTypeConfiguration<PlanFrequency>
{
    public void Configure(EntityTypeBuilder<PlanFrequency> builder)
    {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
    }

}
public static partial class Seeder
{
    public static void SeedPlanFrequency(this ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<PlanFrequency>().HasData(
                          new PlanFrequency { Id = 1, Name = "Daily", Description = "Daily", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PlanFrequency { Id = 2, Name = "Weekly", Description = "Weekly", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PlanFrequency { Id = 3, Name = "Monthly", Description = "Monthly", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PlanFrequency { Id = 4, Name = "Quarterly", Description = "Quarterly", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PlanFrequency { Id = 5, Name = "Yearly", Description = "Yearly", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new PlanFrequency { Id = 6, Name = "Life Time", Description = "Life Time", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                          );
        }
}
}

