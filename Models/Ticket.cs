using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public string PlaceOfDeparture { get; set; } = null!;

    public DateOnly DataOfDeparture { get; set; }

    public TimeOnly TimeOfDeparture { get; set; }

    public string Class { get; set; } = null!;

    public string PlaceOfArrival { get; set; } = null!;

    public DateOnly DateOfArrival { get; set; }

    public TimeOnly TimeOfArrival { get; set; }

    public float PriceTicket { get; set; }

    public virtual ICollection<TourPackage> TourPackages { get; set; } = new List<TourPackage>();

    public virtual ICollection<TypeTransport> TypeTransports { get; set; } = new List<TypeTransport>();
}
