using EMPManegment.EntityModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.Inretface.Interface.CSC
{
    public interface ICSC
    {
        Task<IEnumerable<CountryView>> GetCountries();
        Task<IEnumerable<QuestionView>> GetQuestion();
        Task<IEnumerable<StateView>> GetStates(int id);
        Task<IEnumerable<CityView>> GetCities(int id);
     
    }
}
