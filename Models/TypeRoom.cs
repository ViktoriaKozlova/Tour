using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class TypeRoom
{
    public int IdTypeRoom { get; set; }

    public string NameRoom { get; set; } = null!;

    public float PriceOfRoom { get; set; }

    public virtual ICollection<TourPackage> TourPackages { get; set; } = new List<TourPackage>();
}
