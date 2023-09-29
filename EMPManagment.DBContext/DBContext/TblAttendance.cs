using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblAttendance
{
    public int Id { get; set; }

    public int EmpId { get; set; }

    public DateTime Date { get; set; }

    public DateTime Intime { get; set; }

    public DateTime? OutTime { get; set; }

    public decimal? TotalHours { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual TblUser Emp { get; set; } = null!;
}
