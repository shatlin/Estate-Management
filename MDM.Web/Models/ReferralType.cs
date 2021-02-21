using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class ReferralType
    {
        public ReferralType()
        {
            Member = new HashSet<MemberUser>();
            User = new HashSet<ClientUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberUser> Member { get; set; }
        public virtual ICollection<ClientUser> User { get; set; }
    }


    public partial class ReferralTypeConfiguration : IEntityTypeConfiguration<ReferralType>
    {
        public void Configure(EntityTypeBuilder<ReferralType> builder)
        {
               builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .HasMaxLength(100);
                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
                builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

        }

    }
    public static partial class Seeder
    {
        public static void SeedReferralType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReferralType>().HasData(
                new ReferralType { Id = 1, Name = "Word of Mouth.", Description = "Word of Mouth", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ReferralType { Id = 2, Name = "WISA NewsLetter", Description = "WISA NewsLetter", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ReferralType { Id = 3, Name = "WISA Website", Description = "WISA WebSite", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ReferralType { Id = 4, Name = "WISA Event (Conference, Branch or Division Event)", Description = "WISA Event (Conference, Branch or Division Event)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                new ReferralType { Id = 5, Name = "Other", Description = "Other", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
               
                 );

        }
    }
}

