using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblCountry
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<TblState> TblStates { get; set; } = new List<TblState>();

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
