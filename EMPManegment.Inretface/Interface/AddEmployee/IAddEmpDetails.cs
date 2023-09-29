
using EMPManegment.EntityModels.View_Model;
using EMPManegment.EntityModels.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.Inretface.EmployeesInterface.AddEmployee
{
    public interface IAddEmpDetails
    {
        Task <EmpDetailsView> AddLogin(EmpDetailsView emp);
        Task <EmpDetailsView> GetById(string EId);
        string CheckEmloyess();
        Task <EmpDetailsView> AddEmployee(EmpDetailsView emp);
        void UploadFile(IFormFile file, string path);

        Task<IEnumerable<Department>> EmpDepartment();
    }
}
