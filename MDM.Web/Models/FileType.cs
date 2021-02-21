using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class FileType
    {
        public FileType()
        {
            MemberFile = new HashSet<MemberFileXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberFileXref> MemberFile { get; set; }
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
                              new FileType { Id = 1, Name = "ID Document", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                              new FileType { Id = 2, Name = "Certificates (Completed Qualifications)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                              new FileType { Id = 3, Name = "Proof of DWS Registration (If Applicable)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                              new FileType { Id = 4, Name = "Proof of Registration ( If fulltime Student)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                              new FileType { Id = 5, Name = "Proof of Payment", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                               new FileType { Id = 6, Name = "Note", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                                 new FileType { Id = 7, Name = "StudentLetter", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                                 );
        }
    }
}
