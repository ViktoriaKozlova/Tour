using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class TourPackage
{
    public int IdTourPackage { get; set; }

    public int NumberTypeRoom { get; set; }

    public int NumberTypeFood { get; set; }

    public int NumberHotel { get; set; }

    public string Description { get; set; } = null!;

    public float CostTourPackage { get; set; }

    public virtual Hotel NumberHotelNavigation { get; set; } = null!;

    public virtual TypeFood NumberTypeFoodNavigation { get; set; } = null!;

    public virtual TypeRoom NumberTypeRoomNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
