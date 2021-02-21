using System;
using System.Collections.Generic;
using MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class TaskItemAssignee
    {
        public int Id { get; set; }
        public int? TaskItemId { get; set; }
        public int? SystemUserId { get; set; }
        public int? AssignedByUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual TaskItem TaskItem { get; set; }
        public virtual SystemUser SystemUser { get; set; }
    }

public partial class TaskItemAssigneeConfiguration : IEntityTypeConfiguration<TaskItemAssignee>
{
    public void Configure(EntityTypeBuilder<TaskItemAssignee> builder)
    {
         builder.ToTable("TaskItemAssignee");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            
           
            builder.HasOne(d => d.TaskItem)
                    .WithMany(p => p.TaskItemAssignee)
                    .HasForeignKey(d => d.TaskItemId)
                    .HasConstraintName("FK_TaskItemAssignee_TaskItem");

                builder.HasOne(d => d.SystemUser)
                    .WithMany(p => p.TaskItemAssignee)
                    .HasForeignKey(d => d.SystemUserId)
                    .HasConstraintName("FK_TaskItemAssignee_SystemUser");

            builder.HasOne(d => d.SystemUser)
                   .WithMany(p => p.TaskItemAssignee)
                   .HasForeignKey(d => d.AssignedByUserId)
                   .HasConstraintName("FK_TaskItemAssignee_AssignedByUser");

        }

}
public static partial class Seeder
{
}
}
