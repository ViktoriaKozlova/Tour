using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class InformationTour
{
    public int IdTour { get; set; }

    public float Price { get; set; }

    public string NameTypeTour { get; set; } = null!;

    public DateOnly DepartureDate { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public int AmountSeats { get; set; }

    public string NameTourOperator { get; set; } = null!;

    public string Place { get; set; } = null!;

    public string NameCountry { get; set; } = null!;

    public string NameHotel { get; set; } = null!;

    public int Stars { get; set; }

    public string NameFood { get; set; } = null!;

    public string NameRoom { get; set; } = null!;
}
