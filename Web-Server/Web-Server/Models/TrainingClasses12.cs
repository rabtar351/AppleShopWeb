using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class TrainingClasses12
{
    public int TrainingId { get; set; }

    public int EventId { get; set; }

    public int? MaterialId { get; set; }

    public string? TrainingDescription { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Material? Material { get; set; }
}
