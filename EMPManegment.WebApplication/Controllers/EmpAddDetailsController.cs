
using EMPManagment.Web.Helper;
using EMPManagment.Web.Models.API;
using EMPManegment.EntityModels.View_Model;
using EMPManegment.EntityModels.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using System.Text;
using EMPManegment.Web.Helper;
using Microsoft.AspNetCore.Authorization;

namespace EMPManegment.WebApplication.Controllers
{
    [AllowAnonymous]
    public class EmpAddDetailsController : Controller
    {

        public EmpAddDetailsController(WebAPI webAPI, IWebHostEnvironment environment, APIServices aPIServices)
        {
            WebAPI = webAPI;
            Environment = environment;
            APIServices = aPIServices;
        }

        public WebAPI WebAPI { get; }
        public IWebHostEnvironment Environment { get; }
        public APIServices APIServices { get; }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddEmpDetails()
        {
            try
            {
               
                HttpClient client = WebAPI.Initil();
                ApiResponseModel res = await APIServices.GetAsync("","AddEmp/CheckUser");
                if (res.code == 200)
                {
                    ViewBag.EmpId = res.data;
                }
                
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmpDetails(EmpDetailsView emp)
        {
            try
            {
                ApiResponseModel postuser = await APIServices.PostAsync(emp,"AddEmp/AddEmployees");
                if (postuser.code == 200)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, emp.EmpId) }, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("EmpID",emp.EmpId);
                    return RedirectToAction("EmpSingUP");
                }
                else
                {
                    return View(emp);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IActionResult> EmpSingUP()
        {

            try
            {
                LoginDetailsView login = new LoginDetailsView();
                ViewBag.Name = HttpContext.Session.GetString("EmpID");
                login.EmpId = ViewBag.Name = HttpContext.Session.GetString("EmpID");
                HttpClient client = WebAPI.Initil();
                HttpResponseMessage res = await client.GetAsync("AddEmp/GetById?EId=" + login.EmpId);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<LoginDetailsView>(result);
                }
                return View(login);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EmpSingUP(LoginDetailsView Emplogin)
        {

            try
            {
                ViewBag.Name = HttpContext.Session.GetString("EmpID");
                Emplogin.EmpId = ViewBag.Name = HttpContext.Session.GetString("EmpID");
                if (ModelState.IsValid)
                {
                    var path = Environment.WebRootPath;
                    var filepath = "Content/Image/" + Emplogin.Image.FileName;
                    var fullpath = Path.Combine(path, filepath);
                    UploadFile(Emplogin.Image, fullpath);
                    Crypto.Hash(Emplogin.Password,
                        out byte[] passwordHash,
                        out byte[] passwordSalt);
                    var data = new EmpDetailsView()
                    {

                        EmpId = Emplogin.EmpId,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        QuestionId = Emplogin.QuestionId,
                        Answer = Emplogin.Answer,
                        Image = filepath,
                        IsActive = Emplogin.IsActive,
                    };

                    ApiResponseModel postuser = await APIServices.PostAsync(data, "AddEmp/AddLogins");
                    if (postuser.code == 200)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,Emplogin.EmpId) }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("EmpID", Emplogin.EmpId);
                        TempData["SuccesMessage"] = "You Can Now LOgin.!!";
                        return RedirectToAction("Login","UserLogin");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Empty form Can't be submitted";
                    return View(Emplogin);
                }
                return View(Emplogin);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<JsonResult> GetDepartment()
        {

            try
            {
                List<Department> departments = new List<Department>();
                HttpClient client = WebAPI.Initil();
                ApiResponseModel res = await APIServices.GetAsync(null,"AddEmp/GetDepartment");
                if (res.code == 200)
                {
                    departments = JsonConvert.DeserializeObject<List<Department>>(res.data.ToString());
                }
                return new JsonResult(departments);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JsonResult> GetCountrys()
        {

            try
            {
                List<CountryView> countries = new List<CountryView>();
                HttpClient client = WebAPI.Initil();
                ApiResponseModel res = await APIServices.GetAsync(null,"CSC/GetCountries");
                if (res.code == 200)
                {
                    countries = JsonConvert.DeserializeObject<List<CountryView>>(res.data.ToString());
                }
                return new JsonResult(countries);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> GetState(int id)
        {

            try
            {
                List<StateView> states = new List<StateView>();
                HttpClient client = WebAPI.Initil();
                ApiResponseModel res = await APIServices.GetAsync(id,"CSC/GetState");
                if (res.code == 200)
                {
                    states = JsonConvert.DeserializeObject<List<StateView>>(res.data.ToString());
                }
                return new JsonResult(states);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> GetCity(int id)
        {

            try
            {
                List<CityView> cities = new List<CityView>();
                HttpClient client = WebAPI.Initil();
                ApiResponseModel res = await APIServices.GetAsync(id,"CSC/GetCities");
                if (res.code == 200)
                {
                    cities = JsonConvert.DeserializeObject<List<CityView>>(res.data.ToString());
                }
                return new JsonResult(cities);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<JsonResult> GetQuestion()
        {

            try
            {
                List<QuestionView> questions = new List<QuestionView>();
                HttpClient client = WebAPI.Initil();
                ApiResponseModel res = await APIServices.GetAsync(null, "CSC/GetQuestion");
                if (res.code == 200)
                {
                    questions = JsonConvert.DeserializeObject<List<QuestionView>>(res.data.ToString());
                }
                return new JsonResult(questions);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
