using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MDM.Helper
{
    public class TrackUserAttribute : ResultFilterAttribute
    {
        private string _description;

        public TrackUserAttribute(string description)
        {
            _description = description;
        }

        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Debug.WriteLine($"===User : {context.HttpContext.User.Identity.Name}, description : {_description}, Date {DateTime.Now.ToString()}");
            return base.OnResultExecutionAsync(context, next);
        }
    }

}
