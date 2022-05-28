using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace RSB_Ofish_System.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="درج {0} ضروری میباشد")]
        public string UserName { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "درج {0} ضروری میباشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        

    }


    public class ResetPassword
    {
        [Display(Name = "رمز عبور فعلی")]
        [Required(ErrorMessage = "درج {0} ضروری میباشد")]
        [DataType(DataType.Password)]   
        public string OldPassword { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "درج {0} ضروری میباشد")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=(.*[0-9]))(?=.*[\!@#$%^&*()\\[\]{}\-_+=~`|:;'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}",
            ErrorMessage = "{0} باید حداقل 8 کاراکتر و دارای عدد حروف کوچک و بزرگ و کاراکتر های مخصوص باشد")]
        public string Password { get; set; }


        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "درج {0} ضروری میباشد")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="مقادیر {1} و {0} میبایست یکسان باشند")]
        public string RePassword { get; set; }



    }
}
