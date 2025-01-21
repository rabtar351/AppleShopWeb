using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Canditate
{
    public int Candidate { get; set; }

    public string FirtsName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly ApplicationDate { get; set; }

    public string Field { get; set; } = null!;

    public string Resume { get; set; } = null!;
}
