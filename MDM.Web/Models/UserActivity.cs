using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class UserActivity : BaseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string ActivityDetail { get; set; }
    }

    public partial class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.Property(e => e.ActivityDetail).HasMaxLength(500);
            builder.Property(e => e.UserId).HasMaxLength(100);
        }
    }

    public static partial class Seeder
    {
        public static void SeedUserActivity(this ModelBuilder modelBuilder)
        {

        }
    }
}


