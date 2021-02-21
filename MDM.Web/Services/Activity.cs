using MDM.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MDM.Services
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


}
