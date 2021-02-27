using MDM.Helper;
using MDM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MDM.Services
{

    public interface IEmailRecipients
    {
         string GetEmailSenderList(string template, string type, string toEmail, int? releatedToId = null, int? relatedToEntityId = null);
    }

    public class EmailRecipients : IEmailRecipients
    {
        protected DB _db;
        protected IMemoryCache _cache;
        protected UserManager<ApplicationUser> _userManager;
        public EmailRecipients(DB db, IMemoryCache cache, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _cache = cache;
            _userManager = userManager;

        }
        public string GetEmailSenderList(string template, string type, string toEmail, int? releatedToId = null, int? relatedToEntityId = null)
        {
            string tolist = string.Empty;


            if (template == "NewTicket")
            {
                tolist = _cache.GetOrCreate(Lookups.trustees, c => {

                    var trustees = _db.Board.Include(x => x.SystemUser).Where(x => x.isCurrent == true).ToList();

                    foreach (var trustee in trustees)
                    {
                        var email = _userManager.FindByIdAsync(trustee.SystemUser.ApplicationUserId).Result.Email;
                        tolist += email + ";";
                    }
                    tolist += "||" + releatedToId + "|" + relatedToEntityId;

                    return tolist;
                });

            }
            return tolist;

        }

    }



}
