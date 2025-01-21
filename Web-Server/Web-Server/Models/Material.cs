using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Material
{
    public int MaterialId { get; set; }

    public string MaterialName { get; set; } = null!;

    public DateOnly ApprovalDate { get; set; }

    public DateOnly ModificationDate { get; set; }

    public int MaterialStatusId { get; set; }

    public int MaterialTypeId { get; set; }

    public string Domain { get; set; } = null!;

    public string Author { get; set; } = null!;

    public virtual MaterialStatus MaterialStatus { get; set; } = null!;

    public virtual MaterialType MaterialType { get; set; } = null!;

    public virtual ICollection<TrainingClasses12> TrainingClasses12s { get; set; } = new List<TrainingClasses12>();
}
