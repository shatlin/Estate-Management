using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class QualificationEnrolmentCategory
    {
        public QualificationEnrolmentCategory()
        {
            MemberQualificationXref = new HashSet<MemberQualificationXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberQualificationXref> MemberQualificationXref { get; set; }
    }

    public partial class QualificationEnrolmentCategoryConfiguration : IEntityTypeConfiguration<QualificationEnrolmentCategory>
    {
        public void Configure(EntityTypeBuilder<QualificationEnrolmentCategory> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
        }
    }

    public static partial class Seeder
    {
        public static void SeedQualificationEnrolmentCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualificationEnrolmentCategory>().HasData(
                new QualificationEnrolmentCategory { Id = 1, Name = "FullTime", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new QualificationEnrolmentCategory { Id = 2, Name = "PartTime", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );
        }
    }
}
