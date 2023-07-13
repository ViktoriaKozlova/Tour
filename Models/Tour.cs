using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Tour
{
    public int IdTour { get; set; }

    public DateOnly DepartureDate { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public int AmountSeats { get; set; }

    public int NumberTypeTour { get; set; }

    public float Price { get; set; }

    public string Description { get; set; } = null!;

    public int NumberTourOperator { get; set; }

    public int NumberLocation { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Location NumberLocationNavigation { get; set; } = null!;

    public virtual TourOperator NumberTourOperatorNavigation { get; set; } = null!;

    public virtual TypeTour NumberTypeTourNavigation { get; set; } = null!;

    public virtual ICollection<TourPackage> TourPackages { get; set; } = new List<TourPackage>();
}
