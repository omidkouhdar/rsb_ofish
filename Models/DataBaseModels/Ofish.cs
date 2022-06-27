using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSB_Ofish_System.Models.DataBaseModels
{
    public class Ofish
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string OnExitRegister { get; set; }
        //**********************************************
        public string FullName { get; set; }
        public string Staff { get; set; }
        public int OfficeId { get; set; }
        public string NationCode { get; set; }
        public string PicPath { get; set; }

        //**********************************************
        public DateTime OffishTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [MaxLength(14)]    
        public string ViheclePlate { get; set; }
        public string ViheclePic { get; set; }
        public virtual Office Office { get; set; }
    }
    public enum Sexual
    {
        Male = 1,
        Female = 2
    }
}
