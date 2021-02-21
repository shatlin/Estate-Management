using Microsoft.Extensions.Logging;
using MDM.Models;
using System;
using System.Threading.Tasks;

namespace MDM.Helper
{

    public interface IActivity
    {
        Task<bool> AddAsync(string userId, string email, string activitydetail, int UserOrMember);
    }


    public class Activity : IActivity
    {



        private readonly DB _db;
        private readonly ILogger<Activity> _logger;

        public Activity(
            ILogger<Activity> logger,
            DB db)
        {

            _logger = logger;
            _db = db;
        }

        public async Task<bool> AddAsync(string userId, string email, string activitydetail, int UserOrMember)
        {
            try
            {
                if (userId == null || email == null || activitydetail == null) return false;
                if (UserOrMember != 1 && UserOrMember != 2) return false;

                if (UserOrMember == 1)
                {
                    await _db.UserActivity.AddAsync(new UserActivity { UserId = userId, Email = email, ActivityDate = DateTime.Now, ActivityDetail = activitydetail });
                    await _db.SaveChangesAsync();
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
        public static string GetEmailSenderList(string template, string membershiptype, string toEmail, int? releatedToId = null, int? relatedToEntityId = null)
        {
            string tolist = string.Empty;

            //if (template == "NewMember" && membershiptype == "ind")
            //{
            //    tolist = "mdm@MDM.org.za|mdm@MDM.org.za;membership@MDM.org.za|"+releatedToId+"|"+relatedToEntityId;
            //}


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
        public const string AppName = "Mile Downe Manor";
        public const string AppShortName = "MDM";
        public static int Year
        {
            get
            {
                return DateTime.Now.Year;
            }
        }
        public static int Month
        {
            get
            {
                return DateTime.Now.Month;
            }
        }
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
        Note = 7

    }

    public enum FileTypesEnum
    {
        IDDocs = 1,
        Certificates = 2,
        DWSReg = 3,
        StudentReg = 4,
        Payment = 5,
        Note = 6,
        StudentLetter = 7
    }




    public static class MDMRoles
    {
        public const string SuperUser = "Super User";
        public const string Admin = "Admin";
        public const string Owner = "Owner";
        public const string Tenant = "Owner";

    }

    public static class MDMPolicies
    {
        public const string AllowSuperUser = "SuperUser";
        public const string AllowAdminUser = "AdminUser";
        public const string AllowSetUp = "SetUp";
        public const string AllowSetupDelete = "AllowSetupDelete";
        public const string AllowSetupUpdate = "AllowSetupUpdate";
        public const string AllowRegularUserAccess = "RegularUserAccess";
        public const string AllowToViewReports = "AllowToViewReports";

    }

    public static class MDMClaimTypes
    {
        public static readonly string SuperUser = "SuperUser";
        public const string AdminUser = "AdminUser";
        public const string RegularUser = "RegularUser";
        public const string Event = "Event";
        public const string Finance = "Finance";
        public const string NewsLetter = "NewsLetter";
        public const string SetUp = "Setup";
        public const string Report = "Report";
    }

    public static class MDMClaimValues
    {
        public const string Access = "Access";
        public const string Create = "Create";
        public const string Read = "Read";
        public const string Update = "Update";
        public const string Delete = "Delete";
    }
}
