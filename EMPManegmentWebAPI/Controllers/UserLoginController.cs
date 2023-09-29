
using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.Services.UserLoginServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Azure.Core.HttpHeader;
using System.Net;
using System.Reflection;

namespace EMPManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        public UserLoginController(IUserLoginServices userLogin)
        {
            UserLogin = userLogin;
        }

        public IUserLoginServices UserLogin { get; }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginResponseModel response = new LoginResponseModel();
            try
            {
               
                var result = await UserLogin.LoginUser(request);

                if (result != null && result.Data != null)
                {
                    
                    response.Code = (int)HttpStatusCode.OK;
                    response.Data = result.Data;
                }
                else
                {
                    response.Message = result.Message;
                    response.Code = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
            }
            return StatusCode(response.Code, response);
        }
    }
}
