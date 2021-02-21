using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class ClientBranch
    {
        public ClientBranch()
        {
            MemberUser = new HashSet<MemberUser>();
            Organization = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<MemberUser> MemberUser { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
    }

    public partial class ClientBranchConfiguration : IEntityTypeConfiguration<ClientBranch>
    {
        public void Configure(EntityTypeBuilder<ClientBranch> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

        }


    }

    public static partial class Seeder
    {
        public static void SeedClientBranch(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientBranch>().HasData(
                  new ClientBranch { Id = 1, Name = "Gauteng", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new ClientBranch { Id = 2, Name = "Limpopo", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                   new ClientBranch { Id = 3, Name = "KwaZulu Natal", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new ClientBranch { Id = 4, Name = "Western Cape", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                   new ClientBranch { Id = 5, Name = "Central Regions", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new ClientBranch { Id = 6, Name = "Eastern Cape", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new ClientBranch { Id = 7, Name = "Mpumalanga", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new ClientBranch { Id = 8, Name = "International", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                  new ClientBranch { Id = 9, Name = "Namibia", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
              );
        }
    }
}
