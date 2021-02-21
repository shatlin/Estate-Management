using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EmailType
    {
        public EmailType()
        {
            EmailCcrule = new HashSet<EmailCcrule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<EmailCcrule> EmailCcrule { get; set; }
    }
    public partial class EmailTypeConfiguration : IEntityTypeConfiguration<EmailType>
    {
        public void Configure(EntityTypeBuilder<EmailType> builder)
        {
 builder.Property(e => e.Id).HasColumnName("id");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
        }

    }
    public static partial class Seeder
    {
        public static void SeedEmailType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailType>().HasData
                            (
                            new EmailType { Id = 1, Name = "Personal", Description = "Personal E-mail", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                            new EmailType { Id = 2, Name = "Work", Description = "Work E-mail", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                            new EmailType { Id = 3, Name = "Business", Description = "Business E-mail", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }
                            );
        }
    }
}
