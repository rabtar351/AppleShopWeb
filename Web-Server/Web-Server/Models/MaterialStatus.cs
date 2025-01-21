using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class MaterialStatus
{
    public int MaterialStatusId { get; set; }

    public string MaterialStatusName { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
