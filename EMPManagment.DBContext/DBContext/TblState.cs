using System;
using System.Collections.Generic;

namespace EMPManagment.API;

public partial class TblState
{
    public int Id { get; set; }

    public int CountryId { get; set; }

    public string State { get; set; } = null!;

    public virtual TblCountry Country { get; set; } = null!;

    public virtual ICollection<TblCity> TblCities { get; set; } = new List<TblCity>();

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
