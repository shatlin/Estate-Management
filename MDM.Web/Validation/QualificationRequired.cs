using MM.ClientModels;
using MM.Pages.Apply;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MM.Web.Validation
{

    public class QualificationRequiredAttribute : ValidationAttribute
    {
        public QualificationRequiredAttribute()
            : base("Atlease one Qualification is Required") { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             List<qualificationvm> qvmlist = (List<qualificationvm>)validationContext.ObjectInstance;

            if (qvmlist != null && qvmlist.Count==0)
                return new ValidationResult("Atlease one Qualification is Required");
            else
                return ValidationResult.Success;
          
        }
    }
}
