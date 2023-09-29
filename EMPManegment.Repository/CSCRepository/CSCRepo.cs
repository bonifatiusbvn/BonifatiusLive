using EMPManagment.API;
using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.Interface.CSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.Repository.CSCRepository
{
    public class CSCRepo : ICSC
    {
        public CSCRepo (BonifatiusEmployeesContext context)
        {
            Context = context;
        }

        public BonifatiusEmployeesContext Context { get; }

        public async Task<IEnumerable<CityView>> GetCities(int id)
        {

            try
            {
                IEnumerable<CityView> cities = Context.TblCities.Where(e => e.State.Id == id).ToList().Select(a => new CityView
                {
                    Id = a.Id,
                    CityName = a.City,
                });
                return cities;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<CountryView>> GetCountries()
        {
            try
            {
                IEnumerable<CountryView> countries = Context.TblCountries.ToList().Select(a => new CountryView
                {
                    Id = a.Id,
                    CountryName = a.Country
                });
                return countries;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<QuestionView>> GetQuestion()
        {
            try
            {
                IEnumerable<QuestionView> questions = Context.TblQuestions.ToList().Select(a => new QuestionView
                {
                    Id = a.Id,
                    Questions = a.Question
                });
                return questions;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<StateView>> GetStates(int id)
        {
            try
            {
                IEnumerable<StateView> states = Context.TblStates.Where(e => e.Country.Id == id).ToList().Select(a => new StateView
                {
                    Id = a.Id,
                    StateName = a.State
                });
                return states;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
