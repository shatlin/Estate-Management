using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberRefereeXref
    {
        public int Id { get; set; }
        public int? RelatedEntityId { get; set; }
        public int? RelatedToId { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOfEmployer { get; set; }
        public string PositionOfReferree { get; set; }
        public string ProfessionalRegistrationNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Title { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }


        public virtual RelatedTo RelatedTo { get; set; }
    }
    public partial class MemberRefereeConfiguration : IEntityTypeConfiguration<MemberRefereeXref>
    {
        public void Configure(EntityTypeBuilder<MemberRefereeXref> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.CellPhone).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.CellPhone).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.Initials).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.FirstName).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.NameOfEmployer).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.PositionOfReferree).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.ProfessionalRegistrationNumber).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.TelephoneNumber).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.Title).IsRequired(false).HasMaxLength(10);

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.HasOne(d => d.RelatedTo)
              .WithMany(p => p.MemberRefereeXref)
              .HasForeignKey(d => d.RelatedToId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_MemberRefereeXref_RelatedTo");


        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberRefereeXref(this ModelBuilder modelBuilder)
        {

        }
    }
}

