using EMPManagment.API;

using EMPManegment.EntityModels.View_Model;
using EMPManegment.EntityModels.ViewModels;
using EMPManegment.Inretface.EmployeesInterface.AddEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.Repository.AddEmpRepository
{
    public class AddEmpRepo : IAddEmpDetails
    {

        public AddEmpRepo(BonifatiusEmployeesContext context)
        {
            Context = context;
        }

        public BonifatiusEmployeesContext Context { get; }

        public async Task<EmpDetailsView> AddEmployee(EmpDetailsView emp)
        {
            try
            {
                var model = new TblUser()
                {
                    EmpId = emp.EmpId,
                    DepartmentId = emp.Department,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Address = emp.Address,
                    CityId = emp.City,
                    StateId = emp.State,
                    CountryId = emp.Country,
                    DateOfBirth = emp.DateOfBirth,
                    Email = emp.Email,
                    Gender = emp.Gender,
                    PhoneNumber = emp.PhoneNumber,
                    CreatedOn = DateTime.Now,
                    
                };
                Context.TblUsers.Add(model);
                Context.SaveChanges();
                return emp;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<EmpDetailsView> AddLogin(EmpDetailsView log)
        {
            try
            {
                var data = Context.TblUsers.FirstOrDefault(a => a.EmpId == log.EmpId);
                if (data != null)
                {
                    data.PasswordHash = log.PasswordHash;
                    data.PasswordSalt = log.PasswordSalt;
                    data.QuestionId = log.QuestionId;
                    data.Answer = log.Answer;
                    data.Image = log.Image;
                    data.IsActive = true;

                    Context.TblUsers.Update(data);
                    Context.SaveChanges();
                }
                return log;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckEmloyess()
        {
            try
            {
                var LastEmp = Context.TblUsers.OrderByDescending(e => e.Id).SingleOrDefault();
                string UserEmpId;
                if (LastEmp == null)
                {
                    UserEmpId = "BONI-UID001";
                }
                else
                {
                    UserEmpId = "BONI-UID" + (Convert.ToUInt32(LastEmp.EmpId.Substring(9, LastEmp.EmpId.Length - 9)) + 1).ToString("D3");
                }

                return UserEmpId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async Task<IEnumerable<Department>> EmpDepartment()
        {
            try
            {
                IEnumerable<Department> dept = Context.TblDepartments.ToList().Select(a => new Department
                {
                    Id = a.Id,
                    Departments = a.Department
                });
                return dept;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<EmpDetailsView> GetById(string EId)
        {
            throw new NotImplementedException();
        }

        public void UploadFile(IFormFile file, string path)
        {
            throw new NotImplementedException();
        }
        

        //public EmpDetailsView AddLogin(EmpDetailsView log)
        //{
        //    try
        //    {
        //        var data = Context.TblUsers.FirstOrDefault(a => a.Id == log.Id);
        //        if (data != null)
        //        {
        //            data.Id = log.Id;
        //            data.EmpId = log.EmpId;
        //            data.PasswordHash = log.PasswordHash;
        //            data.PasswordSalt = log.PasswordSalt;
        //            data.Question = log.Question;
        //            data.Answer = log.Answer;
        //            data.Image = log.Image;
        //            data.IsActive = true;



        //            Context.TblUsers.Update(data);
        //            Context.SaveChanges();
        //        }
        //        return log;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

    }   
}
