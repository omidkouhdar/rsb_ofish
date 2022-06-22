using RSB_Ofish_System.Data;
using RSB_Ofish_System.Models.ViewModels;
using RSB_Ofish_System.Repository.Ofish.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommonTools;
namespace RSB_Ofish_System.Repository.Ofish.Services
{
    public class OfishService : IOfishService
    {
        private readonly RSB_Ofish_SystemContext _dataBase;
        public OfishService(RSB_Ofish_SystemContext dataBase)
        {
            _dataBase = dataBase;

        }

        public async Task<ResultInfo> addOfish(OfishVM ofish, string img)
        {
            string picPath = Tools.savePic(img);
            if (!Tools.isCorrectNationCode(ofish.NationalCode))
            {
                return new ResultInfo
                {
                    IsSuccess = false,
                    Message = "کد ملی درج شده صحیح نمی باشد",
                    Title = "عملیات ناموفق",
                    Status = nameof(OprationStatus.error)
                };
            }
            if (!string.IsNullOrEmpty(picPath))
            {
                _dataBase.Ofish.Add(new Models.DataBaseModels.Ofish
                {
                    Created = DateTime.Now,
                    FullName = ofish.FullName,
                    NationCode = ofish.NationalCode,
                    OfficeId = ofish.OfficeId,
                    OffishTime = DateTime.Now,
                    PicPath = picPath,
                    Staff = ofish.Staff,
                    UserId = ofish.UserId,
                    ViheclePlate = ofish.HaveVihicle? 
                    Tools.getPlate(ofish.TowDigit , ofish.Alphabet , 
                    ofish.ThreeDigit , ofish.StataDigit):string.Empty

                });
                try
                {
                    await _dataBase.SaveChangesAsync();
                    return new ResultInfo
                    {
                        IsSuccess = true,
                        Message = "اطلاعات ثبت شد",
                        Title = "عملیات موفق",
                        Status = nameof(OprationStatus.success)
                    };
                }
                catch
                {
                    return new ResultInfo
                    {
                        IsSuccess = false,
                        Message = "ایجاد مشکل در ثبت اطلاعات",
                        Title = "عملیات ناموفق",
                        Status = nameof(OprationStatus.error)
                    };
                }

            }
            return new ResultInfo
            {
                Title = "اسکن مدرک انجام نشد",
                Message = "عملیات نا موفق",
                IsSuccess = false,
                Status = nameof(OprationStatus.error)
            };
        }

        public void Dispose()
        {
            this._dataBase.Dispose();
        }

        public async Task<ResultInfo> Exit(long Id, string UserId)
        {
            var ofish = _dataBase.Ofish.Find(Id);
            if (ofish != null)
            {
                ofish.ExitTime = DateTime.Now;
                ofish.OnExitRegister = UserId;
                try
                {
                    await _dataBase.SaveChangesAsync();
                    return new ResultInfo
                    {
                        IsSuccess = true,
                        Message = "ثبت خروج با موفقیت انجام گردید",
                        Status = nameof(OprationStatus.success),
                        Title = "موفق"
                    };
                }
                catch
                {
                    return new ResultInfo
                    {
                        IsSuccess = true,
                        Message = "خطا در ثبت خروج",
                        Status = nameof(OprationStatus.error),
                        Title = "ناموفق"
                    };
                }
            }
            return new ResultInfo
            {
                IsSuccess = true,
                Message = "رکوردی پیدا نشد",
                Status = nameof(OprationStatus.warning),
                Title = "ناموفق"
            };

        }

        public async Task<ResultInfo> getCard(long Id)
        {
            var ofish = await _dataBase.Ofish.FindAsync(Id);
            if (ofish != null)
            {
                return new ResultInfo
                {
                    IsSuccess = true,
                    Message = ofish.PicPath,
                    Title = $"تصویر کارت ملی آقا / خانم {ofish.FullName}"
                };
            }
            else
            {
                return new ResultInfo
                {
                    IsSuccess = false
                };
            }

        }

        public async Task<ListResultVM<OfishListVM>> GetTodayOfishLists(int pageId = 1)
        {


            var modelList = _dataBase.Ofish.Include(a => a.Office)
               .Where(a => a.OffishTime.Date == DateTime.Now.Date)
               .Select(s => new OfishListVM
               {
                   FullName = s.FullName,
                   Id = s.Id,
                   NationCode = s.NationCode,
                   Office = s.Office.Name,
                   Pic = s.PicPath,
                   Staff = s.Staff,
                   OfishDateTime = s.OffishTime,
                   ExitDate = s.ExitTime,

               }).AsQueryable().OrderByDescending(a => a.OfishDateTime);

            var model = await modelList.ToPaged<OfishListVM>(pageId, "لیست تردد ارباب و رجوع", 10);

            return model;
        }

        public async Task<ListResultVM<OfishListVM>> Search(SearchVM model, int pageId = 1)
        {

            var list = _dataBase.Ofish.Include(a => a.Office)
                .AsQueryable();

           if(model.FromDate != DateTime.MinValue && model.ToDate != DateTime.MinValue)
            {
                list = list.Where(s => s.OffishTime.Date >= model.FromDate && s.OffishTime.Date <= model.ToDate);
            }
            else if (model.FromDate == DateTime.MinValue && model.ToDate != DateTime.MinValue)
            {
                list = list.Where(s => s.OffishTime.Date <= model.ToDate);
            }
            else if (model.FromDate != DateTime.MinValue && model.ToDate == DateTime.MinValue)
            {
                list = list.Where(s => s.OffishTime.Date >= model.FromDate);
            }
           

            if (model.OfficId != 0)
            {
                list = list.Where(s => s.OfficeId == model.OfficId);
            }
            if (!string.IsNullOrEmpty(model.Staff))
            {
                list = list.Where(s => s.Staff.Contains(model.Staff));
            }
            if (!string.IsNullOrEmpty(model.FullName))
            {
                list = list.Where(s => s.FullName.Contains(model.FullName));
            }
            if (!string.IsNullOrEmpty(model.NationCode))
            {
                list = list.Where(s => s.NationCode == model.NationCode);
            }


            var dataList = await
                list.Select(s => new OfishListVM
                {
                    FullName = s.FullName,
                    Id = s.Id,
                    NationCode = s.NationCode,
                    Office = s.Office.Name,
                    Pic = s.PicPath,
                    Staff = s.Staff,
                    OfishDateTime = s.OffishTime,
                    ExitDate = s.ExitTime,
                })
                .AsQueryable().OrderByDescending(s => s.OfishDateTime)
                .ToPaged(pageId, "لیست تردد ارباب و رجوع", 10);





            return new ListResultVM<OfishListVM>
            {
                DataList = dataList.DataList,
                Issuccesd = true,
                ListTitle = dataList.ListTitle,
                PageCount = dataList.PageCount,
                TotalRows = dataList.TotalRows
            };
        }
    }
}
