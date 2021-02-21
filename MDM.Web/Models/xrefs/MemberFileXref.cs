using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberFileXref
    {
        public int Id { get; set; }
        public int? RelatedEntityId { get; set; }
        public int? RelatedToId { get; set; }
        public int? FileTypeId { get; set; }
        public string FileName { get; set; }
        public string Notes { get; set; }
        public string Subject { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual FileType FileType { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class MemberFileConfiguration : IEntityTypeConfiguration<MemberFileXref>
    {
        public void Configure(EntityTypeBuilder<MemberFileXref> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.FilePath).IsRequired(false).HasMaxLength(1000);
            builder.Property(e => e.Notes).IsRequired(false).HasColumnType("Text");
            builder.Property(e => e.Subject).IsRequired(false).HasMaxLength(1000);
            builder.Property(e => e.FileName).IsRequired(false).HasMaxLength(1000);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.FileType)
                .WithMany(p => p.MemberFile)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberFileXref_FileType");

            builder.HasOne(d => d.RelatedTo)
              .WithMany(p => p.MemberFileXref)
              .HasForeignKey(d => d.RelatedToId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_MemberFileXref_RelatedTo");


        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberFileXref(this ModelBuilder modelBuilder)
        {

        }
    }
}

