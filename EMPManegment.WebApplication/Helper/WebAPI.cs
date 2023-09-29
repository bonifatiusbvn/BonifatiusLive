namespace EMPManagment.Web.Helper
{
    public class WebAPI
    {
        private readonly IConfiguration _configuration;

        public WebAPI(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public HttpClient Initil()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("AppSetting:WebAPIBaseUrl").Value);
            return client;
        }

        public HttpClient APIUrl()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("AppSetting:WebAPIUrl").Value);
            return client;
        }
    }
}
