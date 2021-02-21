using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class QualificationCategory
    {
        public QualificationCategory()
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

    public partial class QualificationCategoryConfiguration : IEntityTypeConfiguration<QualificationCategory>
    {
        public void Configure(EntityTypeBuilder<QualificationCategory> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
        }
    }

    public static partial class Seeder
    {
        public static void SeedQualificationCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualificationCategory>().HasData(
                new QualificationCategory { Id = 1, Name = "Current Studies",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new QualificationCategory { Id = 2, Name = "Completed Qualifications", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              
              );
        }
    }
}
