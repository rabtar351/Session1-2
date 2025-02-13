 using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model
{
    public class EmployeeRequest
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string MobilePhone { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int? SupervisorId { get; set; }
        public int? AssistentId { get; set; }
        public string WorkPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Office { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
