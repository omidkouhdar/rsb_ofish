using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RSB_Ofish_System.Models.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="درج {0} ضروری می باشد")]
        public string UserName { get; set; }
        //**************************************************
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
       
        [RegularExpression(@"(?=(.*[0-9]))(?=.*[\!@#$%^&*()\\[\]{}\-_+=~`|:;'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}",
            ErrorMessage ="{0} باید حداقل 8 کاراکتر و دارای عدد حروف کوچک و بزرگ و کاراکتر های مخصوص باشد")]
        public string PassWord { get; set; }
        //***************************************************
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        [Compare("PassWord", ErrorMessage ="مقادیر {0} و {1} میبایست یکسان باشند")]
        public string  Repass { get; set; }


        //*******************************

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        public string FullName { get; set; }

    }
}
