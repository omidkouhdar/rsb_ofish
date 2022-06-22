using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace RSB_Ofish_System.Models.ViewModels
{
    public class PlateVM
    {
        
        [MaxLength(3)]
        public string Alphabet { get; set; } 
        [MaxLength(2)]
        public byte TowDigit { get; set; }
        
        [MaxLength(3)]
        public byte ThreeDigit { get; set; }
        [MaxLength(2)]
        
        public byte StataDigit { get; set; }

    }
}
