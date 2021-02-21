using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberQualificationXref
    {
        public int Id { get; set; }
      
        public string MemberSpecificQualificationName { get; set; }
        public string StudentNumber { get; set; }
        public string InstituteName { get; set; }
        
        public DateTime? QualificationFrom { get; set; }
        public DateTime? QualificationTill { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public int MemberId { get; set; }
        public virtual MemberUser Member { get; set; }

        public int? QualificationCategoryId { get; set; }
        public virtual QualificationCategory QualificationCategory { get; set; }

        public int? QualificationTypeId { get; set; }
        public virtual QualificationType QualificationType { get; set; }

        public int? QualificationEnrolmentCategoryId { get; set; }
        public virtual QualificationEnrolmentCategory QualificationEnrolmentCategory { get; set; }
       
    }

    public partial class MemberQualificationXrefConfiguration : IEntityTypeConfiguration<MemberQualificationXref>
    {
        public void Configure(EntityTypeBuilder<MemberQualificationXref> builder)
        {
                 builder.ToTable("MemberQualificationXRef");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.StudentNumber)
                    .IsRequired(false)
                    .HasMaxLength(200);

                builder.Property(e => e.MemberSpecificQualificationName).IsRequired(false).HasMaxLength(100);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.QualificationFrom).HasColumnType("datetime");

                builder.Property(e => e.QualificationTill).HasColumnType("datetime");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MemberQualificationXref)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberQualificationXRef_Member");

            builder.HasOne(d => d.QualificationCategory)
                .WithMany(p => p.MemberQualificationXref)
                .HasForeignKey(d => d.QualificationCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberQualificationXRef_QualificationCategory");

            builder.HasOne(d => d.QualificationType)
                .WithMany(p => p.MemberQualificationXref)
                .HasForeignKey(d => d.QualificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberQualificationXRef_QualificationType");


            builder.HasOne(d => d.QualificationEnrolmentCategory)
                .WithMany(p => p.MemberQualificationXref)
                .HasForeignKey(d => d.QualificationEnrolmentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberQualificationXRef_QualificationEnrolmentCategory");


        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberQualificationXref(this ModelBuilder modelBuilder)
        {

        }
    }
}
