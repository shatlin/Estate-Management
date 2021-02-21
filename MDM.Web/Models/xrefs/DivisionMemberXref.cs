using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class DivisionMemberXref
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? DivisonId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Division Division { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class DivisionMemberXrefConfiguration : IEntityTypeConfiguration<DivisionMemberXref>
{
    public void Configure(EntityTypeBuilder<DivisionMemberXref> builder)
    {
         builder.ToTable("DivisionMemberXref");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Division)
                    .WithMany(p => p.DivisionMemberXref)
                    .HasForeignKey(d => d.DivisonId)
                    .HasConstraintName("FK_DivisionMemberXref_Division");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.DivisionMemberXref)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_DivisionMemberXref_Member");

    }

}
public static partial class Seeder
{
    public static void SeedDivisionMemberXref(this ModelBuilder modelBuilder)
    {

    }
}
}
