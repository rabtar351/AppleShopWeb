using Web_Server.Models;

namespace Web_Server.Employees
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MobilePhone { get; set; }

        public DateOnly? BirthDate { get; set; }

        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public int? PositionId { get; set; }
        public string? PositionName { get; set; }

        public int? SupervisorId { get; set; }

        public int? AssistantId { get; set; }

        public string? WorkPhone { get; set; }

        public string? Email { get; set; }

        public string Office { get; set; } = null!;

        public string? AdditionalInfo { get; set; }

        public EmployeeModel(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            MobilePhone = employee.MobilePhone;
            BirthDate = employee.BirthDate;
            DepartmentId = employee.DepartmentId;
            PositionId = employee.PositionId;
            SupervisorId = employee.SupervisorId;
            AssistantId = employee.AssistantId;
            WorkPhone = employee.WorkPhone;
            Email = employee.Email;
            Office = employee.Office;
            AdditionalInfo = employee.AdditionalInfo;

            PositionName = employee.Position?.PositionName;
            DepartmentName = employee.Department?.DepartmentName;
        }
    }
}
