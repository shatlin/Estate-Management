using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;

namespace MM.ClientModels
{
    public partial class Organization
    {
        public Organization()
        {
            Member = new HashSet<MemberUser>();
            MemberAddress = new HashSet<MemberAddress>();
            MemberPlanHistory = new HashSet<MemberPlanHistory>();
            OrganizationBusinessXref = new HashSet<OrganizationBusinessXref>();
            OrganizationMemberShipHistory = new HashSet<OrganizationMemberShipHistory>();
        }

        public int Id { get; set; }

        [Display(Name = "Name", Prompt = "Enter Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Company Phone Number", Prompt = "Enter Phone Number")]
        [Required(ErrorMessage = "Company Phone Number is required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Mobile Number", Prompt = "Enter Mobile Number")]
       // [Required(ErrorMessage = "Business Number is required")]
        public string SecondaryPhoneNumber { get; set; }

        [Display(Name = "Short Name", Prompt = "Enter Short Name")]
        //[Required(ErrorMessage = "Short Name is required")]
        public string ShortName { get; set; }

        [Display(Name = "Notes", Prompt = "Enter Description")]
        //[Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string WebSite { get; set; }

        [Display(Name = "VAT Number", Prompt = "Enter VAT Number")]
        //[Required(ErrorMessage = "VAT Number is required")]
        public string TaxNumber { get; set; }

