using MDM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace MDM.Helper
{


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

    public static class Lookups
    {
        public const string priorities="priorties";
        public const string trustees = "trustees";
        public const string categories = "categories";
        public const string taskitemtypes = "taskitemtypes";
    }

    public static class PageNames
    {
        public const string HomePage = "Home";
        public const string TaskPage = "Task";

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
        public const string Updated = "Performed add or Update ";
        public const string Deleted = "Deleted ";
        public const string AccessedViewMember = "Accessed Manage Member Page";
        public const string UpdatedMemberUser = "Updated Member User";
        public const string UploadedFile = "Uploaded New Files";
        #endregion
    }

    public enum AuditType
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }

    public static class AddressTypevalues
    {
        public const int Postal = 1;
        public const int Physical = 2;
        public const int Billing = 3;
        public const int Business = 4;
    }


    public static class UserTypeValues
    {
        public const int Trustee = 1;
        public const int Owner = 2;
        public const int Tenant = 3;
        public const int ServiceProvider = 4;
    }

    public static class NotificationTypeValues
    {
        public const string success = "success";
        public const string warning = "warning";
        public const string danger = "danger";
        public const string info = "info";
    }

    public static class RelatedToValues
    {
        public const int Trustee = 1;
        public const int Owner = 2;
        public const int Tenant = 3;
        public const int EstateManager = 4;
        public const int ManagingAgent = 5;
        public const int GardenVendor = 6;
        public const int SecurityVendor = 7;
        public const int ServiceProvider = 8;
    }

    public static class StatusValues
    {
        public const int Open = 1;
        public const int Pending = 2;
        public const int InProgress = 3;
        public const int Completed = 4;
        public const int InReview = 5;
        public const int Accepted = 6;
        public const int Rejected = 7;
        public const int Blocked = 8;
        public const int Closed = 9;


    }

    public static class FileTypevalues
    {
        public const int SLA = 1;
        public const int Quote = 2;
        public const int OwnerDocs = 3;
        public const int Finance = 4;
        public const int Invoice = 5;
        public const int Bill = 6;
        public const int Ticket=7;
    }

    public static class MDMRoles
    {
        public const string SuperUser = "SuperUser";
        public const string Admin = "Admin";
        public const string Trustee = "Trustee";
        public const string Owner = "Owner";
        public const string Tenant = "Tenant";
        public const string EstateManager = "EstateManager";
        public const string GardenVendor = "GardenVendor";
        public const string SecurityVendor = "SecurityVendor";
        public const string ManagingAgent = "ManagingAgent";
        public const string ServiceProvider = "ServiceProvider";
    }

    public static class MDMPolicies
    {
        public const string AllowSuperUser = "AllowSuperUser";
        public const string AllowAdmin = "AllowAdmin";
        public const string AllowTrustee = "AllowTrustee";
        public const string AllowOwner = "AllowOwner";
        public const string AllowTenant = "AllowTenant";
        public const string AllowEstateManager = "AllowEstateManager";
        public const string AllowGardenVendor = "AllowGardenVendor";
        public const string AllowSecurityVendor = "AllowSecurityVendor";
        public const string AllowManagingAgent = "AllowManagingAgent";
        public const string AllowServiceProvider = "AllowServiceProvider";
    }

    public static class MDMClaimTypes
    {
        public const string SuperUser = "SuperUser";
        public const string Admin = "Admin";
        public const string Trustee = "Trustee";
        public const string Owner = "Owner";
        public const string Tenant = "Tenant";
        public const string EstateManager = "EstateManager";
        public const string GardenVendor = "GardenVendor";
        public const string SecurityVendor = "SecurityVendor";
        public const string ManagingAgent = "ManagingAgent";
        public const string ServiceProvider = "ServiceProvider";
    }

    public static class MDMClaimValues
    {
        public const string Access = "Access";
    }
}


