using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RSB_Ofish_System.Models.ViewModels;

namespace RSB_Ofish_System.Utils.Validators
{
    public class NationCode : ValidationAttribute
    {
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            OfishVM model = (OfishVM)validationContext.ObjectInstance;
            bool result = CommonTools.Tools.isCorrectNationCode(model.NationalCode);
            if (result)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(this.ErrorMessage, new string[] { "NationalCode" });
        }
    }
}
