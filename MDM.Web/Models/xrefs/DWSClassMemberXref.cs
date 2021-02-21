using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class DWSClassMemberXref
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? DWSClassId { get; set; }
        public DateTime? ClassDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual DWSClass DWSClass { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class DWSClassMemberXrefConfiguration : IEntityTypeConfiguration<DWSClassMemberXref>
{
    public void Configure(EntityTypeBuilder<DWSClassMemberXref> builder)
    {
         builder.ToTable("DWSClassMemberXref");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.DWSClass)
                    .WithMany(p => p.DWSClassMemberXref)
                    .HasForeignKey(d => d.DWSClassId)
                    .HasConstraintName("FK_DWSClassMemberXref_DWSClass");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.DWSClassMemberXref)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_DWSClassMemberXref_Member");

    }

}
public static partial class Seeder
{
    public static void SeedDWSClassMemberXref(this ModelBuilder modelBuilder)
    {

    }
}
}
