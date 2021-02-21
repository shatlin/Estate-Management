using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MDM.Models
{
    public partial class FileType
    {
        public FileType()
        {
            TaskItemFile = new HashSet<TaskItemFile>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual ICollection<TaskItemFile> TaskItemFile { get; set; }

    }

    public partial class FileTypeConfiguration : IEntityTypeConfiguration<FileType>
    {
        public void Configure(EntityTypeBuilder<FileType> builder)
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
        public static void SeedFileType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileType>().HasData(
                              new FileType { Id = 1, Name = "Document", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) },
                               new FileType { Id = 2, Name = "Note", CreatedOn = new DateTime(2021, 2, 28), ModifiedOn = new DateTime(2021, 2, 28) }
                                 );
        }
    }
}
