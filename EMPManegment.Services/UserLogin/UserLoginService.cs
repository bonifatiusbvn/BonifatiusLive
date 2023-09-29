
using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.Interface.UsersLogin;
using EMPManegment.Inretface.Services.UserLoginServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.Services.UserLogin
{
    public class UserLoginService : IUserLoginServices
    {
        public UserLoginService(IUserLogin userLogin)
        {
            UserLogin = userLogin;
        }

        public IUserLogin UserLogin { get; }

        public async Task<LoginResponseModel> LoginUser(LoginRequest request)
        {
            return await UserLogin.LoginUser(request);
        }
    }
}
