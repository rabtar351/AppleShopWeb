using System;
using System.Collections.Generic;

namespace Web_Server.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MobilePhone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? PositionId { get; set; }

    public int? SupervisorId { get; set; }

    public int? AssistantId { get; set; }

    public string? WorkPhone { get; set; }

    public string? Email { get; set; }

    public string Office { get; set; } = null!;

    public string? AdditionalInfo { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual Employee? Assistant { get; set; }

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> InverseAssistant { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> InverseSupervisor { get; set; } = new List<Employee>();

    public virtual Position? Position { get; set; }

    public virtual Employee? Supervisor { get; set; }
}
