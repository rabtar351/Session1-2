namespace WebApplication2.Model
{
    public class CommentRequest
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }

        public string Text { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public DateOnly DateUpdated { get; set; }
        public int AuthorId { get; set; }
        public string? Position { get; set; }
    }
}
