using Microsoft.EntityFrameworkCore;
using RSB_Ofish_System.Data;
using RSB_Ofish_System.Models.ViewModels;
using RSB_Ofish_System.Repository.Office.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSB_Ofish_System.Repository.Office.Service
{
    public class OfficeService : IOfficeService
    {
        private readonly RSB_Ofish_SystemContext _context;
        public OfficeService(RSB_Ofish_SystemContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<SelectListItemVM>> GetList()
        {
            var list = new List<SelectListItemVM> { new SelectListItemVM
            {
                Id = "0" , Name = "انتخاب کنید"
            }
            };
            var model = await _context.Office.Select(s => new SelectListItemVM { Id = s.Id.ToString(), Name = s.Name }).ToListAsync();
            foreach(var item in model)
            {
                list.Add(new SelectListItemVM
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return list;
        }
    }
}