        [Display(Name = "Company Registration Number", Prompt = "Enter Registration Number")]
        [Required(ErrorMessage = "Registration Number is required")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Member Code", Prompt = "Enter Member Code")]
        //[Required(ErrorMessage = "Member Code is required")]
        public string OrgMemberCode { get; set; }

        [Display(Name = "Member Status", Prompt = "Select Member Status")]
        //[Required(ErrorMessage = "Member Status is required")]
        public int? MemberStatusId { get; set; }
        public virtual MemberStatus MemberStatus { get; set; }

        [Display(Name = "Member Level", Prompt = "Select Member Level")]
        //[Required(ErrorMessage = "Member Level is required")]
        public int? MemberLevelId { get; set; } //will be unused for WISA
        public virtual MemberLevel MemberLevel { get; set; }


        [Display(Name = "Membership Grade", Prompt = "Select Membership Grade")]
        //[Required(ErrorMessage = "Membership Grade is required")]
        public int? OrganizationGradeId { get; set; } // Membership Grade (ec_membershiptype) from WISA will be mapped to this.Organization Grade table will be used 
        public virtual OrganizationGrade OrganizationGrade { get; set; }


        [Display(Name = "Organization Type", Prompt = "Select Organization Type")]
        //[Required(ErrorMessage = "Membership Type is required")]
        public int? OrganizationTypeId { get; set; } // ec_nonindividualmembercategories  from Wisa will be mapped to this. This will be mapped to memebership type trable
        public virtual OrganizationType OrganizationType { get; set; }

        [Display(Name = "Currency", Prompt = "Select Currency")]
        //[Required(ErrorMessage = "Currency is required")]
        public int? TransactionCurrencyid { get; set; }
        public virtual Currency TransactionCurrency { get; set; }

        [Display(Name = "Primary Contact", Prompt = "Enter Primary Contact Name")]
        //[Required(ErrorMessage = "Primary Contact is required")]
        public int? PrimaryContactId { get; set; }//Person with highest Authority
        public virtual MemberUser PrimaryContact { get; set; }

        [Display(Name = "Contact Person", Prompt = "Enter Contact Person Name")]
        //[Required(ErrorMessage = "Contact Person is required")]
        public int? ContactPersonId { get; set; } //person with whom we can contact mainly
        public virtual MemberUser ContactPerson { get; set; }

        [Display(Name = "Billing Contact Name", Prompt = "Enter Billing Contact Name")]
        //[Required(ErrorMessage = "Billing Contact is required")]
        public int? BillingContactId { get; set; } //Person to send Billing to
        public virtual MemberUser BillingContact { get; set; }

        [Display(Name = "Client Branch", Prompt = "Select Client Branch Name")]
        //[Required(ErrorMessage = "Client Branch is required")]
        public int? ClientBranchId { get; set; }
        public virtual ClientBranch ClientBranch { get; set; }

        [Display(Name = "Account Balance")]
        //[Required(ErrorMessage = "Account Balance is required")]
        public decimal? AccountBalance { get; set; }

        [Display(Name = "Is Term Accepted")]
        public bool IsTermAccepted { get; set; }

        [Display(Name = "Is Invoice Sent")]
        public bool? IsInvoiceSent { get; set; }

        [Display(Name = "Is MembershipFee Invoiced to Company")]
        public bool? IsMembershipFeeInvoicedToCompany { get; set; }

        [Display(Name = "Publish Company In Annual Member Directory")]
        public bool? PublishCompanyInAnnualMemberDirectory { get; set; }

        [Display(Name = "Amount Written Off")]
        public decimal? AmountWrittenOff { get; set; }

        [Display(Name = "Date Written Off")]
        public DateTime? DatetWrittenOff { get; set; }

        [Display(Name = "Application Received Date")]
        public DateTime? ApplicationReceivedDate { get; set; }

        [Display(Name = "Is Application Form Complete")]
        public bool? IsApplicationFormComplete { get; set; }

        [Display(Name = "Proforma Invoice Emailed Date")]
        public DateTime? ProformaInvoiceEmailedDate { get; set; }

        [Display(Name = "Proof of Payment Received & Uploaded")]
        public bool? ProofOfpaymentReceivedandUploaded { get; set; }

        [Display(Name = "Reminder-1 Date")]
        public DateTime? PaymentReminder1Date { get; set; }

        [Display(Name = "Reminder-2 Date")]
        public DateTime? PaymentReminder2Date { get; set; }

        [Display(Name = "Reminder-3 Date")]
        public DateTime? PaymentReminder3Date { get; set; }

        [Display(Name = "Cancel Application Nopay Date")]
        public DateTime? CancelapplicationNopayDate { get; set; }

        [Display(Name = "Sent for Grading Date")]
        public DateTime? SentforGradingDate { get; set; }

        [Display(Name = "Grading Completed Date")]
        public DateTime? GradingCompletedDate { get; set; }

        [Display(Name = "Tax Invoice Emailed Date")]
        public DateTime? TaxInvoicEmailedDate { get; set; }

        [Display(Name = "Proof of Payment Received Date")]
        public DateTime? ProofofPaymentReceivedDate { get; set; }

        //[Display(Name = "Request-1 Date")]
        //public DateTime? Request1MemberFee { get; set; }

        [Display(Name = "Request-2 Date")]
        public DateTime? Request2MemberFee { get; set; }

        [Display(Name = "Request-3 Date")]
        public DateTime? Request3MemberFee { get; set; }

        [Display(Name = "No Pay - Cancelation Date")]
        public DateTime? ApplicationCancelledMemberfeeNotpaidDate { get; set; }

        [Display(Name = "Certificate & welcome Letter Date")]
        public DateTime? CertificateAndwelcomeLetterEmailedDate { get; set; }

        [Display(Name = "Is Certificate Uploaded")]
        public bool? IsCertificateUploaded { get; set; }

        [Display(Name = "Owner Client User")]
        public int? OwnerClientUserId { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }


        [Display(Name = "Start Date", Prompt = "Enter Start date")]
        //[Required(ErrorMessage = "Start Date is required")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date", Prompt = "Enter End date")]
        //[Required(ErrorMessage = "End Date is required")]
        public DateTime? EndDate { get; set; }


        #region wisaspecific

        [Display(Name = "Is Credit On Hold", Prompt = "Select Credit Hold On")]
        //[Required(ErrorMessage = "Credit Hold On is required")]
        public bool? IsCreditOnHold { get; set; }

        [Display(Name = "Account Balance Base")]
        //[Required(ErrorMessage = "Account Balance Base is required")]
        public decimal? AccountBalanceBase { get; set; }

        [Display(Name = "Is Memberfee Paid")]
        //[Required(ErrorMessage = "Member Fee is required")]
        public bool? IsmemberFeePaid { get; set; }

        [Display(Name = "Is Certificate Posted")]
        //[Required(ErrorMessage = "Ceritificate Posted is required")]
        public bool? IsCertificatePosted { get; set; }

        [Display(Name = "Is Memberfee Proof of Payment Sent")]
        public bool? IsMemberfeeProofofpaymentSent { get; set; }

        [Display(Name = "Memberfee Payment Received Date")]
        public DateTime? MemberfeePaymentReceivedDate { get; set; }

        [Display(Name = "Posting of Certificate Date")]
        public DateTime? PostingofCertificateDate { get; set; }

        [Display(Name = "Amount Due As At Date")]
        public DateTime? AmountDueAsAtDate { get; set; }

        [Display(Name = "Post Certificate Tracking")]
        public string PostCertificateTracking { get; set; }

        [Display(Name = "Is AdminFee Paid")]
        public bool? IsAdminFeePaid { get; set; }

        [Display(Name = "Adminfee Proof of Payment Sent")]
        public bool? IsAdminfeeProofofpaymentSent { get; set; }

        [Display(Name = "Payment Received Date")]
        public DateTime? AdminfeePaymentReceivedDate { get; set; }

        [Display(Name = "Original System Record ID")]
        public string OriginalSystemRecordId { get; set; }

        [Display(Name = "Primary Contact Name")]
        public string PrimaryContactName { get; set; }

        [Display(Name = "Contact Person Name")]
        public string ContactPersonName { get; set; }
        #endregion

        public virtual ICollection<MemberUser> Member { get; set; }
        public virtual ICollection<MemberAddress> MemberAddress { get; set; }
     
        public virtual ICollection<MemberPlanHistory> MemberPlanHistory { get; set; }

        public virtual ICollection<OrganizationMemberShipHistory> OrganizationMemberShipHistory { get; set; }

        public virtual ICollection<OrganizationBusinessXref> OrganizationBusinessXref { get; set; }

    }
    public partial class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SecondaryPhoneNumber).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.ShortName).IsRequired(false).HasMaxLength(50);

            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(2000);
            builder.Property(e => e.WebSite).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.TaxNumber).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.RegistrationNumber).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.OrgMemberCode).IsRequired(false).HasMaxLength(20);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.CreatedOn).HasColumnType("datetime");

            builder.Property(e => e.AccountBalanceBase).IsRequired(false).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.AccountBalance).IsRequired(false).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.AmountWrittenOff).IsRequired(false).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.MemberStatusId).IsRequired(false);
            builder.Property(e => e.MemberLevelId).IsRequired(false);
            builder.Property(e => e.OrganizationGradeId).IsRequired(false);
            builder.Property(e => e.OrganizationTypeId).IsRequired(false);
            builder.Property(e => e.TransactionCurrencyid).IsRequired(false);
            builder.Property(e => e.OwnerClientUserId).IsRequired(false);
            builder.Property(e => e.ClientBranchId).IsRequired(false);
            builder.Property(e => e.OriginalSystemRecordId).IsRequired(false).HasMaxLength(50);
            builder.Property(e => e.PostCertificateTracking).IsRequired(false).HasMaxLength(100);




            builder.HasOne(d => d.MemberStatus)
     .WithMany(p => p.Organization)
     .HasForeignKey(d => d.MemberStatusId)
       .OnDelete(DeleteBehavior.ClientSetNull)
     .HasConstraintName("FK_Organization_MemberStatus");

            builder.HasOne(d => d.MemberLevel)
           .WithMany(p => p.Organization)
           .HasForeignKey(d => d.MemberLevelId)
            .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_Organization_MemberLevel");

            builder.HasOne(d => d.OrganizationGrade)
          .WithMany(p => p.Organization)
          .HasForeignKey(d => d.OrganizationGradeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Organization_OrganizationGrade");


            builder.HasOne(d => d.OrganizationType)
        .WithMany(p => p.Organization)
        .HasForeignKey(d => d.OrganizationTypeId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Organization_OrganizationType");

            builder.HasOne(d => d.TransactionCurrency)
          .WithMany(p => p.Organization)
          .HasForeignKey(d => d.TransactionCurrencyid)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Organization_Currency");


            builder.HasOne(d => d.PrimaryContact)
       .WithMany(p => p.PrimaryContactOrganization)
       .HasForeignKey(d => d.PrimaryContactId)
       .OnDelete(DeleteBehavior.ClientSetNull)
       .HasConstraintName("FK_Organization_PrimaryContact");

            builder.HasOne(d => d.ContactPerson)
       .WithMany(p => p.ContactPersonOrganization)
       .HasForeignKey(d => d.ContactPersonId)
       .OnDelete(DeleteBehavior.ClientSetNull)
       .HasConstraintName("FK_Organization_ContactPerson");

            builder.HasOne(d => d.BillingContact)
          .WithMany(p => p.BillingContactOrganization)
          .HasForeignKey(d => d.BillingContactId)
           .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Organization_BillingContact");

            builder.HasOne(d => d.ClientBranch)
            .WithMany(p => p.Organization)
            .HasForeignKey(d => d.ClientBranchId)
             .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Organization_ClientBranch");


        }

    }
    public static partial class Seeder
    {
        public static void SeedOrganization(this ModelBuilder modelBuilder)
        {

        }
    }
}


