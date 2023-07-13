using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Location
{
    public int IdLocation { get; set; }

    public string Place { get; set; } = null!;

    public int NumberCountry { get; set; }

    public virtual Country NumberCountryNavigation { get; set; } = null!;

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
