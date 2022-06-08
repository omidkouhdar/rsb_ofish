using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using RSB_Ofish_System.Models.ViewModels;
using RSB_Ofish_System.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CommonTools
{
    public static class Tools
    {
        public static string GetUserId(System.Security.Claims.ClaimsPrincipal principal)
        {
            return principal.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public static string ToshamsiDate(this DateTime Date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(Date).ToString() + "/" + pc.GetMonth(Date).ToString("00") + "/" + pc.GetDayOfMonth(Date).ToString("00");
        }
        public static int GetYearShamsi(this DateTime Date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(Date);
        }
        public static DateTime convertShamsiToMiladi(this string shamsiDate)
        {

            if (string.IsNullOrWhiteSpace(shamsiDate))
            {
                return DateTime.MinValue;
            }
            var dateItems = shamsiDate.Split('/');
            int yer = 0;
            int month = 0;
            int day = 1;
            int.TryParse(dateItems[0], out yer);
            int.TryParse(dateItems[1], out month);
            int.TryParse(dateItems[2], out day);
            var calender = new System.Globalization.PersianCalendar();
            DateTime date = new DateTime(yer, month, day, calender);
            return date;
        }

        public static Int64 ConvertShamsiDateToInt(this string ShamsiDate)
        {
            string standard = ShamsiDate.Replace("/", "");
            Int64 result = 0;
            Int64.TryParse(standard, out result);
            return result;

        }
        public static string ToLongshamsiDate(this DateTime Date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(Date).ToString() + "/" + getMonthName(pc.GetMonth(Date)) + "/" + pc.GetDayOfMonth(Date).ToString("00");
        }

        public static string getMonthName(int month)
        {
            string MonthName = "";
            switch (month)
            {
                case 1:
                    MonthName = "فروردین";
                    break;
                case 2:
                    MonthName = "اردیبهشت";
                    break;
                case 3:
                    MonthName = "خرداد";
                    break;
                case 4:
                    MonthName = "تیر";
                    break;
                case 5:
                    MonthName = "مرداد";
                    break;
                case 6:
                    MonthName = "شهریور";
                    break;
                case 7:
                    MonthName = "مهر";
                    break;
                case 8:
                    MonthName = "آبان";
                    break;
                case 9:
                    MonthName = "آذر";
                    break;
                case 10:
                    MonthName = "دی";
                    break;

                case 11:
                    MonthName = "بهمن";
                    break;
                case 12:
                    MonthName = "اسفند";
                    break;

            }
            return MonthName;
        }

        public static string savePic(string Base64string)
        {
            if (string.IsNullOrEmpty(Base64string))
                return string.Empty;
            Base64string = Base64string.Substring(Base64string.LastIndexOf(',') + 1);
            try
            {
                string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ofishimg", getTodayFolder());
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(path: dirPath);
                }

                var image = Convert.FromBase64String(Base64string);
                Bitmap srcbitmap;
                Bitmap cropedBitmap;
                byte[] imageData;
                using (var ms = new MemoryStream(image))
                {
                    srcbitmap = new Bitmap(ms);
                }
                using (var croper = new ImageCropper())
                {
                    cropedBitmap = croper.getCrropped(srcbitmap);
                }



                srcbitmap.Dispose();

                string picName = Guid.NewGuid().ToString() + ".jpeg";
                string pathTpStore = Path.Combine(dirPath, picName);

                using (var stream = new MemoryStream())
                {
                    cropedBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = stream.ToArray();
                }


                File.WriteAllBytes(pathTpStore, imageData);
                return Path.Combine("/ofishimg/", getTodayFolder(), picName);
            }
            catch
            {
                return string.Empty;
            }

        }
        public static string getTodayFolder()
        {
            return DateTime.Now.ToshamsiDate().Replace("/", string.Empty);
        }

        public static async Task<ListResultVM<T>> ToPaged<T>(this IQueryable<T> list, int PageId, string ListTitle, int PageSize = 5)

        {

            int totalRows = list.Count();
            int pageCount = totalRows / PageSize;
            if (PageId == 0)
                PageId = 1;

            if (totalRows % PageSize > 0)
            {
                pageCount++;
            }
            var datalist = await list.Skip((PageId - 1) * PageSize).
                Take(PageSize).ToListAsync();

            return new ListResultVM<T>
            {
                DataList = datalist,
                ListTitle = ListTitle,
                PageCount = pageCount,
                TotalRows = totalRows
            };
        }
        public static bool isCorrectNationCode(string nationCode)
        {
            if (string.IsNullOrEmpty(nationCode))
                return false;
            var d = nationCode.AsEnumerable().ToArray();

            if (d.Count() != 10)
                return false;
            byte A = 0;
            if (!char.IsDigit(nationCode[9]))
                return false;
            A = byte.Parse(nationCode[9].ToString());
            byte p = 10;
            int B = 0;
            byte C = 0;

            for (byte i = 0; i < 9; i++)
            {
                if (!char.IsDigit(d[i]))
                    return false;
                B += byte.Parse(d[i].ToString()) * p;
                p -= 1;
            }
            C = Convert.ToByte(B - (B / 11) * 11);

            if (C == 0 && A == C)
                return true;
            if (C == 1 && A == 1)
                return true;
            if (C > 1 && A == Math.Abs(C - 11))
                return true;
            return false;
        }
    }
}
