using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblCity
{
    public int Id { get; set; }

    public int StateId { get; set; }

    public string City { get; set; } = null!;

    public virtual TblState State { get; set; } = null!;

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
