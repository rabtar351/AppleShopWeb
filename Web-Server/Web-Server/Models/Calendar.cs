using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Calendar
{
    public int CalendarId { get; set; }

    public int EmployeeId { get; set; }

    public int DepartmentId { get; set; }

    public int CalendarTypeId { get; set; }

    public virtual CalendarType CalendarType { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
