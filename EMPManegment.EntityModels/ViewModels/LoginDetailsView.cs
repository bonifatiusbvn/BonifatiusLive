using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
#nullable disable
namespace EMPManegment.EntityModels.View_Model
{
    public class LoginDetailsView
    {

        [Required(ErrorMessage = "Please Enter Employee Code..!")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Please Enter Password..!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter the Confirm Password..!")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = ("Confirm Password Dose Not Match..!!"))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Select Question..!")]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please Enter Answer For Selected Question..!")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "Please Select Your Image..!")]
        public IFormFile Image { get; set; }

        public bool IsActive { get; set; }
    }
}
