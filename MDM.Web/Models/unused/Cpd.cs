using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Cpd
    {
        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public int RelatedRecordId { get; set; }
        public int MemberId { get; set; }
        public int Cpdearned { get; set; }
        public int CpdawardedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ClientUser CpdawardedBy { get; set; }
        public virtual MemberUser Member { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class CpdConfiguration : IEntityTypeConfiguration<Cpd>
    {
        public void Configure(EntityTypeBuilder<Cpd> builder)
        {
            builder.ToTable("CPD");

            builder.Property(e => e.CpdawardedById).HasColumnName("CPDAwardedById");

            builder.Property(e => e.Cpdearned).HasColumnName("CPDEarned");

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.CpdawardedBy)
                .WithMany(p => p.Cpd)
                .HasForeignKey(d => d.CpdawardedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPD_User");

            builder.HasOne(d => d.Member)
                .WithMany(p => p.Cpd)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPD_Member");

            builder.HasOne(d => d.RelatedTo)
                .WithMany(p => p.Cpd)
                .HasForeignKey(d => d.RelatedToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPD_RelatedTo");
        }

    }
    public static partial class Seeder
    {
        public static void SeedCpd(this ModelBuilder modelBuilder)
        {

        }
    }
}
