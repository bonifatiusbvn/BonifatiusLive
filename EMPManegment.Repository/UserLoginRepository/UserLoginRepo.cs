using EMPManagment.API;

using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.Interface.UsersLogin;
using EMPManegment.Web.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMPManegment.Repository.UserLoginRepository
{
    public class UserLoginRepo : IUserLogin
    {
        public UserLoginRepo(BonifatiusEmployeesContext context, IWebHostEnvironment environment)
        {
            Context = context;
            Environment = environment;
        }

        public BonifatiusEmployeesContext Context { get; }
        public IWebHostEnvironment Environment { get; }

        public bool GetUserName(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponseModel> LoginUser(LoginRequest request)
        {
            LoginResponseModel response = new LoginResponseModel();
            try
            {
              
                  var tblUser = Context.TblUsers.Where(p => p.EmpId == request.EmpId).SingleOrDefault();

               
                if (tblUser != null)
                {

                    if (tblUser.IsActive == true)
                    {
                        if (tblUser.EmpId == request.EmpId && Crypto.VarifyHash(request.Password, tblUser.PasswordHash, tblUser.PasswordSalt))
                            
                        {
                            LoginView userModel = new LoginView();
                            userModel.Id = tblUser.Id;
                            userModel.EmpId = request.EmpId;    
                            userModel.FirstName = tblUser.FirstName;
                            userModel.LastName = tblUser.LastName;
                            userModel.ProfileImage = tblUser.Image;
                            response.Data = userModel;
                            response.Code = (int)HttpStatusCode.OK;
                        }

                        else
                        {
                            response.Message = "Your Password Is Wrong";
                        }
                        
                    }
                    else
                    {
                      
                        response.Code = (int)HttpStatusCode.Forbidden;
                        response.Message = "Your Deactive Contact Your Admin";
                        return response;
                    }

                }
                else
                {
                    
                    response.Message = "User Not Exist";
                    response.Code = (int)HttpStatusCode.NotFound;
                    response.Data = null;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
    
}
