using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblUser
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

    public int? CityId { get; set; }

    public string? Pincode { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public bool? IsAdmin { get; set; }

    public int? QuestionId { get; set; }

    public string? Answer { get; set; }

    public string? Image { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public virtual TblCity? City { get; set; }

    public virtual TblCountry? Country { get; set; }

    public virtual TblDepartment? Department { get; set; }

    public virtual TblQuestion? Question { get; set; }

    public virtual TblState? State { get; set; }

    public virtual ICollection<TblAttendance> TblAttendances { get; set; } = new List<TblAttendance>();
}
