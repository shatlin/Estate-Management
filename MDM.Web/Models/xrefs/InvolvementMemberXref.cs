using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class InvolvementMemberXref
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? InvolvementId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Involvement Involvement { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class InvolvementMemberXrefConfiguration : IEntityTypeConfiguration<InvolvementMemberXref>
{
    public void Configure(EntityTypeBuilder<InvolvementMemberXref> builder)
    {
         builder.ToTable("InvolvementMemberXref");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Involvement)
                    .WithMany(p => p.InvolvementMemberXref)
                    .HasForeignKey(d => d.InvolvementId)
                    .HasConstraintName("FK_InvolvementMemberXref_Involvement");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.InvolvementMemberXref)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_InvolvementMemberXref_Member");

    }

}
public static partial class Seeder
{
    public static void SeedInvolvementMemberXref(this ModelBuilder modelBuilder)
    {

    }
}
}
