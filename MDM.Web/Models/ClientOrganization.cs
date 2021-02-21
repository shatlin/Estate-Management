using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MM.ClientModels
{
    public partial class ClientOrganization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AgreedToTerms { get; set; }
        public bool IsActive { get; set; }
        public int? DateSettingId { get; set; }
        public int? TimeFormatId { get; set; }
        public int? ClientTimeZoneId { get; set; }
        public int? CurrencyId { get; set; }
        public int? ClientOrganizationTypeId { get; set; }
        public int? CurrencyDecimalPlaces { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual DateSetting DateSetting { get; set; }
        public virtual TimeFormat TimeFormat { get; set; }
        public virtual ClientTimeZone ClientTimeZone { get; set; }
        public virtual ClientOrganizationType ClientOrganizationType { get; set; }

    }
    public partial class ClientOrganizationConfiguration : IEntityTypeConfiguration<ClientOrganization>
    {
        public void Configure(EntityTypeBuilder<ClientOrganization> builder)
        {
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ClientOrganizationTypeId).IsRequired(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(d => d.Currency)
                .WithMany(p => p.Client)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_Client_Currency");

            builder.HasOne(d => d.DateSetting)
                .WithMany(p => p.Client)
                .HasForeignKey(d => d.DateSettingId)
                .HasConstraintName("FK_Client_DateSetting");

            builder.HasOne(d => d.TimeFormat)
                .WithMany(p => p.Client)
                .HasForeignKey(d => d.TimeFormatId)
                .HasConstraintName("FK_Client_TimeFormat");

            builder.HasOne(d => d.ClientTimeZone)
                .WithMany(p => p.Client)
                .HasForeignKey(d => d.ClientTimeZoneId)
                .HasConstraintName("FK_Client_TimeZone");

            builder.HasOne(d => d.ClientOrganizationType)
          .WithMany(p => p.ClientOrganization)
          .HasForeignKey(d => d.ClientOrganizationTypeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_ClientOrganization_ClientOrganizationType");
        }

    }
    public static partial class Seeder
    {
        public static void SeedClientOrganization(this ModelBuilder modelBuilder)
        {

        }
    }
}

