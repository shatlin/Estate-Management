using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class DWSClass
    {
        public DWSClass()
        {
            DWSClassMemberXref = new HashSet<DWSClassMemberXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<DWSClassMemberXref> DWSClassMemberXref { get; set; }
    }

    public partial class DWSClassConfiguration : IEntityTypeConfiguration<DWSClass>
    {
        public void Configure(EntityTypeBuilder<DWSClass> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15);

        }

    }

    public static partial class Seeder
    {
        public static void SeedDWSClass(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DWSClass>().HasData(
                new DWSClass { Id = 1, Name = "Class I", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DWSClass { Id = 2, Name = "Class II",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DWSClass { Id = 3, Name = "Class III", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DWSClass { Id = 4, Name = "Class IV", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DWSClass { Id = 5, Name = "ClassV", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new DWSClass { Id = 6, Name = "Class VI",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );
        }
    }
}
