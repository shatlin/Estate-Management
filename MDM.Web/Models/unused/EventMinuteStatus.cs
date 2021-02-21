using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EventMinuteStatus
    {
        public EventMinuteStatus()
        {
            EventMinute = new HashSet<EventMinute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<EventMinute> EventMinute { get; set; }
    }
    public partial class EventMinuteStatusConfiguration : IEntityTypeConfiguration<EventMinuteStatus>
    {
        public void Configure(EntityTypeBuilder<EventMinuteStatus> builder)
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
        public static void SeedEventMinuteStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventMinuteStatus>().HasData(
                          new EventMinuteStatus { Id = 1, Name = "In-Progress", Description = "Under preperation", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new EventMinuteStatus { Id = 2, Name = "Prepared", Description = "Prepared & awaiting approval", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new EventMinuteStatus { Id = 3, Name = "Approved", Description = "Approved", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                          new EventMinuteStatus { Id = 4, Name = "Shared", Description = "Shared with concerned people", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                          );

        }
    }
}
