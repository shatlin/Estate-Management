using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class Group : BaseModel
    {
        public Group()
        {
            TaskItem = new HashSet<TaskItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<TaskItem> TaskItem { get; set; }
    }

    public partial class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
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
        public static void SeedGroup(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Maintenance", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Group { Id = 2, Name = "Security", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Group { Id = 3, Name = "Finance", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Group { Id = 4, Name = "Legal", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Group { Id = 5, Name = "Special Pr", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new Group { Id = 6, Name ="Others", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
              );
        }
    }
}
