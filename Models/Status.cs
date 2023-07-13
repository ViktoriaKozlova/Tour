using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string NameStatus { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
