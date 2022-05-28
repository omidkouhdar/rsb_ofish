using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSB_Ofish_System.Repository.Users.Interface;
using RSB_Ofish_System.Data;
using RSB_Ofish_System.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
namespace RSB_Ofish_System.Repository.Users.Service

{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public void Dispose()
        {
            this._userManager.Dispose();
        }

        public async Task<ResultInfo> login(LoginVM model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return new ResultInfo
                    {
                        IsSuccess = true,
                        Message = "ورود با موفقیت انجام شد",
                        Status = nameof(Models.ViewModels.OprationStatus.success),
                        Title = "خوش آمدید"
                    };
                }
                else
                {
                    return new ResultInfo
                    {
                        IsSuccess = false,
                        Message = "نام کاربری یا رمز عبور نادرست است",
                        Status = nameof(Models.ViewModels.OprationStatus.error),
                        Title = "نا موفق"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResultInfo
                {
                    IsSuccess = false,
                    Message = $"{ex.Message}",
                    Status = nameof(Models.ViewModels.OprationStatus.error),
                    Title = "نا موفق"
                };
            }

        }

        public async Task<ResultInfo> registerUser(RegisterVM model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = string.Empty,
                PhoneNumber = "02188109530"
            };
            var result = await _userManager.CreateAsync(user, model.PassWord);
            if (result.Succeeded)
            {

                await _userManager.AddClaimAsync(user, new Claim("fullname", model.FullName));

                var roleResult = await CreateRoleForUsers("Guard", user);

                return new ResultInfo
                {

                    IsSuccess = true,
                    Message = "ثبت اطلاعات کاربر انجام شد",
                    Status = nameof(Models.ViewModels.OprationStatus.success),
                    Title = "موفق"
                };
            }
            else
            {
                return new ResultInfo
                {
                    IsSuccess = false,
                    Message = "خطا در هنگام عملیات",
                    Status = nameof(Models.ViewModels.OprationStatus.error),
                    Title = "نا موفق"

                };
            }
        }

        public async Task<ResultInfo> resetPassword(ResetPassword model, string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            var isPassTrue = await _signInManager.CheckPasswordSignInAsync(user, model.OldPassword, false);
            if(!isPassTrue.Succeeded)

            {
                return new ResultInfo
                {
                    IsSuccess = false,
                    Message = "رمز عبور فعلی نادرست میباشد",
                    Status = nameof(Models.ViewModels.OprationStatus.error),
                    Title = "نا موفق"
                };
            }
            var tokenResetPassword = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, tokenResetPassword, model.Password);
            if (result.Succeeded)
                return new ResultInfo
                {

                    IsSuccess = true,
                    Message = "تغییر رمز  با موفقیت انجام شد",
                    Status = nameof(Models.ViewModels.OprationStatus.success),
                    Title = "موفق"

                };
            return new ResultInfo
            {
                IsSuccess = false,
                Message = "عدم تغییر رمز عبور",
                Status = nameof(Models.ViewModels.OprationStatus.error),
                Title = "نا موفق"
            };

        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }


        private async Task<bool> CreateRoleForUsers(string rolName, IdentityUser user)
        {
            try
            {
                bool isExistThisRole = await _roleManager.RoleExistsAsync(rolName);
                if (!isExistThisRole)
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = rolName });
                }
                await _userManager.AddToRoleAsync(user, rolName);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
