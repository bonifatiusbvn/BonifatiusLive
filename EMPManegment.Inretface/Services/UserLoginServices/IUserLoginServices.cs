
using EMPManegment.EntityModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.Inretface.Services.UserLoginServices
{
    public interface IUserLoginServices
    {
        Task<LoginResponseModel> LoginUser(LoginRequest request);
    }
}
