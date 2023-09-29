using EMPManagment.Web.Models.API;
using EMPManegment.EntityModels.View_Model;
using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.EmployeesInterface.AddEmployee;
using EMPManegment.Inretface.Services.AddEmployeeServies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EMPManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEmpController : ControllerBase
    {
        public AddEmpController(IAddEmpDetailsServices empDetails)
        {
            EmpDetails = empDetails;
        }

        public IAddEmpDetailsServices EmpDetails { get; }

        

        [HttpGet]
        [Route("CheckUser")]
        public IActionResult CheckUser()
        {
            var newuser = EmpDetails.CheckEmloyess();
            return Ok(new { code = 200, data = newuser });
        }


        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            IEnumerable<Department> dept = await EmpDetails.EmpDepartment();
            return Ok(new { code = 200, data = dept.ToList() });
        }


        [HttpPost]
        [Route("AddEmployees")]
        public async Task<IActionResult> AddEmployees(EmpDetailsView emp)
        {
            try
            {
                EmpDetails.AddEmployee(emp);
                return Ok(new ApiResponseModel { code = 200, data = emp });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("AddLogins")]
        public async Task<IActionResult> AddLogins(EmpDetailsView emp)
        {
            EmpDetails.AddLogin(emp);
            return Ok(new ApiResponseModel
            {
                code = 200,
                data = emp,

            });
        }

    }
}
