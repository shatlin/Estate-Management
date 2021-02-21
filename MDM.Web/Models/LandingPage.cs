using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class LandingPage
    {
        public int Id { get; set; }
        public int MemberShipGradeId { get; set; }
        public int PageId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MemberShipGrade MemberShipGrade { get; set; }
        public virtual Page Page { get; set; }
    }
    public partial class LandingPageConfiguration : IEntityTypeConfiguration<LandingPage>
    {
        public void Configure(EntityTypeBuilder<LandingPage> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.MemberShipGrade)
                    .WithMany(p => p.LandingPage)
                    .HasForeignKey(d => d.MemberShipGradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandingPage_MembershipGrade");

            builder.HasOne(d => d.Page)
                    .WithMany(p => p.LandingPage)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LandingPage_Page");
        }

    }
    public static partial class Seeder
    {
        public static void SeedLandingPage(this ModelBuilder modelBuilder)
        {

        }
    }
}
