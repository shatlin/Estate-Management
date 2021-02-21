using System;
using System.Collections.Generic;
using MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class TaskItemFile
    {
        public int Id { get; set; }
        public int? TaskItemId { get; set; }
        public int? SystemUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? FileTypeId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Notes { get; set; }

        public virtual TaskItem TaskItem { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual FileType FileType { get; set; }
    }

public partial class TaskItemFileConfiguration : IEntityTypeConfiguration<TaskItemFile>
{
    public void Configure(EntityTypeBuilder<TaskItemFile> builder)
    {
         builder.ToTable("TaskItemFile");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            
           
            builder.HasOne(d => d.TaskItem)
                    .WithMany(p => p.TaskItemFile)
                    .HasForeignKey(d => d.TaskItemId)
                    .HasConstraintName("FK_TaskItemFile_TaskItem");

                builder.HasOne(d => d.SystemUser)
                    .WithMany(p => p.TaskItemFile)
                    .HasForeignKey(d => d.SystemUserId)
                    .HasConstraintName("FK_TaskItemFile_SystemUser");

            builder.HasOne(d => d.FileType)
                  .WithMany(p => p.TaskItemFile)
                  .HasForeignKey(d => d.FileTypeId)
                  .HasConstraintName("FK_TaskItemFile_FileType");

        }

}
public static partial class Seeder
{
}
}
