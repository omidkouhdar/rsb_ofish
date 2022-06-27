using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSB_Ofish_System.Models.ViewModels;
namespace RSB_Ofish_System.Repository.Ofish.Interfaces
{
    public interface IOfishService:IDisposable
    {
        Task<ListResultVM<OfishListVM>> GetTodayOfishLists(int pageId = 1);
        Task<ListResultVM<OfishListVM>> Search(SearchVM model , int pageId = 1);
        Task<ResultInfo> addOfish(OfishVM ofish , string img);
        Task<ResultInfo> getCard(long Id);
        Task<ResultInfo> ShowVehiclePic(long Id);
        Task<ResultInfo> Exit(long Id , string UserId);
    }
}
