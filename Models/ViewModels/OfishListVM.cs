using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CommonTools;
namespace RSB_Ofish_System.Models.ViewModels
{
    public class OfishListVM
    {
        public long Id { get; set; }
        [Display(Name ="اداره /واحد")]
        public string Office { get; set; }
        [Display(Name = "ملاقات شونده")]
        public string Staff { get; set; }
        public DateTime OfishDateTime { get; set; }
        [Display(Name = "تاریخ ملاقات")]
        public string OfishDate
        {
            get
            {

                return this.OfishDateTime.ToshamsiDate();
            }
        }
        [Display(Name = " ملاقات کننده")]
        public string FullName { get; set; }
        [Display(Name = "کد ملی")]
        public string NationCode { get; set; }
        public string User { get; set; }
        public string Pic { get; set; }

    }

    public class ListResultVM<T>
    {
        public IEnumerable<T> DataList { get; set; }
        public string ListTitle { get; set; }
        public int TotalRows { get; set; }
        public int PageCount { get; set; }
        

    }
}
