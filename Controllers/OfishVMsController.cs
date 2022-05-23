using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSB_Ofish_System.Data;
using RSB_Ofish_System.Models.DataBaseModels;
using RSB_Ofish_System.Models.ViewModels;
using RSB_Ofish_System.Repository.Ofish.Interfaces;

namespace RSB_Ofish_System.Controllers
{
    [Authorize(Roles = "Guard")]
    public class OfishController : Controller
    {
        

        private readonly RSB_Ofish_SystemContext _context;
        private readonly IOfishService _ofishService;
        public OfishController(RSB_Ofish_SystemContext context, IOfishService ofishService )
        {
            _context = context;
            _ofishService = ofishService;
          
        }

        // GET: OfishVMs
        public async Task<IActionResult> Index()
        {
            var model = await _ofishService.GetTodayOfishLists();
            return View(model);
        }

        // GET: OfishVMs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofishVM = await _context.Ofish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ofishVM == null)
            {
                return NotFound();
            }

            return View(ofishVM);
        }

        // GET: OfishVMs/Create
        public IActionResult Create()
        {

            ViewBag.office = _context.Office.ToList();
            return View();
        }

        // POST: OfishVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalCode,FullName,OfficeId,Staff,Description")] OfishVM ofishVM, string img)
        {
            var userId = CommonTools.Tools.GetUserId(User);
            ModelState.ClearValidationState(nameof(ofishVM));
            if (TryValidateModel(ofishVM, nameof(ofishVM)))
            {
                ofishVM.UserId = userId;
                var result = await _ofishService.addOfish(ofishVM, img);
                return Json(result);
            }
            ViewBag.office = _context.Office.ToList();
            return View(ofishVM);
        }

        // GET: OfishVMs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofishVM = await _context.Ofish.FindAsync(id);
            if (ofishVM == null)
            {
                return NotFound();
            }

            return View(ofishVM);
        }

        // POST: OfishVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NationalCode,FullName,OfficeId,Staff,Description")] OfishVM ofishVM)
        {
            if (id != ofishVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofishVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfishVMExists(ofishVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ofishVM);
        }

        // GET: OfishVMs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofishVM = await _context.Ofish
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ofishVM == null)
            {
                return NotFound();
            }

            return View(ofishVM);
        }

        // POST: OfishVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ofishVM = await _context.Ofish.FindAsync(id);
            _context.Ofish.Remove(ofishVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfishVMExists(long id)
        {
            return _context.Ofish.Any(e => e.Id == id);
        }
    }
}
