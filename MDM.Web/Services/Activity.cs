using MDM.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MDM.Services
{

    public interface IActivity
    {
        Task<bool> AddAsync(string userId, string email, string activitydetail);
        bool Add(string userId, string email, string activitydetail);
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


        public bool Add(string userId, string email, string activitydetail)
        {
            try
            {
                if (userId == null || email == null || activitydetail == null) return false;



                 _db.UserActivity.Add(new UserActivity { UserId = userId, Email = email, ActivityDetail = activitydetail });
                 _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occurred During logging activity "
                    + "User Id =" + userId + ", Email =" + email + ", Activity =" + activitydetail +
                     "Exception =" + ex.Message + " " + ex.InnerException);
            }
            return false;
        }

        public async Task<bool> AddAsync(string userId, string email, string activitydetail)
        {
            try
            {
                if (userId == null || email == null || activitydetail == null) return false;
               

              
                    await _db.UserActivity.AddAsync(new UserActivity { UserId = userId, Email = email, ActivityDetail = activitydetail });
                    await _db.SaveChangesAsync();
                    return true;
              
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Occurred During logging activity "
                    + "User Id =" + userId + ", Email =" + email + ", Activity =" + activitydetail +
                     "Exception =" + ex.Message + " " + ex.InnerException);
            }
            return false;
        }
    }


}
