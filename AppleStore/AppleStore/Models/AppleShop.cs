using System;
using System.Collections.Generic;

namespace AppleStore.Models;

public partial class AppleShop
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Brands { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public decimal Price { get; set; }
}
