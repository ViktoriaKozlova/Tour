using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string NameCountry { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
