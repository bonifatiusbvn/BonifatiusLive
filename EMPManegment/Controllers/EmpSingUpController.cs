using EMPManagment.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace EMPManagment.Web.Controllers
{
    public class EmpSingUpController : Controller
    {
        public WebAPI WebAPI { get; }
        public IWebHostEnvironment Environment { get; }
        public APIServices APIServices { get; }

        public EmpSingUpController(WebAPI webAPI,IWebHostEnvironment environment, APIServices aPIServices)
        {
            WebAPI = webAPI;
            Environment = environment;
            APIServices = aPIServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EmpDetails()
        {
                return View();

            
            
        }
        public IActionResult EmpSingUP()
        {
            return View();  
        }

        public IActionResult EmpLogin()
        {
            return View();
        }
    }
}
