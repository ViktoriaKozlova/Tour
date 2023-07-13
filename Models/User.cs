using System;
using System.Collections.Generic;

namespace WebTour.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int NumberRole { get; set; }

    public DateOnly DateOfBirhday { get; set; }

    public string NumberPassport { get; set; } = null!;

    public sbyte CovidCertificate { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Role NumberRoleNavigation { get; set; } = null!;
}
