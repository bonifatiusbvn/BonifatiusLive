using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.Interface.CSC;
using EMPManegment.Services.CSC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSCController : ControllerBase
    {
        public CSCController(ICSC cSC)
        {
            CSC = cSC;
        }

        public ICSC CSC { get; }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            IEnumerable<CountryView> dept = await CSC.GetCountries();
            return Ok(new { code = 200, data = dept.ToList() });
        }



        [HttpGet]
        [Route("GetState")]
        public async Task<IActionResult> GetState(int id)
        {
            IEnumerable<StateView> States = await CSC.GetStates(id);
            return Ok(new { code = 200, data = States.ToList() });
        }

        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities(int id)
        {
            IEnumerable<CityView> Cities = await CSC.GetCities(id);
            return Ok(new { code = 200, data = Cities.ToList() });
        }

        [HttpGet]
        [Route("GetQuestion")]
        public async Task<IActionResult> GetQuestion()
        {
            IEnumerable<QuestionView> Cities = await CSC.GetQuestion();
            return Ok(new { code = 200, data = Cities.ToList() });
        }

    }
}
