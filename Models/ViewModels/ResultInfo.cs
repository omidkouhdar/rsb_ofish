using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSB_Ofish_System.Models.ViewModels
{
    public class ResultInfo
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public bool IsSuccess { get; set; }
        public string Status { get; set; }

    }

    public enum OprationStatus
    {
        success = 1 , 
        warning = 2 ,
        error = 3

    }
}
