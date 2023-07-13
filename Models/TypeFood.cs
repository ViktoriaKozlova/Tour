using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class TypeFood
{
    public int IdTypeFood { get; set; }

    public string NameFood { get; set; } = null!;

    public float PriceOfFood { get; set; }

    public virtual ICollection<TourPackage> TourPackages { get; set; } = new List<TourPackage>();
}
