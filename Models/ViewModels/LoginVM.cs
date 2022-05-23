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
}
