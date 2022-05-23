using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RSB_Ofish_System.Models.ViewModels;
using RSB_Ofish_System.Repository.Users.Interface;

namespace RSB_Ofish_System.Controllers
{
   
    public class AuthController : Controller
    {
      
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        //[AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.login(model);
                if (result.IsSuccess)
                {
                    // return Redirect(string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _userService.SignOut();
            return RedirectToAction(nameof(AuthController.Login));
        }

        [Authorize(Roles ="Manager")]
        public IActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {


                return RedirectToAction(nameof(Register));
            }

            var result = await _userService.registerUser(register);
            return Json(result);

        }

    }
}