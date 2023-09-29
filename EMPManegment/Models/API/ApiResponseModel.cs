namespace EMPManagment.Web.Models.API
{
    public class ApiResponseModel
    {
        public int code { get; set; }
        public dynamic data { get; set; }
        public string message { get; set; }
    }
}
