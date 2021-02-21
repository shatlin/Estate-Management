using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class DisabilityMemberXref
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? DisabilityLevelId { get; set; }
        public int? DisabilityId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Disability Disability { get; set; }
        public virtual DisabilityLevel DisabilityLevel { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class DisabilityMemberXrefConfiguration : IEntityTypeConfiguration<DisabilityMemberXref>
{
    public void Configure(EntityTypeBuilder<DisabilityMemberXref> builder)
    {
         builder.ToTable("DisabilityMemberXref");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Disability)
                    .WithMany(p => p.DisabilityMemberXref)
                    .HasForeignKey(d => d.DisabilityId)
                    .HasConstraintName("FK_DisabilityMemberXref_Disability");

            builder.HasOne(d => d.DisabilityLevel)
                   .WithMany(p => p.DisabilityMemberXref)
                   .HasForeignKey(d => d.DisabilityLevelId)
                   .HasConstraintName("FK_DisabilityMemberXref_DisabilityLevel");

            builder.HasOne(d => d.Member)
                    .WithMany(p => p.DisabilityMemberXref)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_DisabilityMemberXref_Member");

    }

}
public static partial class Seeder
{
    public static void SeedDisabilityMemberXref(this ModelBuilder modelBuilder)
    {

    }
}
}
