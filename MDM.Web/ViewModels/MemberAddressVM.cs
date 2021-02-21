using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class MemberAddressVM
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public string MemberName { get; set; }
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string BuidlingName { get; set; }
        public string ComplexName { get; set; }
        public string StreetName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public int CountryName { get; set; }
        public string PostalCode { get; set; }
        public string PrimaryContactNo { get; set; }
        public string SecondaryContactNo { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string FaxNumber { get; set; }
        public string Gpscoordinates { get; set; }



    }


}
