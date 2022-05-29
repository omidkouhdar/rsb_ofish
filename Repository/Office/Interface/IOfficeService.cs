using RSB_Ofish_System.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSB_Ofish_System.Repository.Office.Interface
{
    public interface IOfficeService : IDisposable
    {
        Task<List<SelectListItemVM>> GetList();
        
    }
}
