using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class CalendarType
{
    public int CalendarTypeId { get; set; }

    public string CalendarTypeName { get; set; } = null!;

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
}
