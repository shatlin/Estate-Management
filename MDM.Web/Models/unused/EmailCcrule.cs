using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class EmailCcrule
    {
        public int Id { get; set; }
        public int EmailTypeId { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual EmailType EmailType { get; set; }
        public virtual Role Role { get; set; }
    }
    public partial class EmailCcruleConfiguration : IEntityTypeConfiguration<EmailCcrule>
    {
        public void Configure(EntityTypeBuilder<EmailCcrule> builder)
        {
 builder.ToTable("EmailCCRule");

                builder.Property(e => e.Id).HasColumnName("id");

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.HasOne(d => d.EmailType)
                    .WithMany(p => p.EmailCcrule)
                    .HasForeignKey(d => d.EmailTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailCCRule_EmailType");

                builder.HasOne(d => d.Role)
                    .WithMany(p => p.EmailCcrule)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailCCRule_Role");
        }

    }
    public static partial class Seeder
    {
        public static void SeedEmailCcrule(this ModelBuilder modelBuilder)
        {

        }
    }
}
