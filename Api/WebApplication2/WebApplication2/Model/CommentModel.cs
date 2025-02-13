using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Model
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }

        public string Text { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public DateOnly DateUpdated { get; set; }
        public int AuthorId { get; set; }
        public string? Position { get; set; }

        public CommentModel(Comment comment)
        {
            Id = comment.Id;
            DocumentId = comment.DocumentId;
            Text = comment.Text;
            DateCreated = comment.DateCreated;
            DateUpdated = comment.DateUpdated;
            AuthorId = comment.AuthorId;
            Position = comment.Position;
        }
    }
}
