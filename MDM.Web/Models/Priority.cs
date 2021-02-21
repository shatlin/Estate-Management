using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class Priority
    {
        public Priority()
        {
            TaskItem = new HashSet<TaskItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual ICollection<TaskItem> TaskItem { get; set; }
    }

    public partial class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
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
        public static void SeedPriority(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Name = "Urgent", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Priority { Id = 2, Name = "High", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Priority { Id = 3, Name = "Normal", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Priority { Id = 4, Name = "Low", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Priority { Id = 5, Name = "Clear", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
              );
        }
    }
}
