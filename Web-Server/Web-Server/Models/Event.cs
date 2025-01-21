using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int CalendarId { get; set; }

    public string EventName { get; set; } = null!;

    public int EventTypeId { get; set; }

    public int EventStatusId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string ResponsiblePersons { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Calendar Calendar { get; set; } = null!;

    public virtual EventStatus EventStatus { get; set; } = null!;

    public virtual EventType EventType { get; set; } = null!;

    public virtual ICollection<TrainingClasses12> TrainingClasses12s { get; set; } = new List<TrainingClasses12>();
}
