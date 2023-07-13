using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class TypeTour
{
    public int IdTypeTour { get; set; }

    public string NameTypeTour { get; set; } = null!;

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
