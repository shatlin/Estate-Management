using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MM.Web.Validation
{

    public class EnforceTrueAttribute : ValidationAttribute
    {
        public EnforceTrueAttribute()
            : base("The {0} field must be true.") { }

        public override bool IsValid(object value) =>
            value is bool valueAsBool && valueAsBool;
    }
}
