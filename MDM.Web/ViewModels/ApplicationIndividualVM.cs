using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;
using  MM.Web.Validation;
namespace MM.ClientModels
{
    public class qualificationvm
    {
        public int? id { get; set; }
        public int? categoryid { get; set; }
        public int? enrolmentcategoryid { get; set; }
        public string isdeleted { get; set; }

        [Display(Name = "Institute Name", Prompt = "Enter Institute Name")]
        public string institute { get; set; }

        [Display(Name = "Qualification Name", Prompt = "Enter Qualification Name")]
        public string qualificationname { get; set; }
        public string studentnumber { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }
        public int? qualificationtype { get; set; }
        public string qualificationtypename { get; set; }
    }

    public class refereevm
    {
        public int? id { get; set; }
        public string title { get; set; }
        public string initial { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string membername { get; set; }
        public string email { get; set; }
        public string mobilenumber { get; set; }
        public string phonenumber { get; set; }
        public string employername { get; set; }
        public string positionofreferee { get; set; }
        public string professionalregnoofreferee { get; set; }
        public string isdeleted { get; set; }
    }

    public class dwsclassvm
    {
        public int? id { get; set; }

        [Display(Name = "Class", Prompt = "Select Class")]
        [Required(ErrorMessage = "Class is required")]
        public int waterclass { get; set; }
        public string isdeleted { get; set; }
        public DateTime waterdate { get; set; }
    }

    public class employmentvm
    {
        public int? id { get; set; }

        [Display(Name = "Employment Category", Prompt = "Select Employment Category")]
      
        public int? empcategoryid { get; set; }
        public string empcategoryname { get; set; }
        public string isdeleted { get; set; }
        [Display(Name = "Employer Name", Prompt = "Enter Employer Name")]
      
        public string employer { get; set; }
        [Display(Name = "Designation", Prompt = "Enter Designation")]
    
        public string empdesignation { get; set; }
        public DateTime? empstartdate { get; set; }
        public DateTime? empenddate { get; set; }
        public string emptelnumber { get; set; }
        public string empcompanyemail { get; set; }
        public string empduties { get; set; }
    }

