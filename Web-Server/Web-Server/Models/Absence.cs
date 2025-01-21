using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Absence
{
    public int AbsenceId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int? SubstituteId { get; set; }

    public string? Reason { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
