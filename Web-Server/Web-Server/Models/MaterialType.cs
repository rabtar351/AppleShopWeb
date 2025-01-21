using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class MaterialType
{
    public int MaterialTypeId { get; set; }

    public string MaterialTypeName { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
