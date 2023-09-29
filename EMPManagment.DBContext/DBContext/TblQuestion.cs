using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
