using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class QualificationType
    {
        public QualificationType()
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

    public partial class QualificationTypeConfiguration : IEntityTypeConfiguration<QualificationType>
    {
        public void Configure(EntityTypeBuilder<QualificationType> builder)
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
        public static void SeedQualificationType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualificationType>().HasData(
             new QualificationType{ Id = 1, Name = "Matric/Grade 12", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 2, Name = "1 year diploma/certificate", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 3, Name = "3 year diploma/degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 4, Name = "4 year degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 5, Name = "Postgraduate diploma", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 6, Name = "Honours degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 7, Name = "Master’s degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new QualificationType{ Id = 8, Name = "Dr/PHD degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );              
        }                     
    }
}
