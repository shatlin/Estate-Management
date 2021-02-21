using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace MM.ClientModels
{
    public partial class Address
    {
        public Address()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public int? RelatedEntityId { get; set; }
        public int? RelatedToId { get; set; }

        [Display(Name = "Address Type", Prompt = "Select Address Type")]
        //[Required(ErrorMessage = "Address Type is required")]
        public int? AddressTypeId { get; set; }

        [Display(Name = "Address Line 1", Prompt = "Door No / Building Name")]
        //[Required(ErrorMessage = "Address Line 1 is required")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2", Prompt = "Lane / Street Name")]
        //[Required(ErrorMessage = "Address Line 2 is required")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3", Prompt = "Address Line 3")]
        //[Required(ErrorMessage = "Address Line 3 is required")]
        public string AddressLine3 { get; set; }

        [Display(Name = "Suburb", Prompt = "Enter Suburb")]
        //[Required(ErrorMessage = "Suburb is required")]
        public string Suburb { get; set; }

        [Display(Name = "Town/City", Prompt = "Enter City Name")]
        //[Required(ErrorMessage = "City is required")]
        public int? CityId { get; set; }

        [Display(Name = "Province", Prompt = "Select Province")]
        //[Required(ErrorMessage = "Province is required")]
        public int? StateId { get; set; }

        [Display(Name = "Country", Prompt = "Select Country")]
        //[Required(ErrorMessage = "Country is required")]
        public int? CountryId { get; set; }

        [Display(Name = "Postal Code", Prompt = "Enter Postal Code")]
        //[Required(ErrorMessage = "Postal Code is required")]
        public string PostalCode { get; set; }

        [Display(Name = "Primary Contact Number", Prompt = "Enter Primary Contact No")]
        //[Required(ErrorMessage = "Primary Contact No is required")]
        public string PrimaryContactNo { get; set; }

        [Display(Name = "Secondary Contact Number", Prompt = "Enter Secondary Contact No")]
        //[Required(ErrorMessage = "Secondary Contact No is required")]
        public string SecondaryContactNo { get; set; }

        [Display(Name = "Primary Email", Prompt = "Enter Primary Email")]
        //[Required(ErrorMessage = "Primary is required")]
        public string PrimaryEmail { get; set; }

        [Display(Name = "Secondary Email", Prompt = "Enter Secondary Email")]
        //[Required(ErrorMessage = "Secondary Email is required")]
        public string SecondaryEmail { get; set; }

        [Display(Name = "Fax Number", Prompt = "Enter Fax No")]
        //[Required(ErrorMessage = "Fax No is required")]
        public string FaxNumber { get; set; }

        [Display(Name = "GPS Coordinates", Prompt = "Enter GPS Coordinates")]
        //[Required(ErrorMessage = "GPS Coordinates is required")]
        public string Gpscoordinates { get; set; }

        [Display(Name = "City", Prompt = "Enter City Name")]
        //[Required(ErrorMessage = "City Name is required")]
        public string CityName { get; set; }

        [Display(Name = "State", Prompt = "Enter State Name")]
        //[Required(ErrorMessage = "State Name is required")]
        public string StateName { get; set; }

        [Display(Name = "Country", Prompt = "Select Country Name")]
        //[Required(ErrorMessage = "Country Name is required")]
        public string CountryName { get; set; }

        [Display(Name = "Province", Prompt = "Select Province Name")]
        //[Required(ErrorMessage = "Province Name is required")]
        public string Province { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual City City { get; set; }
        public virtual RelatedTo RelatedTo { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
    public partial class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.Property(e => e.AddressLine1).HasMaxLength(200);
            builder.Property(e => e.AddressLine2).HasMaxLength(200);
            builder.Property(e => e.AddressLine3).HasMaxLength(200);

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

          

            builder.HasOne(d => d.AddressType)
                .WithMany(p => p.Address)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_AddressType");

            builder.HasOne(d => d.City)
                .WithMany(p => p.Address)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Address_City");

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Address)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Country");

            builder.HasOne(d => d.State)
                .WithMany(p => p.Address)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_State");

            builder.HasOne(d => d.RelatedTo)
                   .WithMany(p => p.Address)
                   .HasForeignKey(d => d.RelatedToId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Address_RelatedTo");

        }

    }
    public static partial class Seeder
    {
        public static void SeedAddress(this ModelBuilder modelBuilder)
        {
        }
    }
}

