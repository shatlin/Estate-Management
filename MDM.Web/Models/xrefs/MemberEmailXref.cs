using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberEmailXref
    {
        public int Id { get; set; }
        public int? RelatedEntityId { get; set; }
        public int? RelatedToId { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class MemberEmailConfiguration : IEntityTypeConfiguration<MemberEmailXref>
    {
        public void Configure(EntityTypeBuilder<MemberEmailXref> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Body).HasColumnType("TEXT").IsRequired(false);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.RelatedTo)
                .WithMany(p => p.MemberEmailXref)
                .HasForeignKey(d => d.RelatedToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberEmailXref_RelatedTo");

        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberEmailXref(this ModelBuilder modelBuilder)
        {

        }
    }
}

