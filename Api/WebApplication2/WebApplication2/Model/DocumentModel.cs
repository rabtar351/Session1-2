using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Model
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly DateCreated { get; set; }
        public DateOnly DateUpdated { get; set; }
        public string Category { get; set; } = null!;
        public bool HasComment { get; set; }

        public DocumentModel(Document document)
        {
            Id = document.Id;
            Title = document.Title;
            DateCreated = document.DateCreated;
            DateUpdated = document.DateUpdated;
            Category = document.Category;
            HasComment = document.HasComment;
        }
    }
}
