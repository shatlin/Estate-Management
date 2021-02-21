using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class AccountType
    {
        public AccountType()
        {
            BankingDetail = new HashSet<BankingDetail>();
            MemberBankingDetail = new HashSet<MemberBankingDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<BankingDetail> BankingDetail { get; set; }
        public virtual ICollection<MemberBankingDetail> MemberBankingDetail { get; set; }
    }


    public partial class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {

          
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(100);
            
        }

    }
    public static partial class Seeder
    {
        public static void SeedAccountType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasData(
              new AccountType { Id = 1, Name = "Savings Account",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
              new AccountType { Id = 2, Name = "Cheque Account",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
              new AccountType { Id = 3, Name = "Corporate Account",  CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
              new AccountType { Id = 4, Name = "Business Account", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
            );
        }
    }
}
