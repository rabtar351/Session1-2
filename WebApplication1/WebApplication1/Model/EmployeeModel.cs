using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entities;

namespace WebApplication1.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string MobilePhone { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; } 

        public int? PositionId { get; set; }
        public string PositionName { get; set; }

        public int? SupervisorId { get; set; }

        public int? AssistentId { get; set; }

        public string? WorkPhone { get; set; }

        public string? Email { get; set; }
        public string? Office { get; set; }
        public string? AdditionalInfo { get; set; }

        public EmployeeModel(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Patronymic = employee.Patronymic;
            MobilePhone = employee.MobilePhone;
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