    public class addressvm
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }

    }



    public partial class ApplicationIndividualVM
    {

        public ApplicationIndividualVM()
        {

        }


        //*****Required Fields****//
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string OwnerClientUserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        //***Profile Info***//
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public int? TitleId { get; set; }

         public string TitleName { get; set; }
        [Display(Name = "Initials", Prompt = "Enter Initials")]
        //[Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }


        [Display(Name = "First Name", Prompt = "Enter First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

       // [Display(Name = "Full Name")]
        //[Required(ErrorMessage = "Last Name is required")]
        public string FullName { get; set; }


        [Display(Name = "Date of Birth", Prompt = "Enter your Birthday")]
        // [Required(ErrorMessage = "Birthday is required")]
        public DateTime? BirthDay { get; set; }


        [Display(Name = "ID/Passport Number", Prompt = "Enter ID Number")]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }


        [Display(Name = "Nationality", Prompt = "Select Nationality")]
        [Required(ErrorMessage = "Nationality is required")]
        public int? CountryId { get; set; }
        //public virtual Country Nationality { get; set; }


        [Display(Name = "Home Language", Prompt = "Select Home Language")]
        //[Required(ErrorMessage = "Home Language is required")]
        public int? HomeLanguageId { get; set; }
        //public virtual Language HomeLanguageName { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int? GenderId { get; set; }
        public string GenderName { get; set; }


        [Display(Name = "Ethnicity", Prompt = "Select Ethnicity")]
        [Required(ErrorMessage = "Ethnicity is required")]
        public int? EthnicityId { get; set; }
        public string EthnicityName { get; set; }
        //public virtual Ethnicity Ethnicity { get; set; }


        [Display(Name = "Occupation", Prompt = "Enter Occupation")]
        [Required(ErrorMessage = "Occupation is required")]
        public int? OccupationId { get; set; }
        public string OccupationName { get; set; }
        //public virtual Occupation Occupation { get; set; }


        [Display(Name = "Qualification", Prompt = "Select Qualification")]
        [Required(ErrorMessage = "Highest Qualification is required")]
        public int? HighestQualificationId { get; set; }
        //public virtual Qualification QualificationName { get; set; }

        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Account Balance")]
        //[Required(ErrorMessage = "Account Balance is required")]
        public decimal? AccountBalance { get; set; }


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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email ID", Prompt = "Enter Email ID")]
        [Required(ErrorMessage = "Confirm Email ID is required")]
        public string ConfirmEmail { get; set; }


        [Display(Name = "Alternate Email ID", Prompt = "Enter Alternate Email ID")]
        //[Required(ErrorMessage = "Secondary Email ID is required")]
        public string SecondaryEmail { get; set; }



        //***Address***//

        [Display(Name = "Send Communication")]
        public bool? CanWeSendCommunication { get; set; }



        //[Display(Name = "Country", Prompt = "Select Country")]
        ////[Required(ErrorMessage = "Country is required")]
        //public int? CountryId { get; set; }


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

        [Display(Name = "Province")]
        public int? PhysicalStateId { get; set; }

        [Display(Name = "Country")]
        public int? PhysicalCountryId { get; set; }

        [Display(Name = "Postal Code")]
        public string PhysicalPostalCode { get; set; }

        
        public string PhysicalCountryName { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string PostalAddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Required(ErrorMessage = "Address Line 2 is required")]
        public string PostalAddressLine2 { get; set; }
        
        [Display(Name = "Address Line 3")]
        public string PostalAddressLine3 { get; set; }

        [Display(Name = "Suburb")]
        [Required(ErrorMessage = "Suburb is required")]
        public string PostalSuburb { get; set; }

        [Display(Name = "Town/City")]
        [Required(ErrorMessage = "City is required")]
        public string PostalCity { get; set; }

        [Display(Name = "Province")]
        public string PostalProvince { get; set; }

        [Display(Name = "Province")]
        public int? PostalStateId { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public int? PostalCountryId { get; set; }

        public string PostalCountryName { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal Code is required")]
        public string PostalPostalCode { get; set; }

        [Display(Name = "Publish in Member Directory")]
        //[Required(ErrorMessage = "Publish in Member Directory is required")]
        public bool? PublishCompanyInAnnualMemberDirectory { get; set; }
        public string PublishCompanyInAnnualMemberDirectoryName { get; set; }

        [Display(Name = "Interested In Volunteer Work")]
        //[Required(ErrorMessage = "Interested In Volunteer Work is required")]
        public bool? InterestedInVolunteerWork { get; set; }
        public string InterestedInVolunteerWorkName { get; set; }

        [Display(Name = "Employment History")]
       [Required(ErrorMessage = "Please select")]
        public bool? HaveEmploymentHistory { get; set; }


        [Display(Name = "Volunteer Work Hours", Prompt = "Enter Work Hours")]
        //[Required(ErrorMessage = "Volunteer Work Hours is required")]
        public int? VolunteerWorkHoursId { get; set; }
        //public virtual VolunteerWorkHours VolunteerWorkHours { get; set; }



        [Display(Name = "Referral Type", Prompt = "Select Referral Type")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public int? ReferralTypeId { get; set; }


        [Display(Name = "Referral Other", Prompt = "Enter Referral Other")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public string ReferralOther { get; set; }

        //***END::Referral***//



        [Display(Name = "Terms Accepted")]
        [EnforceTrue(ErrorMessage = "You need to accept terms before submitting")]
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
        //[Required(ErrorMessage = "Member Code is required")]
        public string MemberCode { get; set; }


        //*****EXTRA FIELDS******//
        [Display(Name = "Membership Type", Prompt = "Select Membership Grade")]
        //[Required(ErrorMessage = "Membership Grade is required")]
        public int? MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }

        //*****EXTRA FIELDS******//
        [Display(Name = "Membership Grade", Prompt = "Select Membership Grade")]
        //[Required(ErrorMessage = "Membership Grade is required")]
        public int? MembershipGradeId { get; set; }
        public string MembershipGradeName { get; set; }

        [Display(Name = "Membership Grade", Prompt = "Select Membership Grade")]
        //[Required(ErrorMessage = "Membership Grade is required")]
        public int? MemberStatusId { get; set; }
        public string MemberStatusName { get; set; }


      

        [Display(Name = "Start Date", Prompt = "Enter Start date")]
        //[Required(ErrorMessage = "Start Date is required")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date", Prompt = "Enter End date")]
        //[Required(ErrorMessage = "End Date is required")]
        public DateTime? EndDate { get; set; }


        [Display(Name = "Branch", Prompt = "Select Branch")]
        [Required(ErrorMessage = "Branch is required")]
        public int? ClientBranchId { get; set; }
        public string ClientBranchName { get; set; }



        [Display(Name = "Notes", Prompt = "Enter Notes")]
        //[Required(ErrorMessage = "Note is required")]
        public string Notes { get; set; }


        [Display(Name = "Member Photo")]
        //[Required(ErrorMessage = "Member Photo is required")]
        public byte[] Photo { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Last Updated via Portal")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Application Cancelled Date")]
        public DateTime? ApplicationCancelledMemberfeeNotpaidDate { get; set; }


    }


}
