using WebApplication2.Models;

namespace WebApplication2.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string MobilePhone { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int PositionId { get; set; }
        public string PositionName { get; set; } = null!;
        public int? SupervisorId { get; set; }
        public int? AssistentId { get; set; }
        public string WorkPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Office { get; set; }
        public string? AdditionalInfo { get; set; }

        public EmployeeModel(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Patronymic = employee.Patronymic;
            MobilePhone = employee.MobilePhone;
            BirthDate = employee.BirthDate;
            DepartmentId = employee.DepartmentId;
            PositionId = employee.PositionId;
            SupervisorId = employee.SupervisorId;
            AssistentId = employee.AssistentId;
            WorkPhone = employee.WorkPhone;
            Email = employee.Email;
            Office = employee.Office;
            AdditionalInfo = employee.AdditionalInfo;

            DepartmentName = employee.Department.DepartmentName;
            PositionName = employee.Position.PositionName;
        }
    }
}
