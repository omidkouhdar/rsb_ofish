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
        public OfishController(IOfficeService officeService, IOfishService ofishService)
        {
            _officeService = officeService;
            _ofishService = ofishService;

        }
        public async Task<IActionResult> showCard(int Id)
        {
            var result = await _ofishService.getCard(Id);
            return PartialView("_cardView", result);
        }
        public async Task<IActionResult> showVehicle(int Id)
        {
            var result = await _ofishService.ShowVehiclePic(Id);
            return PartialView("_vehicleView", result);
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
        public async Task<IActionResult> Search(SearchVM model, int pageId = 1)
        {
            bool FormIsEmpty = string.IsNullOrEmpty(string.Concat(model.From, model.FullName, model.NationCode, model.Staff, model.To))
               && model.OfficId == 0;
            if (FormIsEmpty)
            {
                ModelState.AddModelError(string.Empty, "یکی از مقادیر فرم میبایست مقدار دهی شود ");

            }
            if (CommonTools.Tools.isInValidDateTimeSpan(model.FromDate, model.ToDate))
            {
                ModelState.AddModelError(string.Empty, "تاریخ شروع از تاریخ پایان بزرگتر است");

            }

            if (ModelState.IsValid)
            {
                var result = await _ofishService.Search(model, pageId);
                ViewData["currenPage"] = pageId;
                return PartialView("_ofishDataView", result);

            }
            var Errors = new string[ModelState.ErrorCount];
            int c = 0;
            foreach (var modelstate in ModelState.Values)
            {
                foreach (var modelerror in modelstate.Errors)
                {
                    Errors[c] = modelerror.ErrorMessage;
                    c += 1;
                }
            }

            return PartialView("_ErrorView", Errors);


        }

        // GET: OfishVMs/Create
        public async Task<IActionResult> Create()
        {

            ViewBag.office = await _officeService.GetList();
            ViewBag.alphabet = getAlphabetic();
            return View();
        }

        // POST: OfishVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalCode,FullName,OfficeId,Staff,Description,Alphabet,StataDigit,ThreeDigit,TowDigit,HaveVihicle")] OfishVM ofish, string img)
        {
            var userId = CommonTools.Tools.GetUserId(User);

            if (ModelState.IsValid)
            {
                ofish.UserId = userId;
                var result = await _ofishService.addOfish(ofish, img);
                return Json(result);
            }
            ViewBag.alphabet = getAlphabetic();
            ViewBag.office = await _officeService.GetList();
            return View(ofish);
        }

        private string[] getAlphabetic()
        {
            var list = new string[]{ "الف", "ب" ,"پ" , "ت"  ,
                "ث", "ج", "چ", "ح",
                "خ", "د", "ذ", "ر",
                "ز", "ژ","س", "ش",
                "ص", "ض"  , "ط" , "ظ" ,
                "ع" , "غ" , "ف" , "ق" ,
                "ک" , "گ" , "ل" ,"م" ,
                "ن" , "و", "ه" , "ی"
            };
            return list;
        }

    }
}
