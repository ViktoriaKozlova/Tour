using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class TypeTransport
{
    public int IdTypeTransport { get; set; }

    public string NameTypeTransport { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
