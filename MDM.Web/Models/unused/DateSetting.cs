using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class DateSetting
    {
        public DateSetting()
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

    public partial class DateSettingConfiguration : IEntityTypeConfiguration<DateSetting>
    {
        public void Configure(EntityTypeBuilder<DateSetting> builder)
        {
                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).IsRequired().HasMaxLength(40);
        }

    }
    public static partial class Seeder
    {
        public static void SeedDateSetting(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DateSetting>().HasData
          (
          new DateSetting { Id = 1, Name = "12/03/2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 2, Name = "03/12/2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 3, Name = "03.12.2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 4, Name = "03-12-2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 5, Name = "03 Dec 2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 6, Name = "03-Dec-2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 7, Name = "2020-12-03", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 8, Name = "Friday, December 03, 2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 9, Name = "Fri, December 03, 2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 10, Name = "December 03, 2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 11, Name = "03 December 2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
          new DateSetting { Id = 12, Name = "3 Dec 2020", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
          );
        }
    }
}