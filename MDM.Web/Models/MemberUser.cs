using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{
    public partial class MemberUser
    {
        public MemberUser()
        {
            Billing = new HashSet<Billing>();
            Cpd = new HashSet<Cpd>();
            Donation = new HashSet<Donation>();
            EventAttendance = new HashSet<EventAttendance>();
            EventRegistration = new HashSet<EventRegistration>();
            Invoice = new HashSet<Invoice>();
            MemberAddress = new HashSet<MemberAddress>();
            MemberBankingDetail = new HashSet<MemberBankingDetail>();
            MemberCommunicationPreference = new HashSet<MemberCommunicationPreference>();
            MemberPlanHistory = new HashSet<MemberPlanHistory>();
            PromotionResponse = new HashSet<PromotionResponse>();
            Refund = new HashSet<Refund>();
            MarketingGroupXref = new HashSet<MarketingGroupXref>();
            MarketingProfileXref = new HashSet<MarketingProfileXref>();
            MemberAffliationXref = new HashSet<MemberAffliationXref>();
            MemberQualificationXref = new HashSet<MemberQualificationXref>();
            InvolvementMemberXref = new HashSet<InvolvementMemberXref>();
            DisabilityMemberXref = new HashSet<DisabilityMemberXref>();
            DWSClassMemberXref = new HashSet<DWSClassMemberXref>();
            DivisionMemberXref = new HashSet<DivisionMemberXref>();
            EmploymentMemberXref = new HashSet<EmploymentMemberXref>();
            MemberFileXref = new HashSet<MemberFileXref>();
            PrimaryContactOrganization = new HashSet<Organization>();
            ContactPersonOrganization = new HashSet<Organization>();
            BillingContactOrganization = new HashSet<Organization>();
            IndividualMemberShipHistory = new HashSet<IndividualMemberShipHistory>();


        }

        //public class address
        //{
        //    public int Id { get; set; }
        //    public string AddressLine1 { get; set; }
        //    public string AddressLine2 { get; set; }
        //    public string Suburb { get; set; }
        //    public string City { get; set; }
        //    public string Province { get; set; }
        //    public int CountryId { get; set; }
        //    public string PostalCode { get; set; }

        //}


        //[Display(Name = "Address Line 1", Prompt = "Enter Address Line 1")]
        ////[Required(ErrorMessage = "Address Line 1 is required")]
        //public string AddressLine1 { get; set; }

        //[Display(Name = "Address Line 2", Prompt = "Enter Address Line 2")]
        ////[Required(ErrorMessage = "Address Line 2 is required")]
        //public string AddressLine2 { get; set; }

        //[Display(Name = "Suburb", Prompt = "Enter Suburb")]
        ////[Required(ErrorMessage = "Suburb is required")]
        //public string Suburb { get; set; }

        //[Display(Name = "City", Prompt = "Enter City")]
        ////[Required(ErrorMessage = "City is required")]
        //public string City { get; set; }

        //[Display(Name = "Province", Prompt = "Enter Province")]
        ////[Required(ErrorMessage = "Province is required")]
        //public string Province { get; set; }

        //[Display(Name = "Country", Prompt = "Enter Country")]
        ////[Required(ErrorMessage = "Suburb is required")]
        //public int CountryId { get; set; }

        //[Display(Name = "Postal Code", Prompt = "Enter Postal Code")]
        ////[Required(ErrorMessage = "Postal Code is required")]
        //public string PostalCode { get; set; }



        public int Id { get; set; }

        

        [Display(Name = "Membership Grade", Prompt = "Select Membership Grade")]
        //[Required(ErrorMessage = "Membership Type is required")]
        public int? MembershipGradeId { get; set; }
        public virtual MemberShipGrade MembershipGrade { get; set; }


        [Display(Name = "Nationality", Prompt = "Select Nationality")]
        //[Required(ErrorMessage = "Nationality is required")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }



        [Display(Name = "Transaction Currency", Prompt = "Select Transaction Currency")]
        //[Required(ErrorMessage = "Transaction Currency is required")]
        public int? TransactionCurrencyid { get; set; }
        public virtual Currency TransactionCurrency { get; set; }


        [Display(Name = "Member Status", Prompt = "Select Member Status")]
        //[Required(ErrorMessage = "Member Status is required")]
        public int? MemberStatusId { get; set; }
        public virtual MemberStatus MemberStatus { get; set; }


        [Display(Name = "Membership Type", Prompt = "Select Membership Type")]
        //[Required(ErrorMessage = "Membership Type is required")]
        public int? MembershipTypeId { get; set; }
        public virtual MembershipType MembershipType { get; set; }


        [Display(Name = "Member Branch", Prompt = "Select Member Branch")]
        //[Required(ErrorMessage = "Member Branch is required")]
        public int? MemberBranchId { get; set; }
        public virtual MemberBranch MemberBranch { get; set; }


        [Display(Name = "Member Level", Prompt = "Select Member Level")]
        //[Required(ErrorMessage = "Member Level is required")]
        public int? MemberLevelId { get; set; }
        public virtual MemberLevel MemberLevel { get; set; }


        [Display(Name = "Referral Type", Prompt = "Select Referral Type")]
        //[Required(ErrorMessage = "Referral Type is required")]
        public int? ReferralTypeId { get; set; }
        public virtual ReferralType ReferralType { get; set; }


        [Display(Name = "Referral Other", Prompt = "Select Referral Other")]
        //[Required(ErrorMessage = "Referral Other is required")]
        public string ReferralOther { get; set; }


        [Display(Name = "Member Team", Prompt = "Select Member Team")]
        //[Required(ErrorMessage = "Member Team is required")]
        public int? MemberTeamId { get; set; }
        public virtual MemberTeam MemberTeam { get; set; }


        [Display(Name = "Organization Name", Prompt = "Enter Organization")]
        //[Required(ErrorMessage = "Organization is required")]
        public int? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }


        [Display(Name = "Organization Structure", Prompt = "Select Organization Structure")]
        //[Required(ErrorMessage = "Organization is required")]
        public int? OrganizationStructureId { get; set; }
        public virtual OrganizationStructure OrganizationStructure { get; set; }

        public string ApplicaitonUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        public int? OwnerClientUserId { get; set; }
        public virtual ClientUser OwnerClientUser { get; set; }


        [Display(Name = "Client Branch", Prompt = "Select Client Branch")]
        [Required(ErrorMessage = "Organization is required")]
        public int? ClientBranchId { get; set; }
        public virtual ClientBranch ClientBranch { get; set; }


        [Display(Name = "Preferred Appointment Time", Prompt = "Enter Preferred Appointment Time")]
        //[Required(ErrorMessage = "Preferred Appointment Time is required")]
        public int? PreferredAppointmentTimeId { get; set; }
        public virtual PreferredContactTime PreferredAppointmentTime { get; set; }


        [Display(Name = "Highest Qualification", Prompt = "Select Qualification")]
        [Required(ErrorMessage = "Qualification is required")]
        public int? HighestQualitificationId { get; set; }
        public virtual Qualification HighestQualitification { get; set; }


        [Display(Name = "Home Language", Prompt = "Enter Home Language")]
        //[Required(ErrorMessage = "Home Language is required")]
        public int? HomeLanguageId { get; set; }
        public virtual Language HomeLanguage { get; set; }

        [Display(Name = "Volunteer Work Hours", Prompt = "Select Volunteer Work Hours")]
        //[Required(ErrorMessage = "Home Language is required")]
        public int? VolunteerWorkHoursId { get; set; }
        public virtual VolunteerHours VolunteerWorkHours { get; set; }


        [Display(Name = "Ethnicity", Prompt = "Select Ethnicity")]
        [Required(ErrorMessage = "Ethnicity is required")]
        public int? EthnicityId { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }


        [Display(Name = "Occupation", Prompt = "Select Occupation")]
        [Required(ErrorMessage = "Occupation is required")]
        public int? OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }

        
        [Display(Name = "Parent Member", Prompt = "Select Parent Member")]
        // [Required(ErrorMessage = "Parent Member is required")]
        public int? ParentMemberid { get; set; } // unused. Orgainizaiton id will be used
        public virtual Organization ParentMember { get; set; } // unused
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }


        [Display(Name = "Total CDP Points", Prompt = "Enter Total CDP Points")]
        // [Required(ErrorMessage = "Parent Member is required")]
        public int? TotalCDPPoints { get; set; }

        [Display(Name = "Company Account Balance", Prompt = "Enter Company Account Balance")]
        // [Required(ErrorMessage = "Company Account Balance is required")]
        public decimal? AccountBalanceOftheCompany { get; set; }

        [Display(Name = "Exchange Rate", Prompt = "Enter Exchange Rate")]
        // [Required(ErrorMessage = "Exchange Rate is required")]
        public decimal? ExchangeRate { get; set; }
        public decimal? Accountbalanceofthecompany_base { get; set; }

        
        [Display(Name = "Amount Written Off", Prompt = "Amount Written Off")]
        public decimal? AmountWrittenOff { get; set; }


         [Display(Name = "Date Written Off", Prompt = "Date Written Off")]
         public DateTime? DateWrittenOff { get; set; }

       [Display(Name = "Debt Request 1 Date", Prompt = "Request 1 Date")]
        public DateTime? Request1Debt { get; set; }

        [Display(Name = "Debt Request 2 Date", Prompt = "Request 2 Date")]
        public DateTime? Request2Debt { get; set; }

        [Display(Name = "Debt Request 3 Date", Prompt = "Request 3 date")]
        public DateTime? Request3Debt { get; set; }

        [Display(Name = "Debt Payment Received", Prompt = "Debt Payment Received")]
        public DateTime? DebtPaymentReceived { get; set; }

        [Display(Name = "Membership Number", Prompt = "Enter Membership Number")]
        // [Required(ErrorMessage = "Member Code is required")]
        public string MemberCode { get; set; }


        [Display(Name = "ID/Passport Number", Prompt = "Enter ID Number")]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }
        //public string QualificationName { get; set; }

        [Display(Name = "Tracking Number", Prompt = "Enter Post Certificate Tracking")]
        // [Required(ErrorMessage = "ID Number is required")]
        public string PostCertificateTracking { get; set; }

        [Display(Name = "Initials", Prompt = "Enter Initials")]
        //[Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }


        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Display(Name = "Fax To Email", Prompt = "Enter Fax To Email")]
        //[Required(ErrorMessage = "Fax To Email is required")]
        public string FaxToEmail { get; set; }

        [Display(Name = "Mobile Phone", Prompt = "Enter Mobile Phone")]
        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }

        [Display(Name = "Home Phone", Prompt = "Enter Home Phone Number")]
        //[Required(ErrorMessage = "Home Phone Number is required")]
        public string HomePhoneNumber { get; set; }

        [Display(Name = "Business Phone", Prompt = "Enter Business Phone Number")]
        //[Required(ErrorMessage = "Business Phone Number is required")]
        public string BusinessPhoneNumber { get; set; }


        [Display(Name = "Fax Number", Prompt = "Enter Fax Number")]
        //[Required(ErrorMessage = "Fax Number is required")]
        public string FAXNumber { get; set; }


        [Display(Name = "Email", Prompt = "Enter Email")]
        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Display(Name = "Secondary Email", Prompt = "Enter Secondary Email")]
        //[Required(ErrorMessage = "Secondary Email is required")]
        public string SecondaryEmail { get; set; }


        [Display(Name = "Notes", Prompt = "Enter Notes")]
        //[Required(ErrorMessage = "Business Phone Number is required")]
        public string Notes { get; set; }


        [Display(Name = "Job Title", Prompt = "Enter Job Title")]
        //[Required(ErrorMessage = "Job Title is required")]
        public string JobTitle { get; set; }
        //public string JobDuties { get; set; }


        [Display(Name = "Parent Member Name", Prompt = "Enter Parent Member Name")]
        //[Required(ErrorMessage = "Job Title is required")]
        public string ParentMemberName { get; set; }
        //public string StudentNumber { get; set; }
        //public string DisabilityLevel { get; set; }



        [Display(Name = "Special Member", Prompt = "Enter Special Member")]
        //[Required(ErrorMessage = "Special Member is required")]
        public bool? SpecialMember { get; set; }


        [Display(Name = "Special Admin Fee", Prompt = "Enter Admin Fee")]
        //[Required(ErrorMessage = "Admin Fee is required")]
        public bool? AdminFee { get; set; }

        [Display(Name = "ID Attached")]
        public bool? IDAttached { get; set; }

        [Display(Name = "Proof of Registration Attached")]
        public bool? ProofOfRegistrationAttached { get; set; }

        [Display(Name = "Qualification Attached")]
        public bool? QualificationAttached { get; set; }

        [Display(Name = "Dws Certificate Attached")]
        public bool? DwscertificAteattached { get; set; }

        [Display(Name = "Proof of Payment Received")]
        public bool? ProofofPaymentReceived { get; set; }

        [Display(Name = "Interested In Volunteer Work")]
        public bool? InterestedInVolunteerWork { get; set; }

        [Display(Name = "Publish in Annual Member Directory")]
        public bool? PublishCompanyInAnnualMemberDirectory { get; set; }

        [Display(Name = "Membership Fee Invoiced")]
        public bool? MembershipFeeInvoicedToCompany { get; set; }

        [Display(Name = "Application Form Complete")]
        public bool? ApplicationFormComplete { get; set; }

        [Display(Name = "Proof of Payment Sent")]
        public bool? AdminfeeProofofpaymentSent { get; set; }

        [Display(Name = "Referee Report")]
        public bool? RefereeReport { get; set; }

        [Display(Name = "Tax Invoice Sent")]
        public bool? TaxInvoiceSent { get; set; }

        [Display(Name = "Proof Of Payment Uploaded")]
        public bool? ProofOfPaymentUploaded { get; set; }

        [Display(Name = "Certificate Uploaded")]
        public bool? CertificateUploaded { get; set; }

        [Display(Name = "First Reminder Sent")]
        public bool? FirstReminderSent { get; set; }

        [Display(Name = "Second Reminder Sent")]
        public bool? SecondReminderSent { get; set; }

        [Display(Name = "Third Reminder Sent")]
        public bool? ThirdReminderSent { get; set; }
        public bool? New_Check { get; set; }

        [Display(Name = "Is Private")]
        public bool? IsPrivate { get; set; }

        [Display(Name = "Invoice Sent")]
        public bool? InvoiceSent { get; set; }

        public bool isApplicationCompleted { get; set; }

        [Display(Name = "Term Accepted")]
        [Required(ErrorMessage = "Please accept the Terms, to proceed")]
        public bool? TermAccepted { get; set; }

        [Display(Name = "Total Cdp points")]
        public bool? TotalCdppoints_State { get; set; }

        [Display(Name = "Allow Fax")]
        public bool? DonotFax { get; set; }

        [Display(Name = "Allow SMS")]
        public bool? DoNotSMS { get; set; }


        [Display(Name = "Allow Email")]
        public bool? DoNotEmail { get; set; }

        [Display(Name = "Allow Bulk Postal")]
        public bool? DonotBulkPostalMail { get; set; }

        [Display(Name = "Allow Bulk Email")]
        public bool? DonotBulkEmail { get; set; }

        [Display(Name = "Send Mass Marketing")]
        public bool? DonotSendMassMarketing { get; set; }

        [Display(Name = "Send Magazine")]
        public bool? DonotpostalMail { get; set; }

        [Display(Name = "Allow Call")]
        public bool? DonotPhone { get; set; }

        [Display(Name = "Send Follow Email")]
        public bool? FollowEmail { get; set; }

        [Display(Name = "Are you the Billing Contact?")]
        public bool? IsBillingContact { get; set; }

        [Display(Name = "Are you the Branch Contact?")]
        public bool? IsBranchContact { get; set; }

        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }

        [Display(Name = "Dws Registration Name")]
        public string DwsProcessControllerRegistrationName { get; set; }

        [Display(Name = "Existing Membership")]
        public int? ExistingMembershipId { get; set; }

        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "VAT Number")]
        public string VATNumber { get; set; }

        [Display(Name = "Employer Phone Number")]
        public string CompanyPhoneNumber2 { get; set; }

        [Display(Name = "Employer Address")]
        public string EmployerAddress { get; set; }

        [Display(Name = "Employer Postal Code")]
        public string CompanyPostalCode { get; set; }
        public bool? IsDisabled { get; set; }
        public DateTime? LastUsedInCampaignDate { get; set; }

        public DateTime? TotalCdpPointsCalculatedDate { get; set; }
        public DateTime? AdminFeeProofofpaymentReceivedDate { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Completed Date")]
        public DateTime? GradingCompletedDate { get; set; }
        
        [Display(Name = "Proforma Invoice Emailed")]
        public DateTime? ProformaInvoiceEmailedDate { get; set; }

        [Display(Name = "Proof of Payment Received")]
        public DateTime? ProofofPaymentReceivedDate { get; set; }

        [Display(Name = "Tax Invoice Emailed Date")]
        public DateTime? TaxInvoicEemailedDate { get; set; }

        [Display(Name = "Certificate Post Date")]
        public DateTime? PostingofCertificateDate { get; set; }

        [Display(Name = "Welcome Email Date")]
        public DateTime? CertificateAndwelcomeLetterEmailedDate { get; set; }

        [Display(Name = "Sent Date")]
        public DateTime? SentforGradingDate { get; set; }
        
        [Display(Name = "Proforma Invoice Sent Date")]
        public DateTime? ProformaInvoiceSentDate { get; set; }

        [Display(Name = "Reminder-1 Date")]
        public DateTime? PaymentReminder1Date { get; set; }

        [Display(Name = "Reminder-2 Date")]
        public DateTime? PaymentReminder2Date { get; set; }

        [Display(Name = "Reminder-3 Date")]
        public DateTime? PaymentReminder3Date { get; set; }

        [Display(Name = "No-Pay Cancelation Date")]
        public DateTime? CancelapplicationNopayDate { get; set; }

        [Display(Name = "Application Received Date")]
        public DateTime? ApplicationreceivedDate { get; set; }

        [Display(Name = "Request-2 Date")]
        public DateTime? Request2MemberFee { get; set; }

        [Display(Name = "Request-3 Date")]
        public DateTime? Request3MemberFee { get; set; }

        [Display(Name = "Payment Received Date")]
        public DateTime? AdminfeePaymentReceivedDate { get; set; }

        [Display(Name = "Application Cancelled Date")]
        public DateTime? ApplicationCancelledMemberfeeNotpaidDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public byte[] Photo { get; set; }

        #region WISA Specific
           public string OrganizationName { get; set; }
         public string OriginalSystemRecordId { get; set; }
        #endregion
        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<Cpd> Cpd { get; set; }
        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<EventAttendance> EventAttendance { get; set; }
        public virtual ICollection<EventRegistration> EventRegistration { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<MemberAddress> MemberAddress { get; set; }
        public virtual ICollection<MemberBankingDetail> MemberBankingDetail { get; set; }
        public virtual ICollection<MemberCommunicationPreference> MemberCommunicationPreference { get; set; }
        public virtual ICollection<MemberPlanHistory> MemberPlanHistory { get; set; }
        public virtual ICollection<PromotionResponse> PromotionResponse { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }

        public virtual ICollection<IndividualMemberShipHistory> IndividualMemberShipHistory { get; set; }
        public virtual ICollection<MarketingGroupXref> MarketingGroupXref { get; set; }
        public virtual ICollection<MarketingProfileXref> MarketingProfileXref { get; set; }
        public virtual ICollection<MemberAffliationXref> MemberAffliationXref { get; set; }
        public virtual ICollection<MemberFileXref> MemberFileXref { get; set; }
        public virtual ICollection<MemberQualificationXref> MemberQualificationXref { get; set; }

        public virtual ICollection<DWSClassMemberXref> DWSClassMemberXref { get; set; }
        public virtual ICollection<DivisionMemberXref> DivisionMemberXref { get; set; }

        public virtual ICollection<InvolvementMemberXref> InvolvementMemberXref { get; set; }
        public virtual ICollection<DisabilityMemberXref> DisabilityMemberXref { get; set; }
        public virtual ICollection<EmploymentMemberXref> EmploymentMemberXref { get; set; }

         public virtual ICollection<Organization> PrimaryContactOrganization { get; set; }
         public virtual ICollection<Organization> ContactPersonOrganization { get; set; }
         public virtual ICollection<Organization> BillingContactOrganization { get; set; }

    }
    public partial class MemberConfiguration : IEntityTypeConfiguration<MemberUser>
    {
        public void Configure(EntityTypeBuilder<MemberUser> builder)
        {

            builder.Property(e => e.AccountBalanceOftheCompany).IsRequired(false).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.ExchangeRate).IsRequired(false).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Accountbalanceofthecompany_base).IsRequired(false).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.MembershipGradeId).IsRequired(false);
           
            builder.Property(e => e.TransactionCurrencyid).IsRequired(false);

            builder.Property(e => e.MemberStatusId).IsRequired(false);

            builder.Property(e => e.MembershipTypeId).IsRequired(false);
            builder.Property(e => e.ReferralTypeId).IsRequired(false);
            builder.Property(e => e.OwnerClientUserId).IsRequired(false);

            builder.Property(e => e.MemberLevelId).IsRequired(false);

            builder.Property(e => e.ClientBranchId).IsRequired(false);
            builder.Property(e => e.MemberBranchId).IsRequired(false);
            builder.Property(e => e.OrganizationId).IsRequired(false);
            builder.Property(e => e.OrganizationStructureId).IsRequired(false);
            builder.Property(e => e.MemberTeamId).IsRequired(false);

            builder.Property(e => e.HomeLanguageId).IsRequired(false);

            builder.Property(e => e.EthnicityId).IsRequired(false);

            builder.Property(e => e.OccupationId).IsRequired(false);

            builder.Property(e => e.HighestQualitificationId).IsRequired(false);

            builder.Property(e => e.ParentMemberid).IsRequired(false);


            builder.Property(e => e.ApplicaitonUserId).IsRequired(false).HasMaxLength(50);

            builder.Property(e => e.MemberCode)
           .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.IDNumber)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.PostCertificateTracking)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.Initials)
        .IsRequired(false).HasMaxLength(50);

            builder.Property(e => e.CompanyName)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.FaxToEmail)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.MobilePhone)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.HomePhoneNumber)
            .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.BusinessPhoneNumber)
         .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.FAXNumber)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.Email)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.SecondaryEmail)
        .IsRequired(false).HasMaxLength(100);

            builder.Property(e => e.Notes)
        .IsRequired(false).HasColumnType("Text");

            builder.Property(e => e.JobTitle)
        .IsRequired(false).HasMaxLength(120);

            builder.Property(e => e.ParentMemberName)
      .IsRequired(false).HasMaxLength(100);


            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");

            builder.Property(e => e.Photo).HasColumnType("blob");



            builder.HasOne(d => d.MembershipGrade)
            .WithMany(p => p.MemberUser)
            .HasForeignKey(d => d.MembershipGradeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Member_MembershipGrade");

          //  builder.HasOne(d => d.Nationality)
          //.WithMany(p => p.MemberUser)
          //.HasForeignKey(d => d.NationalityId)
          //.OnDelete(DeleteBehavior.ClientSetNull)
          //.HasConstraintName("FK_Member_Nationality");

            builder.HasOne(d => d.TransactionCurrency)
          .WithMany(p => p.MemberUser)
          .HasForeignKey(d => d.TransactionCurrencyid)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Member_Currency");

            builder.HasOne(d => d.MemberStatus)
        .WithMany(p => p.MemberUser)
        .HasForeignKey(d => d.MemberStatusId)
          .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Member_MemberStatus");

            builder.HasOne(d => d.MembershipType)
          .WithMany(p => p.MemberUser)
          .HasForeignKey(d => d.MembershipTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Member_MembershipType");

            builder.HasOne(d => d.MemberBranch)
              .WithMany(p => p.Member)
              .HasForeignKey(d => d.MemberBranchId)
               .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_Member_MemberBranch");

            builder.HasOne(d => d.MemberLevel)
                .WithMany(p => p.Member)
                .HasForeignKey(d => d.MemberLevelId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_MemberLevel");

            builder.HasOne(d => d.ReferralType)
               .WithMany(p => p.Member)
               .HasForeignKey(d => d.ReferralTypeId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Member_ReferralType");

            builder.HasOne(d => d.MemberTeam)
                .WithMany(p => p.Member)
                .HasForeignKey(d => d.MemberTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_MemberTeam");

            builder.HasOne(d => d.Organization)
                .WithMany(p => p.Member)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_Organization");

            builder.HasOne(d => d.OrganizationStructure)
                .WithMany(p => p.Member)
                .HasForeignKey(d => d.OrganizationStructureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_OrganizationStructure");


            builder.HasOne(d => d.ApplicationUser)
           .WithMany(p => p.MemberUser)
           .HasForeignKey(d => d.ApplicaitonUserId)
               .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_ApplicationUser");

            builder.HasOne(d => d.OwnerClientUser)
          .WithMany(p => p.MemberUser)
          .HasForeignKey(d => d.OwnerClientUserId)
           .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Member_OwnerClientUser");


            

            builder.HasOne(d => d.ClientBranch)
            .WithMany(p => p.MemberUser)
            .HasForeignKey(d => d.ClientBranchId)
             .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Member_ClientBranch");

            builder.HasOne(d => d.PreferredAppointmentTime)
           .WithMany(p => p.MemberUser)
           .HasForeignKey(d => d.PreferredAppointmentTimeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_PreferredContactTime");

            builder.HasOne(d => d.HighestQualitification)
      .WithMany(p => p.MemberUser)
      .HasForeignKey(d => d.HighestQualitificationId)
       .OnDelete(DeleteBehavior.ClientSetNull)
      .HasConstraintName("FK_Member_Qualification");

            builder.HasOne(d => d.HomeLanguage)
      .WithMany(p => p.MemberUser)
      .HasForeignKey(d => d.HomeLanguageId)
       .OnDelete(DeleteBehavior.ClientSetNull)
      .HasConstraintName("FK_Member_Language");

            builder.HasOne(d => d.VolunteerWorkHours)
           .WithMany(p => p.MemberUser)
           .HasForeignKey(d => d.VolunteerWorkHoursId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_VolunteerHours");

            builder.HasOne(d => d.Ethnicity)
           .WithMany(p => p.MemberUser)
           .HasForeignKey(d => d.EthnicityId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_Ethnicity");

            builder.HasOne(d => d.Occupation)
           .WithMany(p => p.MemberUser)
           .HasForeignKey(d => d.OccupationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Member_Occupation");

        }

    }
    public static partial class Seeder
    {
        public static void SeedMember(this ModelBuilder modelBuilder)
        {

        }
    }
}
