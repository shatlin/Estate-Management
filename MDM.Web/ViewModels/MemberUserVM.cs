using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace MM.ClientModels
{

    public class qualifications
    {
        public int id { get; set; }
        public int categoryid { get; set; }
        public int enrolmentcategoryid { get; set; }

        [Display(Name = "Institute Name", Prompt = "Enter Institute Name")]
        // [Required(ErrorMessage = "Institute Name is required")]
        public string institute { get; set; }

        [Display(Name = "Qualification Name", Prompt = "Enter Qualification Name")]
        //[Required(ErrorMessage = "Qualification Name is required")]
        public string qualificationname { get; set; }
        public string studentnumber { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public int qualificationtype { get; set; }
    }

    public class employments
    {
        public int id { get; set; }

        [Display(Name = "Employment Category", Prompt = "Select Employment Category")]
        // [Required(ErrorMessage = "Employment Category is required")]
        public int empcategoryid { get; set; }

        [Display(Name = "Employer Name", Prompt = "Enter Employer Name")]
        //[Required(ErrorMessage = "Employer Name is required")]
        public string employer { get; set; }

        [Display(Name = "Designation", Prompt = "Enter Designation")]
        //[Required(ErrorMessage = "Designation is required")]
        public string empdesignation { get; set; }
        public DateTime empstartdate { get; set; }
        public DateTime empenddate { get; set; }
        public string emptelnumber { get; set; }
        public string empcompanyemail { get; set; }
        public string empduties { get; set; }
    }

    public class addresses
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }

    }
    public partial class MemberUserVM
    {
        
        //*****Required Fields****//
        public int Id { get; set; }
        
        public string ApplicaitonUserId { get; internal set; }
        public string OwnerClientUserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter Password (Min. 6 char)")]
        public string Pwd { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Retype same Password")]
        [Compare("Pwd", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPwd { get; set; }

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


       
       
       

        [Display(Name = "Home Language", Prompt = "Select Home Language")]
        [Required(ErrorMessage = "Home Language is required")]
        public int? HomeLanguageId { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int GenderId { get; set; }


        [Display(Name = "Ethnicity", Prompt = "Select Ethnicity")]
        [Required(ErrorMessage = "Ethnicity is required")]
        public int? EthnicityId { get; set; }
      


        [Display(Name = "Occupation", Prompt = "Enter Occupation")]
        [Required(ErrorMessage = "Occupation is required")]
        public int? OccupationId { get; set; }


        [Display(Name = "Qualification", Prompt = "Select Qualification")]
        //[Required(ErrorMessage = "Highest Qualification is required")]
        public int? HighestQualificationId { get; set; }
    

        [Display(Name = "Highest Qualification")]
        public int HighestQualitificationId { get; set; }
     

        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        //[Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }


        [Display(Name = "Job Title", Prompt = "Enter Job Title")]
        //[Required(ErrorMessage = "Job Title is required")]
        public string JobTitle { get; set; }

        //***Contact***//

        [Display(Name = "Contact Number", Prompt = "Enter Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

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



        [Display(Name = "Nationality", Prompt = "Select Nationality")]
        //[Required(ErrorMessage = "Country is required")]
        public int? CountryId { get; set; }


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

        [Display(Name = "Postal Code")]
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

        [Display(Name = "Town/City")]
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

        [Display(Name = "Publish in Member Directory")]
        //[Required(ErrorMessage = "Publish in Member Directory is required")]
        public bool? PublishCompanyInAnnualMemberDirectory { get; set; }

        [Display(Name = "Interested In Volunteer Work")]
        //[Required(ErrorMessage = "Interested In Volunteer Work is required")]
        public bool? InterestedInVolunteerWork { get; set; }

        [Display(Name = "Employment History")]
        //[Required(ErrorMessage = "Employment History is required")]
        public bool? HaveEmploymentHistory { get; set; }


        [Display(Name = "Volunteer Work Hours", Prompt = "Enter Work Hours")]
        //[Required(ErrorMessage = "Volunteer Work Hours is required")]
        public int? VolunteerWorkHoursId { get; set; }



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


        [Display(Name = "Member Status")]
        //[Required(ErrorMessage = "Member Status is required")]
        public int MemberStatusId { get; set; }
        public string MemberStatusName { get; set; }

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

        [Display(Name = "Last Campaign Date")]
        public DateTime? LastUsedInCampaignDate { get; set; }

        [Display(Name = "Do not Phone")]
        //[Required(ErrorMessage = "Do not Phone is required")]
        public bool? DonotPhone { get; set; }

        //**************Upto Here***********************//

        [Display(Name = "Member Code", Prompt = "Enter Member Code")]
        [Required(ErrorMessage = "Member Code is required")]
        public string MemberCode { get; set; }


        //*****EXTRA FIELDS******//
        [Display(Name = "Membership Grade")]
        //[Required(ErrorMessage = "Membership Grade is required")]
        public int MembershipGradeId { get; set; }
        public string MembershipGradeName { get; set; }

        [Display(Name = "Member Branch")]
        [Required(ErrorMessage = "Member Branch is required")]
        public int MemberBranchId { get; set; }
        public string MemberBranchName { get; set; }

        [Display(Name = "Branch", Prompt = "Select Branch")]
        // [Required(ErrorMessage = "Branch is required")]
        public int? ClientBranchId { get; set; }

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



        [Display(Name = "Notes", Prompt = "Enter Notes about Member")]
        //[Required(ErrorMessage = "Note is required")]
        public string Notes { get; set; }


        [Display(Name = "Member Photo")]
        //[Required(ErrorMessage = "Member Photo is required")]
        public byte[] Photo { get; set; }
        
    }


}
