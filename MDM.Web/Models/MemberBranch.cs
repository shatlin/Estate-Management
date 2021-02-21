using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberBranch
    {
        public MemberBranch()
        {
            Member = new HashSet<MemberUser>();
            MemberAddress = new HashSet<MemberAddress>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }


        public virtual ICollection<MemberUser> Member { get; set; }
        public virtual ICollection<MemberAddress> MemberAddress { get; set; }
    }
    public partial class MemberBranchConfiguration : IEntityTypeConfiguration<MemberBranch>
    {
        public void Configure(EntityTypeBuilder<MemberBranch> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(100);

        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberBranch(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberBranch>().HasData(
                new MemberBranch { Id = 1, Name = "Central Regions", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 2, Name = "Eastern Cape", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 3, Name = "Gauteng", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 4, Name = "International", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 5, Name = "KwaZulu Natal", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 6, Name = "Limpopo", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 7, Name = "Mpumalanga", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 8, Name = "Namibia", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 9, Name = "Western Cape", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 10, Name = "Free State", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 11, Name = "Head Office", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 12, Name = "North West", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 13, Name = "Northern Cape", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new MemberBranch { Id = 14, Name = "Johannesburg", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }


                   );
        }
    }
}
