using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPManegment.EntityModels.View_Model
{
    public class EmpDetailsView
    {
        public int Id { get; set; }

        public string? EmpId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public bool? EmailConfirmed { get; set; }

        public string? Address { get; set; }

        public int? City { get; set; }

        public string? Pincode { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? PhoneNumberConfirmed { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? IsAdmin { get; set; }

        public int QuestionId { get; set; }

        public string? Answer { get; set; }

        public string? Image { get; set; }

        public int? Department { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public int? State { get; set; }

        public int? Country { get; set; }
    }


    
}
