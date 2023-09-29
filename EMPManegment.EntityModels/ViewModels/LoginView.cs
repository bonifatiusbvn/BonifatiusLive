using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.EntityModels.ViewModels
{
    public class LoginView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImage { get; set; }
        public string EmpId { get; set;}
        public string Password { get; set;}

        public DateTime? LastLoginDate { get; set; }
    }
    public class LoginResponseModel
    {
        public string Message { get; set; }

        public int Code { get; set; }

        public string Token { get; set; }

        public LoginView Data { get; set; }

    }
}
