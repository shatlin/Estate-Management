using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MM.ClientModels;
using System;
using System.Threading.Tasks;

namespace WISA.Services
{

    public interface IActivity
    {
        Task<bool> AddAsync(string userId, string email, string activitydetail, int UserOrMember);
    }


    public class Activity : IActivity
    {


        #region Constructor

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClientDbContext _context;
        private readonly ILogger<Activity> _logger;

        public Activity(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<Activity> logger,
            ClientDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        #endregion

        public async Task<bool> AddAsync(string userId, string email, string activitydetail, int UserOrMember)
        {
            string fullname=string.Empty;
            try
            {
                if (userId == null || email == null || activitydetail == null) return false;
                if (UserOrMember != 1 && UserOrMember != 2) return false;
                var user = _userManager.FindByEmailAsync(email).Result;
                if(user != null) 
                    fullname= user.FullName;
                if (UserOrMember == 1)
                {
                  
                    await _context.UserActivity.AddAsync(new UserActivity { UserId = userId, Email = email, FullName= fullname, ActivityDate = DateTime.Now, ActivityDetail = activitydetail });
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    await _context.MemberActivity.AddAsync(new MemberActivity { UserId = userId, Email = email, FullName = fullname, ActivityDate = DateTime.Now, ActivityDetail = activitydetail });
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occurred During logging activity "
                    + "User Id =" + userId + ", Email =" + email + ", Activity =" + activitydetail +
                    "User Or Member =" + UserOrMember + "Exception =" + ex.Message + " " + ex.InnerException);
            }
            return false;
        }
    }


    public static class EmailRecipients
    {
        public static string GetEmailSenderList(string template, string membershiptype, string toEmail,int? releatedToId=null,int? relatedToEntityId=null)
        {
            string tolist = string.Empty;

            if (template == "NewMember" && membershiptype == "ind")
            {
                tolist = "wisa@wisa.org.za|membership@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;//Evelyn
            }
            else if (template == "NewMember" && membershiptype == "pro")
            {
                tolist = "support@wisa.org.za|membership@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;//Talent
            }
            else if (template == "NewMember" && membershiptype == "student")
            {
                tolist = "support@wisa.org.za|membership@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;//Talent
            }
            else if (template == "NewNonIndividual" && membershiptype == "NonIndividual")
            {
                tolist = "wisa@wisa.org.za|wisa@wisa.org.za;membership@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;//Evelyn
            }
            else if (template == "ConfirmEmail")
            {
                tolist = toEmail+"||"+releatedToId+"|"+relatedToEntityId;
            }
            else if (template == "FirstReminder")
            {
                tolist = toEmail + "|wisa@wisa.org.za;membership@wisa.org.za;support@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;
            }
            else if (template == "SecondReminder")
            {
                tolist = toEmail + "|wisa@wisa.org.za;membership@wisa.org.za;support@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;
            }
            else if (template == "ThirdReminder")
            {
                tolist = toEmail + "|wisa@wisa.org.za;membership@wisa.org.za;support@wisa.org.za|"+releatedToId+"|"+relatedToEntityId;
            }

           
            return tolist;

        }

    }

    public class Notification
    {
        public string message { get; set; }
        public string notificationtype { get; set; }
    }

    public class SystemRole
    {
        public bool IsSelected { get; set; }
        public string id { get; set; }
        public string Name { get; set; }
    }

    public class SystemClaim
    {
        public bool IsSelected { get; set; }
        public string Type { get; set; }
        public string value { get; set; }
    }

    public static class GlobalVariables
    {
        public const string ExcelFileContenttType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    }

    public static class MMMessages
    {
        public const string Error_Please_check_values_entered = "Error. Please check values entered";
        public const string Error_Subject_note_Missing = "Error. Subject and Body are mandatory for notes";
        public const string Authorization_failed = "Authorization failed.";
        public const string SavedSuccessfully = "Saved successfully";
        public const string NoRecordToDelete = "No such record found to delete";
        public const string DeletedSuccessfully = "Deleted successfully";
        public const string ClientUserAccess = "Client User";

        #region activities
        public const string LoggedIn = "Logged In";
        public const string LoggedOut = "Logged Out";
        public const string Accessed = "Accessed Page ";
        public const string Added = "Added ";
        public const string Updated = "Updated ";
        public const string Deleted = "Deleted ";
        public const string AccessedViewMember = "Accessed Manage Member Page";
        public const string UpdatedMemberUser = "Updated Member User";
        public const string UploadedFile = "Uploaded New Files";
        #endregion
    }

    public enum AddressTypeEnum
    {
        Postal = 1,
        Physical = 2,
        Billing = 3,
        Business = 4

    }


    public static class UserTypeValues
    {
        public const int Staff = 1;
        public const int Member = 2;
        public const int Contact = 3;

    }

    public static class NotificationTypeValues
    {
        public const string success = "success";
        public const string warning = "warning";
        public const string danger = "danger";
        public const string info = "info";
    }

    public enum RelatedToEnum
    {
        Member = 1,
        Organization = 2,
        Event = 3,
        CPD = 4,
        Contact = 5,
        Staff = 6,
        Note=7

    }

    public enum FileTypesEnum
    {
        IDDocs = 1,
        Certificates = 2,
        DWSReg = 3,
        StudentReg = 4,
        Payment = 5,
        Note = 6,
        StudentLetter=7
    }


    public enum MembershipTypeEnum
    {
        IndividualMember = 1,
        ProfessionalProcessController = 2,
        NonIndividualMember = 3,
        NonMembers = 4,
        PrimaryContact = 5,
        BillingContact = 6,
        ContactPerson = 7,
        AdditionalContacts = 8
    }

    public static class MMRoles
    {
        public const string SuperUserRole = "Super User Access";
        public const string AdminFullAccessRole = "Admin Full Access";
        public const string AdminReadAccessRole = "Admin Read Access";
        public const string LimitedAdminAccessRole = "Limited Admin Access";
        public const string NoAdminRole = "No Admin Access";
        public const string ClientUserRole = "Client User";
        public const string MemberRole = "Member User";
        public const string ContactRole = "Contact User";
    }

    public static class MMPolicies
    {
        public const string AllowSuperUser = "SuperUser";
        public const string AllowAdminUser = "AdminUser";
        public const string AllowSetUp = "SetUp";
        public const string AllowSetupDelete = "AllowSetupDelete";
        public const string AllowSetupUpdate = "AllowSetupUpdate";
        public const string AllowMemberAccess = "MemberAccess";
        public const string AllowContactAccess = "ContactAccess";
        public const string AllowUserAccess = "UserAccess";
        public const string AllowToViewReports = "AllowToViewReports";

    }

    public static class MMClaimTypes
    {
        public static readonly string SuperUser = "SuperUser";
        public const string AdminUser = "AdminUser";
        public const string ClientUser = "ClientUser";
        public const string MemberUser = "MemberShip";
        public const string ContactUser = "ContactUser";
        public const string Event = "Event";
        public const string Membership = "Membership";
        public const string Training = "Training";
        public const string Finance = "Finance";
        public const string NewsLetter = "NewsLetter";
        public const string SetUp = "Setup";
        public const string Donations = "Donations";
        public const string Report = "Report";
    }

    public static class MMClaimValues
    {
        public const string Access = "Access";
        public const string Create = "Create";
        public const string Read = "Read";
        public const string Update = "Update";
        public const string Delete = "Delete";
    }
}
