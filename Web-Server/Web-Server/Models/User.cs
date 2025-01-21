using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class User
{
    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
