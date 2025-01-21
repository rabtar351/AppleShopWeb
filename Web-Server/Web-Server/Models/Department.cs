using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }
}
