using System;
using System.Collections.Generic;

namespace AppleStore.Models;

public partial class Document
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? HasComments { get; set; }
}
