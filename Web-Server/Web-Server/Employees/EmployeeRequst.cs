namespace Web_Server.Employees
{
    public class EmployeeRequst
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MobilePhone { get; set; }

        public DateOnly? BirthDate { get; set; }

        public int? DepartmentId { get; set; }

        public int? PositionId { get; set; }

        public string? WorkPhone { get; set; }

        public string? Email { get; set; }

        public string Office { get; set; } = null!;

        public string? AdditionalInfo { get; set; }
    }
}
