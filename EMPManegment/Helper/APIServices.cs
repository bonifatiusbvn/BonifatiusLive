using EMPManagment.Web.Models.API;
using Newtonsoft.Json;
using System.Text;


namespace EMPManagment.Web.Helper
{
    public class APIServices
    {
        public APIServices(WebAPI webAPI,IWebHostEnvironment environment)
        {
            WebAPI = webAPI;
            Environment = environment;
        }

        public WebAPI WebAPI { get; }
        public IWebHostEnvironment Environment { get; }


        public async Task<ApiResponseModel> GetAsync(dynamic id, string endpoint)
        {
            var model = new ApiResponseModel();

            try
            {
                HttpClient clients = WebAPI.Initil();
                var url = $"{clients.BaseAddress}/{endpoint}";

                if (id != null)
                    url = $"{url}?{id}";

                var response = await clients.GetAsync(url);

                var responseContent = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<object>(responseContent);

                model = JsonConvert.DeserializeObject<ApiResponseModel>(responseContent);
                model.code = (int)response.StatusCode;

                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ApiResponseModel> PostAsync(dynamic input, string endpoint)
        {
            var model = new ApiResponseModel();

            try
            {

                StringContent data = new StringContent("");
                if (input != null)
                {
                    var json = JsonConvert.SerializeObject(input);
                    data = new StringContent(json, Encoding.UTF8, "application/json");
                }

                HttpClient clients = WebAPI.APIUrl();
                var url = $"{clients.BaseAddress}/{endpoint}";
                var responses = await clients.PostAsync(url, data);

                var responseContent = await responses.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<ApiResponseModel>(responseContent);
                model.code = (int)responses.StatusCode;

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
