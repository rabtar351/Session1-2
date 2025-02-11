namespace WebApplication1.Model
{
    public class EventEmployeeRequest
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public int? EventEmployeeTypeId { get; set; }
        public string EventEmployeeTypeName { get; set; }

    }
}
