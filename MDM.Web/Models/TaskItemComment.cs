using System;
using System.Collections.Generic;
using MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class TaskItemComment : BaseModel
    {
        public int Id { get; set; }
        public int? TaskItemId { get; set; }
        public int? SystemUserId { get; set; }
        public string Comment { get; set; }

        public virtual TaskItem TaskItem { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual FileType FileType { get; set; }
    }

public partial class TaskItemCommentConfiguration : IEntityTypeConfiguration<TaskItemComment>
{
    public void Configure(EntityTypeBuilder<TaskItemComment> builder)
    {
         builder.ToTable("TaskItemComment");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Comment)
                  .IsRequired()
                  .HasMaxLength(2000);

            builder.HasOne(d => d.TaskItem)
                    .WithMany(p => p.TaskItemComment)
                    .HasForeignKey(d => d.TaskItemId)
                    .HasConstraintName("FK_TaskItemComment_TaskItem");

                builder.HasOne(d => d.SystemUser)
                    .WithMany(p => p.TaskItemComment)
                    .HasForeignKey(d => d.SystemUserId)
                    .HasConstraintName("FK_TaskItemComment_SystemUser");



        }

}
public static partial class Seeder
{
}
}
