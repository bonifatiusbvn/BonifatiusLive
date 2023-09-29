using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblDepartment
{
    public int Id { get; set; }

    public string Department { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
