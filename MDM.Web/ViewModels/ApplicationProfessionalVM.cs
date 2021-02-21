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

    public partial class PostalAddress
    {

    }

    public partial class HomeLanguageVM
    {

    }

    public partial class Disability
    {

    }

    public partial class Division
    {

    }
    public partial class VolunteerWorkHours
    {

    }

    public partial class ApplicationProfessionalVM
    {

        //*****Required Fields****//
        public int Id { get; set; }
        public string ApplicaitonUserId { get; set; }
        public string OwnerClientUserId { get; set; }
        //public AddressVM PhysicalAddress { get; set; }
        //public AddressVM PostalAddress { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual PhysicalAddress PhysicalAddress { get; set; }
        public virtual PostalAddress PostalAddress { get; set; }
        public virtual Disability Disability { get; set; }

        //***Profile***//
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public int TitleId { get; set; }


        [Display(Name = "Initials", Prompt = "Enter Initials")]
        //[Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }


        [Display(Name = "First Name", Prompt = "Enter First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name", Prompt = "Enter Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int GenderId { get; set; }


        [Display(Name = "Date of Birth", Prompt = "Enter your Birthday")]
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime? BirthDay { get; set; }


        [Display(Name = "Highest Qualification", Prompt = "Select Qualification")]
        //[Required(ErrorMessage = "Highest Qualification is required")]
        public int HighestQualitificationId { get; set; }
        public virtual Qualification QualificationName { get; set; }


        [Display(Name = "Occupation", Prompt = "Enter Occupation")]
        //[Required(ErrorMessage = "Occupation is required")]
        public int OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }

        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        //[Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }


        [Display(Name = "Job Title", Prompt = "Enter Job Title")]
        //[Required(ErrorMessage = "Job Title is required")]
        public string JobTitle { get; set; }


        [Display(Name = "Home Language", Prompt = "Select Home Language")]
        //[Required(ErrorMessage = "Home Language is required")]
        public int HomeLanguageId { get; set; }
        public virtual HomeLanguageVM HomeLanguageName { get; set; }


        [Display(Name = "Ethnicity", Prompt = "Select Ethnicity")]
        //[Required(ErrorMessage = "Ethnicity is required")]
        public int EthnicityId { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }


        [Display(Name = "ID Number", Prompt = "Enter ID Number")]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }


        [Display(Name = "Nationality", Prompt = "Select Nationality")]
        [Required(ErrorMessage = "Nationality is required")]
        public int NationalityId { get; set; }

        //***Contact***//

        [Display(Name = "Home Phone Number", Prompt = "Enter Home Phone Number")]
        [Required(ErrorMessage = "Home Phone Number is required")]
        public string HomePhoneNumber { get; set; }


        [Display(Name = "Business Phone Number", Prompt = "Enter Business Phone Number")]
        [Required(ErrorMessage = "Business Phone Number is required")]
        public string BusinessPhoneNumber { get; set; }


        [Display(Name = "Mobile Phone", Prompt = "Enter Mobile Phone")]
        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }


        [Display(Name = "Email ID", Prompt = "Enter Email ID")]
        [Required(ErrorMessage = "Email ID is required")]
        public string Email { get; set; }


        [Display(Name = "Alternate Email ID", Prompt = "Enter Alternate Email ID")]
        //[Required(ErrorMessage = "Secondary Email ID is required")]
        public string SecondaryEmail { get; set; }


        [Display(Name = "Fax Number", Prompt = "Enter Fax Number")]
        //[Required(ErrorMessage = "Fax Number is required")]
        public string FAXNumber { get; set; }


        [Display(Name = "Fax To Email", Prompt = "Enter Fax To Email")]
        //[Required(ErrorMessage = "Fax To Email is required")]
        public string FaxToEmail { get; set; }

        //***Address***//

        [Display(Name = "Address Line 1", Prompt = "Enter Address Line 1")]
        //[Required(ErrorMessage = "Ethnicity is required")]
        public string AddressLine1 { get; set; }


        [Display(Name = "Address Line 2", Prompt = "Enter Address Line 2")]
        //[Required(ErrorMessage = "AddressLine2 is required")]
        public string AddressLine2 { get; set; }


        [Display(Name = "Suburb", Prompt = "Enter Suburb")]
        //[Required(ErrorMessage = "Subrub is required")]
        public string Suburb { get; set; }


        [Display(Name = "Town/City", Prompt = "Enter Town/City")]
        //[Required(ErrorMessage = "Subrub is required")]
        public string TownCity { get; set; }


        [Display(Name = "Province", Prompt = "Select Province")]
        //[Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }


        [Display(Name = "Country", Prompt = "Select Country")]
        //[Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }


        [Display(Name = "Postal Code", Prompt = "Enter Postal Code")]
        //[Required(ErrorMessage = "Postal Code is required")]
        public string PostalCode { get; set; }


        //***Qualification&Employment***//
        [Display(Name = "Qualification Attached")]
        //[Required(ErrorMessage = "Qualification Attached is required")]
        public bool QualificationAttached { get; set; }


        [Display(Name = "Employment History")]
        //[Required(ErrorMessage = "Employment Attached is required")]
        public bool EmploymentAttached { get; set; }

        //Additional Info***//

        [Display(Name = "Disability")]
        //[Required(ErrorMessage = "Disability is required")]
        public bool IsDisabled { get; set; }

        [Display(Name = "Hearing")]
        //[Required(ErrorMessage = "Hearing Disability Rate is required")]
        public string Hearing { get; set; }


        [Display(Name = "Communication")]
        //[Required(ErrorMessage = "Communication Disability Rate is required")]
        public string Communication { get; set; }


        [Display(Name = "Seeing")]
        //[Required(ErrorMessage = "Seeing Disability Rate is required")]
        public string Seeing { get; set; }


        [Display(Name = "Walking")]
        //[Required(ErrorMessage = "Walking Disability Rate is required")]
        public string Walking { get; set; }


        [Display(Name = "Self-Care")]
        //[Required(ErrorMessage = "Self Care Disability Rate is required")]
        public string SelfCare { get; set; }


        [Display(Name = "Remembering")]
        //[Required(ErrorMessage = "Remembering Disability Rate is required")]
        public string Remembering { get; set; }


        [Display(Name = "Member Branch", Prompt = "Select Member Branch")]
        //[Required(ErrorMessage = "Member Branch is required")]
        public int? MemberBranchId { get; set; }
        public string MemberBranchName { get; set; }

        //***Division***//
        [Display(Name = "Anaerobic Sludge Processes")]
        public bool AnaerobicSludgeProcesses { get; set; }


        [Display(Name = "Community Water Supply and Sanitation")]
        public bool CommunityWaterSupplyAndSanitation { get; set; }


        [Display(Name = "Industrial Water")]
        public bool IndustrialWater { get; set; }


        [Display(Name = "Innovations in Water & Sanitation")]
        public bool InnovationsInWaterAndSanitation { get; set; }


        [Display(Name = "IWA-SA")]
        public bool IWASA { get; set; }


        [Display(Name = "Management & Institutional Affairs")]
        public bool ManagementAndInstitutionalAffairs { get; set; }


        [Display(Name = "Membrane Technology")]
        public bool MembraneTechnology { get; set; }


        [Display(Name = "Mine Water")]
        public bool MineWater { get; set; }


        [Display(Name = "Process Controllers")]
        public bool ProcessControllers { get; set; }


        [Display(Name = "Small Wastewater Treatment Works")]
        public bool SmallWastewaterTreatmentWorks { get; set; }


        [Display(Name = "Water Distribution")]
        public bool WaterDistribution { get; set; }


        [Display(Name = "Water Reuse")]
        public bool WaterReuse { get; set; }


        [Display(Name = "Water Sciencce")]
        public bool WaterScience { get; set; }


        [Display(Name = "Young Water Professionals")]
        public bool YoungWaterProfessionals { get; set; }


        [Display(Name = "Affilication")]
        //[Required(ErrorMessage = "Affilication is required")]
        public int? AffilicationId { get; set; }
        public string AffiliationName { get; set; }
        public string AffiliationMemberNumber { get; set; }


        [Display(Name = "Publish in Member Directory")]
        //[Required(ErrorMessage = "Publish in Member Directory is required")]
        public int PublishCompanyInAnnualMemberDirectory { get; set; }


        [Display(Name = "Interested In Volunteer Work")]
        //[Required(ErrorMessage = "Interested In Volunteer Work is required")]
        public int InterestedInVolunteerWork { get; set; }


        [Display(Name = "Volunteer Work Hours", Prompt = "Enter Work Hours")]
        //[Required(ErrorMessage = "Volunteer Work Hours is required")]
        public int VolunteerWorkHoursId { get; set; }
        public virtual VolunteerWorkHours VolunteerWorkHours { get; set; }

        //*********In which of the following ways do you want to be involved?*************//

        [Display(Name = "Branch/Division Committee member")]
        public bool CommitteeMember { get; set; }


        [Display(Name = "Logistics")]
        public bool Logistics { get; set; }


        [Display(Name = "Promotions and Marketing")]
        public bool PromotionsMarketing { get; set; }


        [Display(Name = "Assist in obtaining sponsorship")]
        public bool AssistSponsorship { get; set; }


        [Display(Name = "Writing articles for publication in WISA and main stream media")]
        public bool Articles { get; set; }


        [Display(Name = "Being a mentor and/or specialist advisor")]
        public bool SpecialistAdvisor { get; set; }


        [Display(Name = "Visit schools and universities to promote WISA")]
        public bool VisitSchool { get; set; }


        [Display(Name = "Visit businesses and government departments to promote WISA")]
        public bool VisitBusiness { get; set; }


        [Display(Name = "Membership Desk or Exhibition Stand")]
        public bool MembershipDesk { get; set; }


        [Display(Name = "Community outreach projects")]
        public bool CommunityOutreach { get; set; }


        [Display(Name = "Media mentor - reporting to WISA HQ")]
        public bool MediaMentor { get; set; }

        //******END::In which of the following ways do you want to be involved?*****//


        //***Referral***//

        [Display(Name = "Referral Type", Prompt = "Select Referral Type")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public int? ReferralTypeId { get; set; }
        public string ReferralTypeName { get; set; }

        [Display(Name = "Referral Other", Prompt = "Enter Referral Other")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public string ReferralOther { get; set; }

        //***END::Referral***//

        [Display(Name = "ID Attached")]
        //[Required(ErrorMessage = "ID Attached is required")]
        public int IDAttached { get; set; }


        [Display(Name = "Certificate Uploaded")]
        //[Required(ErrorMessage = "CertificateUploaded is required")]
        public int CertificateUploaded { get; set; }


        [Display(Name = "Proof Of Registration Attached")]
        //[Required(ErrorMessage = "Proof Of Registration Attached is required")]
        public int ProofOfRegistrationAttached { get; set; }


        [Display(Name = "Dws certificate Attached")]
        //[Required(ErrorMessage = "Dws certificate Attached is required")]
        public int DwsCertificateAttached { get; set; }





        [Display(Name = "Admin Fee")]
        //[Required(ErrorMessage = "Admin Fee is required")]
        public int AdminFee { get; set; }


        [Display(Name = "Admin Fee Proof of Payment Sent")]
        //[Required(ErrorMessage = "Proof of Payment Sent is required")]
        public int AdminfeeProofofpaymentSent { get; set; }


        [Display(Name = "Proof Of Payment Applicable")]
        //[Required(ErrorMessage = "Proof of Payment Applicable is required")]
        public int ProofOfpaymentApplicable { get; set; }


        [Display(Name = "Proof of Payment Received")]
        //[Required(ErrorMessage = "Proof of Payment Received is required")]
        public int ProofofPaymentReceived { get; set; }


        [Display(Name = "Application Form Complete")]
        //[Required(ErrorMessage = "Application Form Complete is required")]
        public int ApplicationFormComplete { get; set; }


        [Display(Name = "Terms Accepted")]
        //[Required(ErrorMessage = "Terms Accepted is required")]
        public bool TermAccepted { get; set; }


        //***Notificaations*Verify variables from here*//

        [Display(Name = "Do not SMS")]
        //[Required(ErrorMessage = "Do not SMS is required")]
        public bool DoNotSMS { get; set; }


        [Display(Name = "Do not Email")]
        //[Required(ErrorMessage = "Do not Email is required")]
        public bool DoNotEmail { get; set; }


        [Display(Name = "Do not Fax")]
        //[Required(ErrorMessage = "Do not Fax is required")]
        public bool DonotFax { get; set; }



        [Display(Name = "Do not Bulk Postal Mail")]
        //[Required(ErrorMessage = "Do not Bulk Postal Mail is required")]
        public int DonotBulkPostalMail { get; set; }


        [Display(Name = "Do not Send Postal Mail")]
        //[Required(ErrorMessage = "Do not Bulk Postal Mail is required")]
        public int DonotpostalMail { get; set; }


        [Display(Name = "Do not Bulk Email")]
        //[Required(ErrorMessage = "Do not Bulk Email is required")]
        public int DonotBulkEmail { get; set; }


        [Display(Name = "Do not Send Mass Marketing")]
        //[Required(ErrorMessage = "Do not Send Mass Marketing is required")]
        public int DonotSendMassMarketing { get; set; }


        [Display(Name = "Do not Phone")]
        //[Required(ErrorMessage = "Do not Phone is required")]
        public int DonotPhone { get; set; }

        //**************Upto Here***********************//

        [Display(Name = "Member Code", Prompt = "Enter Member Code")]
        [Required(ErrorMessage = "Member Code is required")]
        public string MemberCode { get; set; }



        [Display(Name = "Post Certificate Tracking", Prompt = "Select Post Certificate Tracking")]
        //[Required(ErrorMessage = "Post Certificate Tracking is required")]
        public string PostCertificateTracking { get; set; }


        [Display(Name = "Admin Fee Proof of Payment Received Date")]
        //[Required(ErrorMessage = "Admin Fee Payment Date is required")]
        public DateTime AdminFeeProofofpaymentReceivedDate { get; set; }

        [Display(Name = "Proof of Payment Received Date")]
        //[Required(ErrorMessage = "Proof of Payment Received Date is required")]
        public DateTime ProofofPaymentReceivedDate { get; set; }


        [Display(Name = "Admin fee Payment Received Date", Prompt = "Select Admin fee Payment Received Date")]
        //[Required(ErrorMessage = "Member Fee Request 3 Date is required")]
        public DateTime AdminfeePaymentReceivedDate { get; set; }


        [Display(Name = "Application Cancel Date (Member Fee Not Paid)", Prompt = "Select Application Cancel Date")]
        //[Required(ErrorMessage = "Application Cancel Date - Member Fee is required")]
        public DateTime ApplicationCancelledMemberfeeNotpaidDate { get; set; }


        [Display(Name = "Application Cancel Date (No Payment)", Prompt = "Select Application Cancel Date")]
        //[Required(ErrorMessage = "Application Cancel Date - No Payment is required")]
        public DateTime CancelapplicationNopayDate { get; set; }


        [Display(Name = "Application Received Date", Prompt = "Select Application Received Date")]
        //[Required(ErrorMessage = "Application Received Date is required")]
        public DateTime ApplicationreceivedDate { get; set; }









        //*****EXTRA FIELDS******//
        [Display(Name = "Membership Grade", Prompt = "Select Membership Grade")]
        [Required(ErrorMessage = "Membership Grade is required")]
        public int MembershipGradeId { get; set; }
        public string MembershipGradeName { get; set; }



        [Display(Name = "Transaction Currency", Prompt = "Select Transaction Currency")]
        //[Required(ErrorMessage = "Nationality is required")]
        public int TransactionCurrencyId { get; set; }

        [Display(Name = "Member Status")]
        //[Required(ErrorMessage = "Member Status is required")]
        public int? MemberStatusId { get; set; }
        public string MemberStatusName { get; set; }

        [Display(Name = "Membership Type", Prompt = "Select Membership Type")]
        //[Required(ErrorMessage = "Membership Type is required")]
        public int? MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }



        [Display(Name = "Member Level", Prompt = "Select Member Level")]
        //[Required(ErrorMessage = "Member Level is required")]
        public int? MemberLevelId { get; set; }
        public string MemberLevelName { get; set; }




        [Display(Name = "Member Team", Prompt = "Select Member Team")]
        //[Required(ErrorMessage = "Member Team is required")]
        public int? MemberTeamId { get; set; }
        public string MemberTeamName { get; set; }

        [Display(Name = "Organization", Prompt = "Select Member Team")]
        [Required(ErrorMessage = "Organization is required")]
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }

        [Display(Name = "Organization Structure", Prompt = "Select Org. Structure")]
        [Required(ErrorMessage = "Organization Structure is required")]
        public int? OrganizationStructureId { get; set; }
        public string OrganizationStructureName { get; set; }

        [Display(Name = "Client Branch", Prompt = "Select Client Branch")]
        //[Required(ErrorMessage = "Client Branch is required")]
        public int? ClientBranchId { get; set; }

        [Display(Name = "Preferred Appointment Time", Prompt = "Select preferred time")]
        //[Required(ErrorMessage = "Preferred Appointment is required")]
        public int? PreferredAppointmentTimeId { get; set; }


        [Display(Name = "Parent Member", Prompt = "Select Parent Member")]
        //[Required(ErrorMessage = "Parent Member is required")]
        public int ParentMemberid { get; set; }


        [Display(Name = "Parent Member Name", Prompt = "Enter Parent Member Name")]
        //[Required(ErrorMessage = "Parent Member Name is required")]
        public int ParentMemberName { get; set; }

        [Display(Name = "Special Member Name", Prompt = "Select Special Member")]
        //[Required(ErrorMessage = "Special Member is required")]
        public int SpecialMember { get; set; }


        [Display(Name = "Total CDP Points")]
        //[Required(ErrorMessage = "Total CDP Points is required")]
        public int TotalCDPPoints { get; set; }

        [Display(Name = "Account Balance Of the Company")]
        public decimal AccountBalanceOftheCompany { get; set; }

        [Display(Name = "Account Balance Of the Company Base")]
        public decimal Accountbalanceofthecompany_base { get; set; }

        [Display(Name = "Exchange Rate")]
        public decimal ExchangeRate { get; set; }





        [Display(Name = "Notes", Prompt = "Enter Notes")]
        //[Required(ErrorMessage = "Note is required")]
        public string Notes { get; set; }












        [Display(Name = "Membership Fee Invoiced To Company")]
        //[Required(ErrorMessage = "MembershipFee Invoiced To Company is required")]
        public int MembershipFeeInvoicedToCompany { get; set; }




        [Display(Name = "Tax Invoice Sent")]
        //[Required(ErrorMessage = "Tax Invoice Sent is required")]
        public int TaxInvoiceSent { get; set; }

        [Display(Name = "Referee Report", Prompt = "Enter Referee Report")]
        //[Required(ErrorMessage = "Referee Report is required")]
        public int RefereeReport { get; set; }




        [Display(Name = "First Reminder Sent")]
        //[Required(ErrorMessage = "First Reminder Sent is required")]
        public int FirstReminderSent { get; set; }

        [Display(Name = "Second Reminder Sent")]
        //[Required(ErrorMessage = "Second Reminder Sent is required")]
        public int SecondReminderSent { get; set; }


        [Display(Name = "Third Reminder Sent")]
        //[Required(ErrorMessage = "Third Reminder Sent is required")]
        public int ThirdReminderSent { get; set; }


        [Display(Name = "Invoice Sent")]
        //[Required(ErrorMessage = "Invoice Sent is required")]
        public int InvoiceSent { get; set; }


        [Display(Name = "Total CDP Points State")]
        //[Required(ErrorMessage = "Total CDP Points State is required")]
        public int TotalCdppoints_State { get; set; }


        [Display(Name = "Total CDP Points Calculated Date")]
        //[Required(ErrorMessage = "CDP calculated date is required")]
        public DateTime TotalCdpPointsCalculatedDate { get; set; }


        [Display(Name = "Is Private")]
        //[Required(ErrorMessage = "Is Private is required")]
        public int IsPrivate { get; set; }



        [Display(Name = "Follow Email")]
        //[Required(ErrorMessage = "Follow Email is required")]
        public int FollowEmail { get; set; }


        [Display(Name = "Is Billing Contact")]
        //[Required(ErrorMessage = "Billing Contact status is required")]
        public bool IsBillingContact { get; set; }


        [Display(Name = "Branch Contact")]
        //[Required(ErrorMessage = "Branch Contact status is required")]
        public bool IsBranchContact { get; set; }


        [Display(Name = "Is Active")]
        //[Required(ErrorMessage = "Active status is required")]
        public bool IsActive { get; set; }





        [Display(Name = "Start Date", Prompt = "Start Date")]
        //[Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }


        [Display(Name = "End Date", Prompt = "End Date")]
        //[Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }


        [Display(Name = "Grading Completed Date", Prompt = "Select Grading Completed Date")]
        //[Required(ErrorMessage = "Grading Completed date is required")]
        public DateTime GradingCompletedDate { get; set; }


        [Display(Name = "Sent for Grading Date", Prompt = "Select Sent for Grading Date")]
        //[Required(ErrorMessage = "Sent for Grading Date is required")]
        public DateTime SentforGradingDate { get; set; }


        [Display(Name = "Posting of Certificate Date", Prompt = "Select Posting of Certificate Date")]
        //[Required(ErrorMessage = "Posting of Certificate Date is required")]
        public DateTime PostingofCertificateDate { get; set; }


        [Display(Name = "Certificate & Welcome Letter Emailed Date", Prompt = "Select Welcome Letter Emailed Date")]
        //[Required(ErrorMessage = "Welcome Letter Emailed Date is required")]
        public DateTime CertificateAndwelcomeLetterEmailedDate { get; set; }


        [Display(Name = "Proforma Invoice Emailed Date", Prompt = "Select Proforma Invoice Emailed Date")]
        //[Required(ErrorMessage = "Proforma Invoice Emailed Date is required")]
        public DateTime ProformaInvoiceEmailedDate { get; set; }


        [Display(Name = "Proforma Invoice Sent Date", Prompt = "Select Proforma Invoice Sent Date")]
        //[Required(ErrorMessage = "Proforma Invoice Sent Date is required")]
        public DateTime ProformaInvoiceSentDate { get; set; }


        [Display(Name = "Tax Invoice Emailed Date", Prompt = "Select Tax Invoice Emailed Date")]
        //[Required(ErrorMessage = "Tax Invoice Emailed Date is required")]
        public DateTime TaxInvoiceEmailedDate { get; set; }


        [Display(Name = "Payment Reminder1 Date", Prompt = "Select Payment Reminder1 Date")]
        //[Required(ErrorMessage = "Payment Reminder1 Date is required")]
        public DateTime PaymentReminder1Date { get; set; }


        [Display(Name = "Payment Reminder2 Date", Prompt = "Select Payment Reminder2 Date")]
        //[Required(ErrorMessage = "Payment Reminder2 Date is required")]
        public DateTime PaymentReminder2Date { get; set; }


        [Display(Name = "Payment Reminder3 Date", Prompt = "Select Payment Reminder3 Date")]
        //[Required(ErrorMessage = "Payment Reminder3 Date is required")]
        public DateTime PaymentReminder3Date { get; set; }


        [Display(Name = "Member Fee Request 2 Date", Prompt = "Select Member Fee Request 2 Date")]
        //[Required(ErrorMessage = "Member Fee Request 2 Date is required")]
        public DateTime Request2MemberFee { get; set; }


        [Display(Name = "Member Fee Request 3 Date", Prompt = "Select Member Fee Request 3 Date")]
        //[Required(ErrorMessage = "Member Fee Request 3 Date is required")]
        public DateTime Request3MemberFee { get; set; }


        [Display(Name = "Join Date",
                 Prompt = "Enter Join Date")]
        //[Required(ErrorMessage = "Join Date is required")]
        public DateTime JoinDate { get; set; }


        [Display(Name = "Renewal Date",
                 Prompt = "Enter Next Renewal Date")]
        //[Required(ErrorMessage = "Renewal Date is required")]
        public DateTime NextRenewalDate { get; set; }


        [Display(Name = "Membership Confirmation")]
        public int MembershipConfirmed { get; set; }


        [Display(Name = "Membership Confirm Date",
                 Prompt = "Enter Membership Confirmed Date")]
        //[Required(ErrorMessage = "Confirm Date is required")]
        public DateTime ConfirmedDate { get; set; }


        [Display(Name = "Member Photo")]
        //[Required(ErrorMessage = "Member Photo is required")]
        public byte[] Photo { get; set; }

        [Display(Name = "Created On Date")]
        //[Required(ErrorMessage = "Created On Date is required")]
        public DateTime CreatedOn { get; set; }


        [Display(Name = "Modified On Date")]
        //[Required(ErrorMessage = "Modified On Date is required")]
        public DateTime ModifiedOn { get; set; }


        [Display(Name = "Created by (Name)")]
        //[Required(ErrorMessage = "Created By Name is required")]
        public string CreatedBy { get; set; }


        [Display(Name = "Modified by (Name)")]
        //[Required(ErrorMessage = "Modified By Name is required")]
        public string ModifiedBy { get; set; }


        [Display(Name = "New Check")]
        //[Required(ErrorMessage = "New_Check is required")]
        public string New_Check { get; set; }




    }


}
