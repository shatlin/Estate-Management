using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace MDM.Helper
{

    public class YesNoLookup
    {
        public bool Id { get; set; }
        public string Name { get; set; }

        public List<YesNoLookup> YesNoList()
        {
            var YesNoLookupList = new List<YesNoLookup>();
            YesNoLookupList.Add(new YesNoLookup { Id = true, Name = "Yes" });
            YesNoLookupList.Add(new YesNoLookup { Id = false, Name = "No" });
            return YesNoLookupList;
        }
    }


    public static class HelperMethods
    {


        public static string GetUserId(this IPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return null;
            return claim.Value;
        }

        public static string GetEmail(this IPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            if (claim == null) return null;
            return claim.Value;
        }



        public static string GeneratePassword(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "@$#*!abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (System.Security.Cryptography.RNGCryptoServiceProvider crypto = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }

            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();

        }

        public static string GetDateStamp()
        {
            DateTime today = DateTime.Now;
            return today.Year + "_" + today.Month + "_" + today.Day + " " + today.Hour + "_" + today.Minute + "_" + today.Second;
        }

        public static string GetFormattedDate(this DateTime? date)
        {
            if (date == null) return string.Empty;
            StringBuilder dateBuilder = new StringBuilder();

            if (date.Value.Month < 10)
            {
                dateBuilder.Append("0");
            }
            dateBuilder.Append(date.Value.Month + "/");


            if (date.Value.Day < 10)
            {
                dateBuilder.Append("0");
            }
            dateBuilder.Append(date.Value.Day + "/" + date.Value.Year);



            return dateBuilder.ToString();
        }


    }
}
