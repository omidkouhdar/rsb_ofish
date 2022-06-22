using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RSB_Ofish_System.Utils.Validators;
namespace RSB_Ofish_System.Models.ViewModels
{
    public class OfishVM
    {
        public long Id { get; set; }


        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        [MaxLength(10, ErrorMessage = "حداکثر طول {0} ، {1} کاراکتر میباشد")]
        //[NationCode(ErrorMessage ="کد ملی درج شده صحیح نمی باشد")]
        public string NationalCode { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        public string FullName { get; set; }


        [Display(Name = "اداره / واحد")]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        public int OfficeId { get; set; }

        [Display(Name = "ملاقات شونده")]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        public string Staff { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "درج {0} ضروری می باشد")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string UserId { get; set; }
        [Display(Name = "دارای وسیله نقلیه")]
        public bool HaveVihicle { get; set; }
        
        public string Alphabet { get; set; }
       
        [MaxLength(2)]
        public string TowDigit { get; set; }
        [MaxLength(3)]
        public string ThreeDigit { get; set; }
        [MaxLength(2)]
        public string StataDigit { get; set; }
    }
}
