using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;

namespace MM.ClientModels
{



    public partial class NonIndividualVM
    {

        public NonIndividualVM()
        {

        }

        public string MemberStatusName { get; set; }
        public string OrganizationGrade { get; set; }  
        public string OrgMemberCode { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string PrimaryContactFax { get; set; }
        public string WebSite { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }


        
        [Display(Name = "Address Line 1")]
        public string PhysicalAddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string PhysicalAddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string PhysicalAddressLine3 { get; set; }

        [Display(Name = "Suburb")]
        public string PhysicalSuburb { get; set; }

        [Display(Name = "Town/City")]
        public string PhysicalCity { get; set; }

        [Display(Name = "Province")]
        public string PhysicalProvince { get; set; }

        [Display(Name = "Country")]
        public int? PhysicalCountryId { get; set; }

        [Display(Name = "Postal Code")]
        public string PhysicalPostalCode { get; set; }

        
        public string PhysicalCountryName { get; set; }

        public string PostalAddressLine1 { get; set; }

      
        public string PostalAddressLine2 { get; set; }

        public string PostalAddressLine3 { get; set; }


        public string PostalSuburb { get; set; }

      
        public string PostalCity { get; set; }

        public string PostalProvince { get; set; }
        
        public int? PostalCountryId { get; set; }

        public string PostalCountryName { get; set; }
     
        public string PostalPostalCode { get; set; }

        public string PrimaryContact { get; set; }
        public string ContactPerson { get; set; }
        public string PrimaryContactEmail { get; set; }
        public string PrimaryContactMobile { get; set; }
        public string PrimaryContactJobTitle { get; set; }
        public string AccountBalance { get; set; }
        public DateTime? CancelapplicationNopayDate { get; set; }
        public DateTime? ApplicationCancelledMemberfeeNotpaidDate { get; set; }
        public string BranchMembership { get; set; }
        public DateTime? CreatedOn { get; set; }

    }


}
