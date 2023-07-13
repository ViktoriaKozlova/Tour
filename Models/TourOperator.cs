using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class TourOperator
{
    public int IdTourOperator { get; set; }

    public string NumberPhone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NameTourOperator { get; set; } = null!;

    public string Address { get; set; } = null!;

    public float NumberRegistration { get; set; }

    public DateOnly DateOfContract { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
