using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class TaskItemType : BaseModel
    {
        public TaskItemType()
        {
            TaskItem = new HashSet<TaskItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<TaskItem> TaskItem { get; set; }
    }

    public partial class TaskItemTypeConfiguration : IEntityTypeConfiguration<TaskItemType>
    {
        public void Configure(EntityTypeBuilder<TaskItemType> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
        }


    }

    public static partial class Seeder
    {
        public static void SeedTaskItemType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItemType>().HasData(
                new TaskItemType { Id = 1, Name = "Issue", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItemType { Id = 2, Name = "Request", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItemType { Id = 3, Name = "Complaint", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItemType { Id = 4, Name = "Query", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
                
              );
        }
    }
}
