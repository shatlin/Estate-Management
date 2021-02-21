using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class PreferredContactTime
    {
        public PreferredContactTime()
        {
            MemberUser = new HashSet<MemberUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberUser> MemberUser { get; set; }
    }

    public partial class PreferredContactTimeConfiguration : IEntityTypeConfiguration<PreferredContactTime>
    {
        public void Configure(EntityTypeBuilder<PreferredContactTime> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

        }


    }

    public static partial class Seeder
    {
        public static void SeedPreferredContactTime(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreferredContactTime>().HasData(
                new PreferredContactTime { Id = 1, Name = "Morning", Description = "Morning", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new PreferredContactTime { Id = 2, Name = "Day", Description = "Day", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new PreferredContactTime { Id = 3, Name = "Evenings", Description = "Evenings", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
               
              );
        }
    }
}
