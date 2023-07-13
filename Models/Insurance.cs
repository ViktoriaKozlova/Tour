using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Insurance
{
    public int ContractIdContract { get; set; }

    public string NameInsurance { get; set; } = null!;

    public string Description { get; set; } = null!;

    public float Price { get; set; }

    public DateOnly DateLicense { get; set; }

    public virtual Contract ContractIdContractNavigation { get; set; } = null!;
}
