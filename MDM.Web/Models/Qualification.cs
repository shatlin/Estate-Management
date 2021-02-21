using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class Qualification
    {
        public Qualification()
        {
            MemberQualificationXref = new HashSet<MemberQualificationXref>();
            MemberUser = new HashSet<MemberUser>();
            }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
                public virtual ICollection<MemberUser> MemberUser { get; set; }

        public virtual ICollection<MemberQualificationXref> MemberQualificationXref { get; set; }
    }


    public partial class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
  builder.Property(e => e.CreatedOn).HasColumnType("datetime");

              

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name).HasMaxLength(100);
        }

    }
    public static partial class Seeder
    {
        public static void SeedQualification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().HasData(
             new Qualification { Id = 1, Name = "Matric/Grade 12", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 2, Name = "1 year diploma/certificate", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 3, Name = "3 year diploma/degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 4, Name = "4 year degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 5, Name = "Postgraduate diploma", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 6, Name = "Honours degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 7, Name = "Master’s degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
             new Qualification { Id = 8, Name = "Dr/PHD degree", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
            
           );
        }
    }
}


