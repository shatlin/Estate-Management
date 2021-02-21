using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MDM.Models
{
    public partial class TaskItem
    {
        public TaskItem()
        {
            TaskItemAssignee = new HashSet<TaskItemAssignee>();
            TaskItemFile = new HashSet<TaskItemFile>();
            TaskItemComment = new HashSet<TaskItemComment>();
        }

        public virtual ICollection<TaskItemAssignee> TaskItemAssignee { get; set; }
        public virtual ICollection<TaskItemFile> TaskItemFile { get; set; }
        public virtual ICollection<TaskItemComment> TaskItemComment { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DueOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ProgressPercentage { get; set; }
        public int? ModifiedBy { get; set; }

        public int? PriorityId { get; set; }
        public int? StatusId { get; set; }
        public int? GroupId { get; set; }
        public int? UnitId { get; set; }

        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
        public virtual Group Group { get; set; }
        public virtual Unit Unit { get; set; }
    }

    public partial class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.DueOn).HasColumnType("datetime");
            builder.Property(e => e.ClosedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1500);
            builder.Property(e => e.Description)
                   .IsRequired(false)
                   .HasMaxLength(4000);

            builder.HasOne(d => d.Priority)
            .WithMany(p => p.TaskItem)
            .HasForeignKey(d => d.PriorityId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_TaskItem_Priority");

            builder.HasOne(d => d.Status)
        .WithMany(p => p.TaskItem)
        .HasForeignKey(d => d.StatusId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_TaskItem_Status");

            builder.HasOne(d => d.Group)
     .WithMany(p => p.TaskItem)
     .HasForeignKey(d => d.GroupId)
     .OnDelete(DeleteBehavior.ClientSetNull)
     .HasConstraintName("FK_TaskItem_Group");

            builder.HasOne(d => d.Unit)
     .WithMany(p => p.TaskItem)
     .HasForeignKey(d => d.UnitId)
     .OnDelete(DeleteBehavior.ClientSetNull)
     .HasConstraintName("FK_TaskItem_Unit");


        }
    }

    public static partial class Seeder
    {
        public static void SeedTaskItem(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Name = "Open", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 2, Name = "Pending", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 3, Name = "In Progress", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 4, Name = "Completed", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 5, Name = "In Review", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 6, Name = "Accepted", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 7, Name = "Rejected", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 8, Name = "Blocked", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                new TaskItem { Id = 9, Name = "Closed", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
              );
        }
    }
}
