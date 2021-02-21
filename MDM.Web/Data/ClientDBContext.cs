using System;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MM.ClientModels
{

    public partial class ClientDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ClientDbContext()
        {
        }

        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {
        }

      
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }

        public virtual DbSet<MemberShipChangeReason> MemberShipChangeReason { get; set; }

        public virtual DbSet<IndividualMemberShipHistory> IndividualMemberShipHistory { get; set; }

        public virtual DbSet<OrganizationMemberShipHistory> OrganizationMemberShipHistory { get; set; }
        public virtual DbSet<Affliation> Affliation { get; set; }
        public virtual DbSet<BankingDetail> BankingDetail { get; set; }
        public virtual DbSet<Billing> Billing { get; set; }
        public virtual DbSet<BillingCommunication> BillingCommunication { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ClientOrganization> ClientOrganization { get; set; }
        public virtual DbSet<ClientPlanHistory> ClientPlanHistory { get; set; }
        public virtual DbSet<ClientOrganizationType> ClientOrganizationGrade { get; set; }
        public virtual DbSet<OrganizationGrade> OrganizationGrade { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<OrganizationBusinessXref> OrganizationBusinessXref { get; set; }
        public virtual DbSet<MemberRefereeXref> MemberRefereeXref { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<CommunicationPreference> CommunicationPreference { get; set; }
        public virtual DbSet<CommunicationType> CommunicationType { get; set; }
        public virtual DbSet<ContactUsRelatedTo> ContactUsRelatedTo { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<CorrespondenceType> CorrespondenceType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        //public virtual DbSet<Nationality> Nationality { get; set; }

        public virtual DbSet<Cpd> Cpd { get; set; }
        public virtual DbSet<CpdmembershipTypeSetUp> CPDMembershipTypeSetUp { get; set; }
        public virtual DbSet<CpdmemberLevelSetUp> CpdmemberLevelSetUp { get; set; }
        public virtual DbSet<CpdmemberTeamSetUp> CpdmemberTeamSetUp { get; set; }
        public virtual DbSet<CpdMemberShipGradeSetUp> CPDMembershipGradeSetUp { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CustomField> CustomField { get; set; }
        public virtual DbSet<CustomFieldLookUp> CustomFieldLookUp { get; set; }
        public virtual DbSet<CustomFieldName> CustomFieldName { get; set; }
        public virtual DbSet<DateSetting> DateSetting { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Donation> Donation { get; set; }
        public virtual DbSet<EmailCcrule> EmailCcrule { get; set; }
        public virtual DbSet<EmailTemplateContent> EmailTemplateContent { get; set; }
        public virtual DbSet<EmailTemplateName> EmailTemplateName { get; set; }
        public virtual DbSet<EmailType> EmailType { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentCount> EquipmentCount { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAccess> EventAccess { get; set; }
        public virtual DbSet<EventAttendance> EventAttendance { get; set; }
        public virtual DbSet<EventCommunication> EventCommunication { get; set; }
        public virtual DbSet<EventCost> EventCost { get; set; }
        public virtual DbSet<EventCostItem> EventCostItem { get; set; }
        public virtual DbSet<EventEquipment> EventEquipment { get; set; }
        public virtual DbSet<EventMinute> EventMinute { get; set; }
        public virtual DbSet<EventMinuteStatus> EventMinuteStatus { get; set; }
        public virtual DbSet<EventPreRequisiteEvent> EventPreRequisiteEvent { get; set; }
        public virtual DbSet<EventRegistration> EventRegistration { get; set; }
        public virtual DbSet<EventResponseType> EventResponseType { get; set; }
        public virtual DbSet<EventRestrictionList> EventRestrictionList { get; set; }
        public virtual DbSet<EventRole> EventRole { get; set; }
        public virtual DbSet<EventRoleUserXref> EventRoleUserXref { get; set; }
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceSetting> InvoiceSetting { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public virtual DbSet<LandingPage> LandingPage { get; set; }
        public virtual DbSet<MarketingGroup> MarketingGroup { get; set; }
        public virtual DbSet<MarketingGroupXref> MarketingGroupXref { get; set; }
        public virtual DbSet<MarketingProfile> MarketingProfile { get; set; }
        public virtual DbSet<MarketingProfileXref> MarketingProfileXref { get; set; }
        public virtual DbSet<MemberUser> MemberUser { get; set; }
        public virtual DbSet<MemberAddress> MemberAddress { get; set; }
        public virtual DbSet<MemberAffliationXref> MemberAffliationXref { get; set; }
        public virtual DbSet<MemberBankingDetail> MemberBankingDetail { get; set; }
        public virtual DbSet<MemberBranch> MemberBranch { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public virtual DbSet<MemberCodeGenerator> MemberCodeGenerator { get; set; }
        public virtual DbSet<MemberCommunicationPreference> MemberCommunicationPreference { get; set; }

        public virtual DbSet<MemberLevel> MemberLevel { get; set; }
        public virtual DbSet<MemberLoginAudit> MemberLoginAudit { get; set; }
        public virtual DbSet<MemberPlanHistory> MemberPlanHistory { get; set; }

        public virtual DbSet<MemberStatus> MemberStatus { get; set; }
        public virtual DbSet<MemberTeam> MemberTeam { get; set; }
        public virtual DbSet<MemberShipGrade> MembershipGrade { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationStructure> OrganizationStructure { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PayPalConnectionMode> PayPalConnectionMode { get; set; }
        public virtual DbSet<PayPalPreferredPaymentGateway> PayPalPreferredPaymentGateway { get; set; }
        public virtual DbSet<PaymentCard> PaymentCard { get; set; }
        public virtual DbSet<PaymentGateway> PaymentGateway { get; set; }
        public virtual DbSet<PaymentSetting> PaymentSetting { get; set; }
        public virtual DbSet<PaymentSettingAllowedCard> PaymentSettingAllowedCard { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PlanCanChangeToXref> PlanCanChangeToXref { get; set; }
        public virtual DbSet<PlanDetail> PlanDetail { get; set; }
        public virtual DbSet<PlanFrequency> PlanFrequency { get; set; }
        public virtual DbSet<PlanMaster> PlanMaster { get; set; }
        public virtual DbSet<PromotionDetail> PromotionDetail { get; set; }
        public virtual DbSet<PromotionMaster> PromotionMaster { get; set; }
        public virtual DbSet<PromotionResponse> PromotionResponse { get; set; }
        public virtual DbSet<PromotionResponseType> PromotionResponseType { get; set; }

        public virtual DbSet<ReferralType> ReferralType { get; set; }
        public virtual DbSet<Refund> Refund { get; set; }
        public virtual DbSet<RelatedTo> RelatedTo { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermissionXref> RolePermissionXref { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<TaxPolicy> TaxPolicy { get; set; }
        public virtual DbSet<TaxScope> TaxScope { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }
        public virtual DbSet<TimeFormat> TimeFormat { get; set; }
        public virtual DbSet<ClientTimeZone> ClientTimeZone { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<ClientUser> ClientUser { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
        public virtual DbSet<MemberActivity> MemberActivity { get; set; }
        public virtual DbSet<UserRoleXref> UserRoleXref { get; set; }
        public virtual DbSet<MemberFileXref> MemberFileXref { get; set; }
        public virtual DbSet<MemberEmailXref> MemberEmailXref { get; set; }
        public virtual DbSet<MemberNotesXref> MemberNotesXref { get; set; }
        public virtual DbSet<MemberQualificationXref> MemberQualificationXref { get; set; }
        public virtual DbSet<InvolvementMemberXref> InvolvementMemberXref { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<PreferredContactTime> PreferredContactTime { get; set; }
        public virtual DbSet<DWSClass> DWSClass { get; set; }
        public virtual DbSet<DWSClassMemberXref> DWSClassMemberXref { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<DivisionMemberXref> DivisionMemberXref { get; set; }
        public virtual DbSet<Involvement> Involvement { get; set; }
        public virtual DbSet<Disability> Disability { get; set; }
        public virtual DbSet<DisabilityLevel> DisabilityLevel { get; set; }
        public virtual DbSet<DisabilityMemberXref> DisabilityMemberXref { get; set; }
        public virtual DbSet<VolunteerHours> VolunteerHours { get; set; }
        public virtual DbSet<EmploymentCategory> EmploymentCategory { get; set; }
        public virtual DbSet<EmploymentMemberXref> EmploymentMemberXref { get; set; }
        public virtual DbSet<QualificationCategory> QualificationCategory { get; set; }
        public virtual DbSet<QualificationType> QualificationType { get; set; }
        public virtual DbSet<QualificationEnrolmentCategory> QualificationEnrolmentCategory { get; set; }
        public virtual DbSet<ClientBranch> ClientBranch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(50));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(50));
            modelBuilder.Entity<ApplicationRole>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<ApplicationRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(50));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(50));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(50));
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration()).SeedAccountType();
            modelBuilder.ApplyConfiguration(new AddressConfiguration()).SeedAddress();
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration()).SeedAddressType();
            modelBuilder.ApplyConfiguration(new AffliationConfiguration()).SeedAffliation();
            modelBuilder.ApplyConfiguration(new BankingDetailConfiguration()).SeedBankingDetail();
            modelBuilder.ApplyConfiguration(new BillingConfiguration()).SeedBilling();
            modelBuilder.ApplyConfiguration(new BillingCommunicationConfiguration()).SeedBillingCommunication();
            modelBuilder.ApplyConfiguration(new CityConfiguration()).SeedCity();
            modelBuilder.ApplyConfiguration(new ClientOrganizationConfiguration()).SeedClientOrganization();
            modelBuilder.ApplyConfiguration(new ClientPlanHistoryConfiguration()).SeedClientPlanHistory();
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration()).SeedUserType();
            modelBuilder.ApplyConfiguration(new OrganizationGradeConfiguration()).SeedOrganizationGrade();
            modelBuilder.ApplyConfiguration(new OrganizationTypeConfiguration()).SeedOrganizationType();
            modelBuilder.ApplyConfiguration(new BusinessConfiguration()).SeedBusiness();
            modelBuilder.ApplyConfiguration(new ClientOrganizationTypeConfiguration()).SeedClientOrganizationType();
            modelBuilder.ApplyConfiguration(new ClientUserConfiguration()).SeedClientUser();
            modelBuilder.ApplyConfiguration(new ContactUsConfiguration()).SeedContactUs();
            modelBuilder.ApplyConfiguration(new ContactUsRelatedToConfiguration()).SeedContactUsRelatedTo();
            modelBuilder.ApplyConfiguration(new CommunicationPreferenceConfiguration()).SeedCommunicationPreference();
            modelBuilder.ApplyConfiguration(new CommunicationTypeConfiguration()).SeedCommunicationType();
            modelBuilder.ApplyConfiguration(new CorrespondenceTypeConfiguration()).SeedCorrespondenceType();
            modelBuilder.ApplyConfiguration(new CountryConfiguration()).SeedCountry();
            //modelBuilder.ApplyConfiguration(new NationalityConfiguration()).SeedNationality();
            modelBuilder.ApplyConfiguration(new CpdConfiguration()).SeedCpd();
            modelBuilder.ApplyConfiguration(new CPDMembershipTypeSetUpConfiguration()).SeedCPDMembershipTypeSetUp();
            modelBuilder.ApplyConfiguration(new CpdmemberLevelSetUpConfiguration()).SeedCpdmemberLevelSetUp();
            modelBuilder.ApplyConfiguration(new CpdmemberTeamSetUpConfiguration()).SeedCpdmemberTeamSetUp();
            modelBuilder.ApplyConfiguration(new CPDMembershipGradeSetUpConfiguration()).SeedCPDMembershipGradeSetUp();
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration()).SeedCurrency();
            modelBuilder.ApplyConfiguration(new CustomFieldConfiguration()).SeedCustomField();
            modelBuilder.ApplyConfiguration(new CustomFieldLookUpConfiguration()).SeedCustomFieldLookUp();
            modelBuilder.ApplyConfiguration(new CustomFieldNameConfiguration()).SeedCustomFieldName();
            modelBuilder.ApplyConfiguration(new DateSettingConfiguration()).SeedDateSetting();
            modelBuilder.ApplyConfiguration(new DesignationConfiguration()).SeedDesignation();
            modelBuilder.ApplyConfiguration(new DonationConfiguration()).SeedDonation();
            modelBuilder.ApplyConfiguration(new EmailCcruleConfiguration()).SeedEmailCcrule();
            modelBuilder.ApplyConfiguration(new EmailTemplateContentConfiguration()).SeedEmailTemplateContent();
            modelBuilder.ApplyConfiguration(new EmailTemplateNameConfiguration()).SeedEmailTemplateName();
            modelBuilder.ApplyConfiguration(new EmailTypeConfiguration()).SeedEmailType();
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration()).SeedEquipment();
            modelBuilder.ApplyConfiguration(new EquipmentCountConfiguration()).SeedEquipmentCount();
            modelBuilder.ApplyConfiguration(new EventConfiguration()).SeedEvent();
            modelBuilder.ApplyConfiguration(new EventAccessConfiguration()).SeedEventAccess();
            modelBuilder.ApplyConfiguration(new EventAttendanceConfiguration()).SeedEventAttendance();
            modelBuilder.ApplyConfiguration(new EventCommunicationConfiguration()).SeedEventCommunication();
            modelBuilder.ApplyConfiguration(new EventCostConfiguration()).SeedEventCost();
            modelBuilder.ApplyConfiguration(new EventCostItemConfiguration()).SeedEventCostItem();
            modelBuilder.ApplyConfiguration(new EventEquipmentConfiguration()).SeedEventEquipment();
            modelBuilder.ApplyConfiguration(new EventMinuteConfiguration()).SeedEventMinute();
            modelBuilder.ApplyConfiguration(new EventMinuteStatusConfiguration()).SeedEventMinuteStatus();
            modelBuilder.ApplyConfiguration(new EventPreRequisiteEventConfiguration()).SeedEventPreRequisiteEvent();
            modelBuilder.ApplyConfiguration(new EventRegistrationConfiguration()).SeedEventRegistration();
            modelBuilder.ApplyConfiguration(new EventResponseTypeConfiguration()).SeedEventResponseType();
            modelBuilder.ApplyConfiguration(new EventRestrictionListConfiguration()).SeedEventRestrictionList();
            modelBuilder.ApplyConfiguration(new EventRoleConfiguration()).SeedEventRole();
            modelBuilder.ApplyConfiguration(new EventRoleUserXrefConfiguration()).SeedEventRoleUserXref();
            modelBuilder.ApplyConfiguration(new FileTypeConfiguration()).SeedFileType();
            modelBuilder.ApplyConfiguration(new GenderConfiguration()).SeedGender();
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration()).SeedInvoice();
            modelBuilder.ApplyConfiguration(new InvoiceSettingConfiguration()).SeedInvoiceSetting();
            modelBuilder.ApplyConfiguration(new InvoiceStatusConfiguration()).SeedInvoiceStatus();
            modelBuilder.ApplyConfiguration(new LandingPageConfiguration()).SeedLandingPage();
            modelBuilder.ApplyConfiguration(new MarketingGroupConfiguration()).SeedMarketingGroup();
            modelBuilder.ApplyConfiguration(new MarketingGroupXrefConfiguration()).SeedMarketingGroupXref();
            modelBuilder.ApplyConfiguration(new MarketingProfileConfiguration()).SeedMarketingProfile();
            modelBuilder.ApplyConfiguration(new MarketingProfileXrefConfiguration()).SeedMarketingProfileXref();
            modelBuilder.ApplyConfiguration(new MemberConfiguration()).SeedMember();
            modelBuilder.ApplyConfiguration(new MemberAddressConfiguration()).SeedMemberAddress();
            modelBuilder.ApplyConfiguration(new MemberAffliationXrefConfiguration()).SeedMemberAffliationXref();
            modelBuilder.ApplyConfiguration(new OrganizationBusinessXrefConfiguration()).SeedOrganizationBusinessXref();
            modelBuilder.ApplyConfiguration(new MemberBankingDetailConfiguration()).SeedMemberBankingDetail();
            modelBuilder.ApplyConfiguration(new MemberBranchConfiguration()).SeedMemberBranch();
            modelBuilder.ApplyConfiguration(new MembershipTypeConfiguration()).SeedMembershipType();
            modelBuilder.ApplyConfiguration(new MemberCodeGeneratorConfiguration()).SeedMemberCodeGenerator();
            modelBuilder.ApplyConfiguration(new MemberCommunicationPreferenceConfiguration()).SeedMemberCommunicationPreference();

            modelBuilder.ApplyConfiguration(new MemberLevelConfiguration()).SeedMemberLevel();
            modelBuilder.ApplyConfiguration(new MemberLoginAuditConfiguration()).SeedMemberLoginAudit();
            modelBuilder.ApplyConfiguration(new MemberPlanHistoryConfiguration()).SeedMemberPlanHistory();

            modelBuilder.ApplyConfiguration(new MemberStatusConfiguration()).SeedMemberStatus();
            modelBuilder.ApplyConfiguration(new MemberTeamConfiguration()).SeedMemberTeam();
            modelBuilder.ApplyConfiguration(new MembershipGradeConfiguration()).SeedMembershipGrade();
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration()).SeedOrganization();
            modelBuilder.ApplyConfiguration(new OrganizationStructureConfiguration()).SeedOrganizationStructure();
            modelBuilder.ApplyConfiguration(new PageConfiguration()).SeedPage();
            modelBuilder.ApplyConfiguration(new PaymentCardConfiguration()).SeedPaymentCard();
            modelBuilder.ApplyConfiguration(new PaymentGatewayConfiguration()).SeedPaymentGateway();
            modelBuilder.ApplyConfiguration(new PaymentSettingConfiguration()).SeedPaymentSetting();
            modelBuilder.ApplyConfiguration(new PaymentSettingAllowedCardConfiguration()).SeedPaymentSettingAllowedCard();
            modelBuilder.ApplyConfiguration(new PayPalConnectionModeConfiguration()).SeedPayPalConnectionMode();
            modelBuilder.ApplyConfiguration(new PayPalPreferredPaymentGatewayConfiguration()).SeedPayPalPreferredPaymentGateway();
            modelBuilder.ApplyConfiguration(new PermissionConfiguration()).SeedPermission();
            modelBuilder.ApplyConfiguration(new PlanCanChangeToXrefConfiguration()).SeedPlanCanChangeToXref();
            modelBuilder.ApplyConfiguration(new PlanDetailConfiguration()).SeedPlanDetail();
            modelBuilder.ApplyConfiguration(new PlanFrequencyConfiguration()).SeedPlanFrequency();
            modelBuilder.ApplyConfiguration(new PlanMasterConfiguration()).SeedPlanMaster();
            modelBuilder.ApplyConfiguration(new PromotionDetailConfiguration()).SeedPromotionDetail();
            modelBuilder.ApplyConfiguration(new PromotionMasterConfiguration()).SeedPromotionMaster();
            modelBuilder.ApplyConfiguration(new PromotionResponseConfiguration()).SeedPromotionResponse();
            modelBuilder.ApplyConfiguration(new PromotionResponseTypeConfiguration()).SeedPromotionResponseType();
            modelBuilder.ApplyConfiguration(new ReferralTypeConfiguration()).SeedReferralType();
            modelBuilder.ApplyConfiguration(new RefundConfiguration()).SeedRefund();
            modelBuilder.ApplyConfiguration(new RelatedToConfiguration()).SeedRelatedTo();
            modelBuilder.ApplyConfiguration(new RoleConfiguration()).SeedRole();
            modelBuilder.ApplyConfiguration(new RolePermissionXrefConfiguration()).SeedRolePermissionXref();
            modelBuilder.ApplyConfiguration(new StateConfiguration()).SeedState();
            modelBuilder.ApplyConfiguration(new TagConfiguration()).SeedTag();
            modelBuilder.ApplyConfiguration(new TaxConfiguration()).SeedTax();
            modelBuilder.ApplyConfiguration(new TaxPolicyConfiguration()).SeedTaxPolicy();
            modelBuilder.ApplyConfiguration(new TaxScopeConfiguration()).SeedTaxScope();
            modelBuilder.ApplyConfiguration(new ThemeConfiguration()).SeedTheme();
            modelBuilder.ApplyConfiguration(new TimeFormatConfiguration()).SeedTimeFormat();
            modelBuilder.ApplyConfiguration(new TimeZoneConfiguration()).SeedTimeZone();
            modelBuilder.ApplyConfiguration(new TitleConfiguration()).SeedTitle();
            modelBuilder.ApplyConfiguration(new UserActivityConfiguration()).SeedUserActivity();
            modelBuilder.ApplyConfiguration(new MemberActivityConfiguration()).SeedMemberActivity();
            modelBuilder.ApplyConfiguration(new UserRoleXrefConfiguration()).SeedUserRoleXref();
            modelBuilder.ApplyConfiguration(new MemberQualificationXrefConfiguration()).SeedMemberQualificationXref();
            modelBuilder.ApplyConfiguration(new MemberFileConfiguration()).SeedMemberFileXref();
            modelBuilder.ApplyConfiguration(new MemberRefereeConfiguration()).SeedMemberRefereeXref();
            modelBuilder.ApplyConfiguration(new MemberNotesConfiguration()).SeedMemberNotesXRef();
            modelBuilder.ApplyConfiguration(new MemberEmailConfiguration()).SeedMemberEmailXref();
            modelBuilder.ApplyConfiguration(new QualificationConfiguration()).SeedQualification();
            modelBuilder.ApplyConfiguration(new LanguageConfiguration()).SeedLanguage();
            modelBuilder.ApplyConfiguration(new EthnicityConfiguration()).SeedEthnicity();
            modelBuilder.ApplyConfiguration(new OccupationConfiguration()).SeedOccupation();
            modelBuilder.ApplyConfiguration(new PreferredContactTimeConfiguration()).SeedPreferredContactTime();
            modelBuilder.ApplyConfiguration(new DWSClassConfiguration()).SeedDWSClass();
            modelBuilder.ApplyConfiguration(new DWSClassMemberXrefConfiguration()).SeedDWSClassMemberXref();
            modelBuilder.ApplyConfiguration(new DivisionConfiguration()).SeedDivision();
            modelBuilder.ApplyConfiguration(new DivisionMemberXrefConfiguration()).SeedDivisionMemberXref();
            modelBuilder.ApplyConfiguration(new InvolvementConfiguration()).SeedInvolvement();
            modelBuilder.ApplyConfiguration(new InvolvementMemberXrefConfiguration()).SeedInvolvementMemberXref();
            modelBuilder.ApplyConfiguration(new DisabilityConfiguration()).SeedDisability();
            modelBuilder.ApplyConfiguration(new DisabilityLevelConfiguration()).SeedDisabilityLevel();
            modelBuilder.ApplyConfiguration(new DisabilityMemberXrefConfiguration()).SeedDisabilityMemberXref();
            modelBuilder.ApplyConfiguration(new VolunteerHoursConfiguration()).SeedVolunteerHours();
            modelBuilder.ApplyConfiguration(new EmploymentCategoryConfiguration()).SeedEmploymentCategory();
            modelBuilder.ApplyConfiguration(new EmploymentMemberXrefConfiguration()).SeedEmploymentMemberXref();
            modelBuilder.ApplyConfiguration(new QualificationCategoryConfiguration()).SeedQualificationCategory();
            modelBuilder.ApplyConfiguration(new QualificationTypeConfiguration()).SeedQualificationType();
            modelBuilder.ApplyConfiguration(new QualificationEnrolmentCategoryConfiguration()).SeedQualificationEnrolmentCategory();
            modelBuilder.ApplyConfiguration(new ClientBranchConfiguration()).SeedClientBranch();
            modelBuilder.ApplyConfiguration(new MemberShipChangeReasonConfiguration()).SeedMemberShipChangeReason();
            modelBuilder.ApplyConfiguration(new IndividualMemberShipHistoryConfiguration()).SeedIndividualMemberShipHistory();
            modelBuilder.ApplyConfiguration(new OrganizationMemberShipHistoryConfiguration()).SeedOrganizationMemberShipHistory();

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["ClientDBContext"]);
                base.OnConfiguring(optionsBuilder);
            }
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
