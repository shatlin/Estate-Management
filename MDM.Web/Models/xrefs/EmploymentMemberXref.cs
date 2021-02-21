using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class EmploymentMemberXref
    {
        public EmploymentMemberXref()
        {
            
        }
        public int Id { get; set; }
        public string Designation { get; set; }
        public string EmployerName { get; set; }
        public string CompanyTelephoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string YourDuties { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public int MemberUserId { get; set; }
        public virtual MemberUser MemberUser { get; set; }

        public int? EmploymentCategoryId { get; set; }
        public virtual EmploymentCategory EmploymentCategory { get; set; }
    }

    public partial class EmploymentMemberXrefConfiguration : IEntityTypeConfiguration<EmploymentMemberXref>
    {
        public void Configure(EntityTypeBuilder<EmploymentMemberXref> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Designation)
                    .IsRequired(false)
                    .HasMaxLength(120);

              builder.Property(e => e.YourDuties)
                    .IsRequired(false)
                    .HasMaxLength(2500);

            builder.Property(e => e.EmployerName)
               .IsRequired(false)
               .HasMaxLength(100);

            builder.HasOne(d => d.MemberUser)
                .WithMany(p => p.EmploymentMemberXref)
                .HasForeignKey(d => d.MemberUserId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmploymentMemberXref_MemberUser");

            builder.HasOne(d => d.EmploymentCategory)
                .WithMany(p => p.EmploymentMemberXref)
                .HasForeignKey(d => d.EmploymentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmploymentMemberXref_EmploymentCategory");


        }
    }

    public static partial class Seeder
    {
        public static void SeedEmploymentMemberXref(this ModelBuilder modelBuilder)
        {
        
        }
    }
}
