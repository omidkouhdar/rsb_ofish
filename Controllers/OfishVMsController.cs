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
using RSB_Ofish_System.Repository.Office.Interface;
using RSB_Ofish_System.Repository.Ofish.Interfaces;

namespace RSB_Ofish_System.Controllers
{
    [Authorize(Roles = "Guard")]
    public class OfishController : Controller
    {


        private readonly IOfficeService _officeService;
        private readonly IOfishService _ofishService;
        public OfishController(IOfficeService officeService, IOfishService ofishService )
        {
            _officeService = officeService;
            _ofishService = ofishService;
          
        }
        public async Task<IActionResult> showCard(int Id)
        {
            var result = await _ofishService.getCard(Id);
            return PartialView("_cardView", result);
        }
        public async Task<IActionResult> Exit(long Id)
        {
            var userId = CommonTools.Tools.GetUserId(User);
            var result = await _ofishService.Exit(Id, userId);
            return Json(result);
        }
        // GET: OfishVMs
        public async Task<IActionResult> Index()
        {
            var model = await _ofishService.GetTodayOfishLists();
            return View(model);
        }
        public async Task<IActionResult> Search()
        {

            ViewBag.Office = await _officeService.GetList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(SearchVM model , int pageId = 1)
        {
            bool FormIsEmpty = string.IsNullOrEmpty(string.Concat(model.From, model.FullName, model.NationCode, model.Staff, model.To))
               && model.OfficId == 0;
            if (FormIsEmpty)
            {
                ModelState.AddModelError(string.Empty, "یکی از مقادیر فرم میبایشت مقدار دهی شود ");
            }

            if (ModelState.IsValid)
            {
                var result = await _ofishService.Search(model, pageId);
                ViewData["currenPage"] = pageId;
                return PartialView("_ofishDataView", result);
                
            }
            //ViewBag.Office = await _officeService.GetList();
            return Json("");

        }

        // GET: OfishVMs/Create
        public async Task< IActionResult> Create()
        {

            ViewBag.office = await _officeService.GetList();
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
            ViewBag.office = await _officeService.GetList();
            return View(ofishVM);
        }

  
    }
}
