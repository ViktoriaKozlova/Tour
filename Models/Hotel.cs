using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Hotel
{
    public int IdHotel { get; set; }

    public string NameHotel { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Stars { get; set; }

    public float PriceOfHotel { get; set; }

    public virtual ICollection<TourPackage> TourPackages { get; set; } = new List<TourPackage>();
}
