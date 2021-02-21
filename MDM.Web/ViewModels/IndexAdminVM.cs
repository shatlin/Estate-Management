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



    public partial class IndexAdminVM
    {
        // other objects required in cs
        // Core business List
        // Additonal Contacts (All members belonging to this organization)
        //vlounteer list

        public IndexAdminVM()
        {

        }

        //*****Required Fields****//
        public int Id { get; set; }

        //public decimal? AccountBalanceOftheCompany { get; set; }

        //[Display(Name = "Company Name", Prompt = "Enter Company Name")]
        //[Required(ErrorMessage = "Company Name is required")]
        //public string CompanyName { get; set; }


        //public string CompanyRegistrationNumber { get; set; }
        //public string CompanyVATNumber { get; set; }

        //public string CompanyPhoneNumber { get; set; }
        //public string CompanyAddress { get; set; }
        //public string CompanyPostalCode { get; set; }







        //This should be mapped to Membership Categories in screen
        [Display(Name = "Membership Type", Prompt = "Select Membership Type")]
        [Required(ErrorMessage = "Membership Type is required")]
        public int? MembershipTypeId { get; set; }


        //This should be mapped to Membership Grade in screen
        public int? MembershipGradeId { get; set; }

        //This should be mapped to MembershipUser Table
        public int? PrimaryContactId { get; set; }

        //This should be mapped to MembershipUser Table
        public int? ContactPersonId { get; set; }


        [Display(Name = "Job Title", Prompt = "Enter Job Title")]
        //[Required(ErrorMessage = "Job Title is required")]
        public string JobTitle { get; set; }



        [Display(Name = "Email ID", Prompt = "Enter Email ID")]
        [Required(ErrorMessage = "Email ID is required")]
        public string Email { get; set; }

        [Display(Name = "Secondary Email ID", Prompt = "Enter Secondary Email ID")]
        //[Required(ErrorMessage = "Secondary Email ID is required")]
        public string SecondaryEmail { get; set; }


        [Display(Name = "Mobile Phone Number", Prompt = "Enter Mobile Number")]
        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }

        [Display(Name = "Home Phone Number", Prompt = "Enter Home Phone")]
        //[Required(ErrorMessage = "Home Phone Number is required")]
        public string HomePhoneNumber { get; set; }


        [Display(Name = "Business Phone Number", Prompt = "Enter Business Phone")]
        //[Required(ErrorMessage = "Business Phone Number is required")]
        public string BusinessPhoneNumber { get; set; }


        [Display(Name = "Fax Number", Prompt = "Enter Fax Number")]
        //[Required(ErrorMessage = "Fax Number is required")]
        public string FAXNumber { get; set; }

        [Display(Name = "Fax To Email", Prompt = "Enter Fax to Email")]
        //[Required(ErrorMessage = "Fax to email is required")]
        public string FaxToEmail { get; set; }

        public string WebSite { get; set; }

        public bool? CanWeSendCommunication { get; set; }

        public bool? MembershipFeeInvoicedToCompany { get; set; }


        [Display(Name = "Terms Accepted")]
        [Required(ErrorMessage = "You need to accept terms before submitting")]
        public bool TermAccepted { get; set; }




        [Display(Name = "Address Line 1")]
        public string PhysicalAddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string PhysicalAddressLine2 { get; set; }

        [Display(Name = "Suburb")]
        public string PhysicalSuburb { get; set; }

        [Display(Name = "City")]
        public string PhysicalCity { get; set; }

        [Display(Name = "Province")]
        public string PhysicalProvince { get; set; }

        [Display(Name = "Country")]
        public int? PhysicalCountryId { get; set; }

        [Display(Name = "Physical Code")]
        public string PhysicalPostalCode { get; set; }


        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string PostalAddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Required(ErrorMessage = "Address Line 2 is required")]
        public string PostalAddressLine2 { get; set; }

        [Display(Name = "Suburb")]
        [Required(ErrorMessage = "Suburb is required")]
        public string PostalSuburb { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string PostalCity { get; set; }

        [Display(Name = "Province")]
        [Required(ErrorMessage = "Province is required")]
        public string PostalProvince { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public int PostalCountryId { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal Code is required")]
        public string PostalPostalCode { get; set; }

        //***Contact***//





        public int? MemberStatusId { get; set; }


        //This is membership number
        [Display(Name = "Member Code", Prompt = "Enter Member Code")]
        [Required(ErrorMessage = "Member Code is required")]
        public string MemberCode { get; set; }


        [Display(Name = "Interested In Volunteer Work")]
        //[Required(ErrorMessage = "Interested In Volunteer Work is required")]
        public bool? InterestedInVolunteerWork { get; set; }



        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Display(Name = "Branch Membership")]


        public bool? IsBranchContact { get; set; }
        public bool? IsBillingContact { get; set; }

        public bool? IsMembershipFeeInvoicedToYou { get; set; }


        [Display(Name = "Can we Publish your details")]
        public bool? PublishCompanyInAnnualMemberDirectory { get; set; }

        [Display(Name = "Volunteer Work Hours", Prompt = "Enter Work Hours")]
        //[Required(ErrorMessage = "Volunteer Work Hours is required")]
        public int? VolunteerWorkHoursId { get; set; }




        public DateTime? LastUsedInCampaignDate { get; set; }
        public bool? DonotSendMarketingMaterial { get; set; }

        public int? ReferralTypeId { get; set; }
        public string ReferralOther { get; set; }

        //This is for contact Method any drop down. Should be mapped to CommunicationType
        public int? CommunicationTypeId { get; set; }


        public bool? DoNotSMS { get; set; }

        public bool? DonotpostalMail { get; set; } //magazine
        public bool? DonotBulkPostalMail { get; set; }

        public bool? DonotBulkEmail { get; set; }
        public bool? DoNotEmail { get; set; }

        public bool? DonotPhone { get; set; }
        public bool? FollowEmail { get; set; }


        public decimal? AmountWrittenOff { get; set; }
        public DateTime? DatetWrittenOff { get; set; }


        public DateTime? ApplicationreceivedDate { get; set; }
        public bool? ApplicationFormComplete { get; set; }


        public DateTime? ProformaInvoiceEmailedDate { get; set; }

        public DateTime? AdminfeePaymentReceivedDate { get; set; }
        public bool? ProofOfpaymentReceivedandUploaded { get; set; }
        public DateTime? PaymentReminder1Date { get; set; }
        public DateTime? PaymentReminder2Date { get; set; }
        public DateTime? PaymentReminder3Date { get; set; }
        public DateTime? CancelapplicationNopayDate { get; set; }


        public DateTime? SentforGradingDate { get; set; }
        public DateTime? GradingCompletedDate { get; set; }



        public DateTime? TaxInvoicEemailedDate { get; set; }
        public DateTime? ProofofPaymentReceivedDate { get; set; }
        public DateTime? Request2MemberFee { get; set; }
        public DateTime? Request3MemberFee { get; set; }
        public DateTime? ApplicationCancelledMemberfeeNotpaidDate { get; set; }



        public DateTime? CertificateAndwelcomeLetterEmailedDate { get; set; }
        public bool? CertificateUploaded { get; set; }
        public DateTime? PostingofCertificateDate { get; set; }
        public string PostCertificateTracking { get; set; }



        public string OwnerClientUserId { get; set; }


        [Display(Name = "Client Branch", Prompt = "Select Client Branch")]
        public int? ClientBranchId { get; set; }



        [Display(Name = "Notes", Prompt = "Enter Notes")]
        //[Required(ErrorMessage = "Note is required")]
        public string Notes { get; set; }

    }


}
