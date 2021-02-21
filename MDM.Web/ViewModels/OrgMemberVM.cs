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



    public partial class OrgMemberVM
    {
        // other objects required in cs
        // Core business List
        // Additonal Contacts (All members belonging to this organization)
        //vlounteer list

        public OrgMemberVM()
        {

        }

        //*****Required Fields****//
        public int Id { get; set; }

        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string WebSite { get; set; }

        [Display(Name = "VAT Number", Prompt = "Enter Company VAT Number")]
        [Required(ErrorMessage = "VAT Number is required")]
        public string TaxNumber { get; set; }

        [Display(Name = "Registration No", Prompt = "Enter Registration Number")]
        [Required(ErrorMessage = "Registration Number is required")]
        public string RegistrationNumber { get; set; }
        //This is compnayy membership number
        [Display(Name = "Member Code", Prompt = "Enter Member Code")]
        [Required(ErrorMessage = "Member Code is required")]
        public string OrgMemberCode { get; set; }

        public int? MemberStatusId { get; set; }


       
        [Display(Name = "Membership Grade")]
        public int? OrganizationGradeId { get; set; }

        
        [Display(Name = "Membership Type", Prompt = "Select Membership Type")]
        [Required(ErrorMessage = "Membership Type is required")]
        public int? OrganizationTypeId { get; set; }


        public int? CurrencyId { get; set; }

        public int? PrimaryContactId { get; set; }//Person with highest Authority
        public int? ContactPersonId { get; set; } //person with whom we can contact mainly

        public int? BillingContactId { get; set; } //Person to send Billing to

        [Display(Name = "Client Branch", Prompt = "Select Client Branch")]
        public int? ClientBranchId { get; set; }


        [Display(Name = "Terms Accepted")]
        [Required(ErrorMessage = "You need to accept terms before submitting")]
        public bool IsTermAccepted { get; set; }

        public bool? IsInvoiceSent { get; set; }

        public bool? IsMembershipFeeInvoicedToCompany { get; set; }

        [Display(Name = "Can we Publish your details")]
        public bool? PublishCompanyInAnnualMemberDirectory { get; set; }



        public decimal? AmountWrittenOff { get; set; }
        public DateTime? DatetWrittenOff { get; set; }

        public DateTime? ApplicationReceivedDate { get; set; }
        public bool? IsApplicationFormComplete { get; set; }

        public DateTime? ProformaInvoiceEmailedDate { get; set; }
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
        [Display(Name = "Application Cancellation - non payment", Prompt = "Enter Application Cancelled Memberfee Not paid Date")]
        public DateTime? ApplicationCancelledMemberfeeNotpaidDate { get; set; }
        public DateTime? CertificateAndwelcomeLetterEmailedDate { get; set; }

        public bool? IsCertificateUploaded { get; set; }
        public string OwnerClientUserId { get; set; }


        [Display(Name = "Notes", Prompt = "Enter Notes")]
        //[Required(ErrorMessage = "Note is required")]
        public string Notes { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public decimal? AccountBalance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region wisaspecific


        public bool? IsCreditOnHold { get; set; }
        public decimal? AccountBalanceBase { get; set; }
        public bool? IsmemberFeePaid { get; set; }
        public bool? IsCertificatePosted { get; set; }
        public bool? IsMemberfeeProofofpaymentSent { get; set; }
        public DateTime? MemberfeePaymentReceivedDate { get; set; }
        public DateTime? PostingofCertificateDate { get; set; }
        public DateTime? AmountDueAsAtDate { get; set; }
        public string PostCertificateTracking { get; set; }
        public bool? IsAdminFeePaid { get; set; }
        public bool? IsAdminfeeProofofpaymentSent { get; set; }
        public DateTime? AdminfeePaymentReceivedDate { get; set; }
        public string OriginalSystemRecordId { get; set; }
        public string PrimaryContactName { get; set; }
        public string ContactPersonName { get; set; }

        #endregion

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

        //***Profile Info***//
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public int TitleId { get; set; }


        [Display(Name = "Initials", Prompt = "Enter Initials")]
        //[Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }


        [Display(Name = "First Name", Prompt = "Enter First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name", Prompt = "Enter Middle Name")]
        //[Required(ErrorMessage = "Middle Name is required")] 
        public string MiddleName { get; set; }

        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }


        [Display(Name = "Date of Birth", Prompt = "Enter your Birthday")]
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime? BirthDay { get; set; }


        [Display(Name = "ID/Passport", Prompt = "Enter ID Number")]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }


        [Display(Name = "Nationality", Prompt = "Select Nationality")]
        //[Required(ErrorMessage = "Nationality is required")]
        public int? NationalityId { get; set; }
        public virtual Country Nationality { get; set; }


        [Display(Name = "Home Language", Prompt = "Select Home Language")]
        [Required(ErrorMessage = "Home Language is required")]
        public int? HomeLanguageId { get; set; }
        public virtual Language HomeLanguageName { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int GenderId { get; set; }


        [Display(Name = "Ethnicity", Prompt = "Select Ethnicity")]
        [Required(ErrorMessage = "Ethnicity is required")]
        public int? EthnicityId { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }


        [Display(Name = "Occupation", Prompt = "Enter Occupation")]
        [Required(ErrorMessage = "Occupation is required")]
        public int? OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }


        [Display(Name = "Qualification", Prompt = "Select Qualification")]
        //[Required(ErrorMessage = "Highest Qualification is required")]
        public int? HighestQualificationId { get; set; }
        //public virtual Qualification QualificationName { get; set; }

        [Display(Name = "Highest Qualification")]
        public int HighestQualitificationId { get; set; }
        public virtual Qualification QualificationName { get; set; }

        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        //[Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }


        [Display(Name = "Job Title", Prompt = "Enter Job Title")]
        //[Required(ErrorMessage = "Job Title is required")]
        public string JobTitle { get; set; }

        //***Contact***//

      

        [Display(Name = "Home Phone", Prompt = "Enter Home Phone Number")]
        //[Required(ErrorMessage = "Home Phone Number is required")]
        public string HomePhoneNumber { get; set; }


        [Display(Name = "Business Phone", Prompt = "Enter Business Phone Number")]
        //[Required(ErrorMessage = "Business Phone Number is required")]
        public string BusinessPhoneNumber { get; set; }


        [Display(Name = "Fax Number", Prompt = "Enter Fax Number")]
        //[Required(ErrorMessage = "Fax Number is required")]
        public string FAXNumber { get; set; }


        [Display(Name = "Fax To Email", Prompt = "Enter Fax To Email")]
        //[Required(ErrorMessage = "Fax To Email is required")]
        public string FaxToEmail { get; set; }


        [Display(Name = "Mobile Phone", Prompt = "Enter Mobile Phone")]
        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }


        [Display(Name = "Email ID", Prompt = "Enter Email ID")]
        [Required(ErrorMessage = "Email ID is required")]
        public string Email { get; set; }


        [Display(Name = "Alternate Email ID", Prompt = "Enter Alternate Email ID")]
        //[Required(ErrorMessage = "Secondary Email ID is required")]
        public string SecondaryEmail { get; set; }



        //***Address***//


        public bool? CanWeSendCommunication { get; set; }



        [Display(Name = "Country", Prompt = "Select Country")]
        //[Required(ErrorMessage = "Country is required")]
        public int? CountryId { get; set; }


        [Display(Name = "Interested In Volunteer Work")]
        //[Required(ErrorMessage = "Interested In Volunteer Work is required")]
        public bool? InterestedInVolunteerWork { get; set; }

        [Display(Name = "Employment History")]
        //[Required(ErrorMessage = "Employment History is required")]
        public bool? HaveEmploymentHistory { get; set; }


        [Display(Name = "Volunteer Work Hours", Prompt = "Enter Work Hours")]
        //[Required(ErrorMessage = "Volunteer Work Hours is required")]
        public int? VolunteerWorkHoursId { get; set; }
        public virtual VolunteerWorkHours VolunteerWorkHours { get; set; }



        [Display(Name = "Referral Type", Prompt = "Select Referral Type")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public int? ReferralTypeId { get; set; }
        public string ReferralTypeName { get; set; }


        [Display(Name = "Referral Other", Prompt = "Enter Referral Other")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public string ReferralOther { get; set; }

        //***END::Referral***//

        [Display(Name = "Is Active")]
        [Required(ErrorMessage = "Active status is required")]
        public bool IsActive { get; set; }


       

        [Display(Name = "Member Level")]
        //[Required(ErrorMessage = "Member Level is required")]
        public int MemberLevelId { get; set; }
        public string MemberLevelName { get; set; }


        [Display(Name = "Member Team")]
        //[Required(ErrorMessage = "Member Team is required")]
        public int MemberTeamId { get; set; }
        public string MemberTeamName { get; set; }


        [Display(Name = "Terms Accepted")]
        [Required(ErrorMessage = "You need to accept terms before submitting")]
        public bool TermAccepted { get; set; }


        //***Notificaations*Verify variables from here*//

        [Display(Name = "Do not SMS")]
        //[Required(ErrorMessage = "Do not SMS is required")]
        public bool? DoNotSMS { get; set; }


        [Display(Name = "Do not Email")]
        //[Required(ErrorMessage = "Do not Email is required")]
        public bool? DoNotEmail { get; set; }


        [Display(Name = "Do not Fax")]
        //[Required(ErrorMessage = "Do not Fax is required")]
        public bool? DonotFax { get; set; }



        [Display(Name = "Do not Bulk Postal Mail")]
        //[Required(ErrorMessage = "Do not Bulk Postal Mail is required")]
        public bool? DonotBulkPostalMail { get; set; }


        [Display(Name = "Do not Send Postal Mail")]
        //[Required(ErrorMessage = "Do not Bulk Postal Mail is required")]
        public bool? DonotpostalMail { get; set; }


        [Display(Name = "Do not Bulk Email")]
        //[Required(ErrorMessage = "Do not Bulk Email is required")]
        public bool? DonotBulkEmail { get; set; }


        [Display(Name = "Do not Send Mass Marketing")]
        //[Required(ErrorMessage = "Do not Send Mass Marketing is required")]
        public bool? DonotSendMassMarketing { get; set; }


        [Display(Name = "Do not Phone")]
        //[Required(ErrorMessage = "Do not Phone is required")]
        public bool? DonotPhone { get; set; }

        //**************Upto Here***********************//

        [Display(Name = "Member Code", Prompt = "Enter Member Code")]
        [Required(ErrorMessage = "Member Code is required")]
        public string MemberCode { get; set; }


        //*****EXTRA FIELDS******//
        
        public string MembershipTypeName { get; set; }

        [Display(Name = "Member Branch")]
        [Required(ErrorMessage = "Member Branch is required")]
        public int MemberBranchId { get; set; }
        public string MemberBranchName { get; set; }

        

        [Display(Name = "Organization")]
        [Required(ErrorMessage = "Organization is required")]
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }

        [Display(Name = "Organization Structure")]
        [Required(ErrorMessage = "Organization Structure is required")]
        public int OrganizationStructureId { get; set; }
        public string OrganizationStructureName { get; set; }

        [Display(Name = "Join Date",
                 Prompt = "Enter Join Date")]
        //[Required(ErrorMessage = "Join Date is required")]
        public DateTime JoinDate { get; set; }

        [Display(Name = "Renewal Date",
                 Prompt = "Enter Next Renewal Date")]
        //[Required(ErrorMessage = "Renewal Date is required")]
        public DateTime NextRenewalDate { get; set; }

        [Display(Name = "Membership Confirmation")]
        public bool MembershipConfirmed { get; set; }

        [Display(Name = "Membership Confirm Date",
                 Prompt = "Enter Membership Confirmed Date")]
        //[Required(ErrorMessage = "Confirm Date is required")]
        public DateTime ConfirmedDate { get; set; }

        [Display(Name = "Is Billing Contact")]
        [Required(ErrorMessage = "Billing Contact status is required")]
        public bool IsBillingContact { get; set; }


        [Display(Name = "Branch Contact")]
        [Required(ErrorMessage = "Branch Contact status is required")]
        public bool IsBranchContact { get; set; }


        [Display(Name = "Member Photo")]
        //[Required(ErrorMessage = "Member Photo is required")]
        public byte[] Photo { get; set; }





    }


}
