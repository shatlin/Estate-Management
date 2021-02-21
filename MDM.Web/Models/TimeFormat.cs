using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class TimeFormat
    {
        public TimeFormat()
        {
            Client = new HashSet<ClientOrganization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<ClientOrganization> Client { get; set; }
    }

    public partial class TimeFormatConfiguration : IEntityTypeConfiguration<TimeFormat>
    {
        public void Configure(EntityTypeBuilder<TimeFormat> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

        }


    }

    public static partial class Seeder
    {
        public static void SeedTimeFormat(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeFormat>().HasData
                (
                new TimeFormat { Id = 1, Name = "12:00 AM/PM", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new TimeFormat { Id = 2, Name = "24 Hours", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
               
                );
        }
    }
}