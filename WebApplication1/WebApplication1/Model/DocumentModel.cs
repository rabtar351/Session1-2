using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entities;

namespace WebApplication1.Model
{
    public class DocumentModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateOnly DateCreated { get; set; }

        public DateOnly DateUpdated { get; set; }

        public string Category { get; set; } = null!;

        public bool HasComment { get; set; }

        public DocumentModel (Document model)
        {
            Id = model.Id;
            Title = model.Title;
            DateCreated = model.DateCreated;
            DateUpdated = model.DateUpdated;
            Category = model.Category;
            HasComment = model.HasComment;
        }
    }
}
