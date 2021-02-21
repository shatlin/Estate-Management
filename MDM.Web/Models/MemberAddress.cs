using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class MemberAddress
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? OrganizationId { get; set; }
        public int? BranchId { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string BuidlingName { get; set; }
        public string ComplexName { get; set; }
        public string StreetName { get; set; }
        public int? CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }
        public string PrimaryContactNo { get; set; }
        public string SecondaryContactNo { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string FaxNumber { get; set; }
        public string Gpscoordinates { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual MemberBranch Branch { get; set; }
        public virtual MemberUser Member { get; set; }
        public virtual Organization Organization { get; set; }
    }

    public partial class MemberAddressConfiguration : IEntityTypeConfiguration<MemberAddress>
    {
        public void Configure(EntityTypeBuilder<MemberAddress> builder)
        {
                builder.Property(e => e.AddressLine1).HasMaxLength(100);

                builder.Property(e => e.AddressLine2).HasMaxLength(100);

                builder.Property(e => e.BuidlingName).HasMaxLength(100);

                builder.Property(e => e.ComplexName).HasMaxLength(100);

                builder.Property(e => e.CreatedOn).HasColumnType("datetime");

                builder.Property(e => e.FaxNumber).HasMaxLength(50);

                builder.Property(e => e.Gpscoordinates)
                    .HasColumnName("GPSCoordinates")
                    .HasMaxLength(50);

                builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

                builder.Property(e => e.PostalCode).HasMaxLength(50);

                builder.Property(e => e.PrimaryContactNo).HasMaxLength(50);

                builder.Property(e => e.PrimaryEmail).HasMaxLength(50);

                builder.Property(e => e.SecondaryContactNo).HasMaxLength(50);

                builder.Property(e => e.SecondaryEmail).HasMaxLength(50);

                builder.Property(e => e.StreetName).HasMaxLength(100);

                builder.HasOne(d => d.AddressType)
                    .WithMany(p => p.MemberAddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberAddress_AddressType");

                builder.HasOne(d => d.Branch)
                    .WithMany(p => p.MemberAddress)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_MemberAddress_MemberBranch");

                builder.HasOne(d => d.Member)
                    .WithMany(p => p.MemberAddress)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_MemberAddress_Member");

                builder.HasOne(d => d.Organization)
                    .WithMany(p => p.MemberAddress)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_MemberAddress_Organization");

        }

    }
    public static partial class Seeder
    {
        public static void SeedMemberAddress(this ModelBuilder modelBuilder)
        {

        }
    }
}
