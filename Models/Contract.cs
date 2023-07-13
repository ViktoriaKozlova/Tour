using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Contract
{
    public int IdContract { get; set; }

    public int NumberUser { get; set; }

    public int NumberStatus { get; set; }

    public int QuantityTourists { get; set; }

    public int NumberTour { get; set; }

    public DateOnly DateOfConlusion { get; set; }

    public string NumberInvoice { get; set; } = null!;

    public float Sum { get; set; }

    public string Description { get; set; } = null!;

    public virtual Insurance? Insurance { get; set; }

    public virtual Status NumberStatusNavigation { get; set; } = null!;

    public virtual Tour NumberTourNavigation { get; set; } = null!;

    public virtual User NumberUserNavigation { get; set; } = null!;
}
