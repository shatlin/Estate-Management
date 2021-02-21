using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class VolunteerHours
    {
        public VolunteerHours()
        {
            MemberUser = new HashSet<MemberUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberUser> MemberUser { get; set; }
    }

    public partial class VolunteerHoursConfiguration : IEntityTypeConfiguration<VolunteerHours>
    {
        public void Configure(EntityTypeBuilder<VolunteerHours> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }

    public static partial class Seeder
    {
        public static void SeedVolunteerHours(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VolunteerHours>().HasData(
                new VolunteerHours { Id = 1, Name = "1-5  hours per week",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new VolunteerHours { Id = 2, Name = "6-10  hours per week", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new VolunteerHours { Id = 3, Name = "11-15 hours per week", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new VolunteerHours { Id = 4, Name = "16-20 hours per week", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                
              );
        }
    }
}
