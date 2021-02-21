using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberAffliationXref
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? AffliationId { get; set; }
        public string MemberSpecificAffliationName { get; set; }
        public string MemberNumber { get; set; }
        public string Description { get; set; }
        public DateTime? AffliatedFrom { get; set; }
        public DateTime? AffliatedTill { get; set; }
        public bool? IsActiveAffliatedNow { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual Affliation Affliation { get; set; }
        public virtual MemberUser Member { get; set; }
    }

public partial class MemberAffliationXrefConfiguration : IEntityTypeConfiguration<MemberAffliationXref>
{
    public void Configure(EntityTypeBuilder<MemberAffliationXref> builder)
    {
         builder.ToTable("MemberAffliationXRef");

                builder.Property(e => e.AffliatedFrom).HasColumnType("datetime");

                builder.Property(e => e.AffliatedTill).HasColumnType("datetime");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.MemberNumber)
               .IsRequired(false)
               .HasMaxLength(100);

            builder.Property(e => e.Description)
                    .IsRequired(false)
                    .HasMaxLength(200);

                builder.Property(e => e.IsActiveAffliatedNow).HasColumnName("isActiveAffliatedNow");

                builder.Property(e => e.MemberSpecificAffliationName).HasMaxLength(100);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.Affliation)
                    .WithMany(p => p.MemberAffliationXref)
                    .HasForeignKey(d => d.AffliationId)
                    .HasConstraintName("FK_MemberAffliationXRef_Affliation");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MemberAffliationXref)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_MemberAffliationXRef_Member");

    }

}
public static partial class Seeder
{
    public static void SeedMemberAffliationXref(this ModelBuilder modelBuilder)
    {

    }
}
}
