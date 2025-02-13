namespace WebApplication2.Model
{
    public class DocumentRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly DateCreated { get; set; }
        public DateOnly DateUpdated { get; set; }
        public string Category { get; set; } = null!;
        public bool HasComment { get; set; }
    }
}
