using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Entities;

namespace WebApplication1.Model
{
    public class EventEmployeeModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public int? EventEmployeeTypeId { get; set; }

        public EventEmployeeModel(EventEmployee employee)
        {
            Id = employee.Id;
            EmployeeId = employee.EmployeeId;
            DateStart = employee.DateStart;
            DateEnd = employee.DateEnd;
            EventEmployeeTypeId = employee.EventEmployeeTypeId;

        } 
    }
}
