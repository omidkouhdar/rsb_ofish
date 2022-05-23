using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSB_Ofish_System.Models.ViewModels;
namespace RSB_Ofish_System.Repository.Users.Interface
{
    public interface IUserService : IDisposable
    {
        Task<ResultInfo> registerUser(RegisterVM model);
        Task<ResultInfo> login(LoginVM model);
        Task SignOut();
    }
}
