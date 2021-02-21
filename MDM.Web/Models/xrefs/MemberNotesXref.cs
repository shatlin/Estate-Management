using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberNotesXref
    {
        public int Id { get; set; }
        public int? RelatedEntityId { get; set; }
        public int? RelatedToId { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class MemberNotesConfiguration : IEntityTypeConfiguration<MemberNotesXref>
    {
        public void Configure(EntityTypeBuilder<MemberNotesXref> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Subject).IsRequired(false).HasMaxLength(1000);
            builder.Property(e => e.Notes).IsRequired(false).HasColumnType("Text");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.RelatedTo)
                .WithMany(p => p.MemberNotesXref)
                .HasForeignKey(d => d.RelatedToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberNotesXref_RelatedTo");


        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberNotesXRef(this ModelBuilder modelBuilder)
        {

        }
    }
}

