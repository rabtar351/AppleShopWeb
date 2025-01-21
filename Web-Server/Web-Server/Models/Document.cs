using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public string Category { get; set; } = null!;

    public bool HasComments { get; set; }

    public virtual Comment? Comment { get; set; }
}
