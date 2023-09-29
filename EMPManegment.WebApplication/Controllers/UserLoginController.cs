using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using static Azure.Core.HttpHeader;
using EMPManagment.Web.Helper;
using EMPManagment.Web.Models.API;
using EMPManegment.EntityModels.ViewModels;
using EMPManegment.EntityModels.View_Model;

namespace EMPManegment.Web.Controllers
{
    public class UserLoginController : Controller
    {

        public UserLoginController(WebAPI webAPI, APIServices aPIServices, IWebHostEnvironment environment)
        {
            WebAPI = webAPI;
            APIServices = aPIServices;
            Environment = environment;
        }

        public WebAPI WebAPI { get; }
        public APIServices APIServices { get; }
        public IWebHostEnvironment Environment { get; }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApiResponseModel response = await APIServices.PostAsync(login, "UserLogin/Login");

                    if (response.code != (int)HttpStatusCode.OK)
                    {
                        if (response.code == (int)HttpStatusCode.Forbidden)
                        {
                            TempData["ErrorMessage"] = response.message;
                            return Ok(new { Message = string.Format(response.message), Code = response.code });
                        }
                        else
                        {
                            TempData["ErrorMessage"] = response.message;
                            return Ok(new { Message = string.Format(response.message), Code = response.code });

                        }
                    }
                    var user = response.data;
                }
                
                return View();

            }
             
            catch (Exception ex)
            {
                return BadRequest(new { Message = "InternalServer" });

            }

            return View();
        }

    }
}
