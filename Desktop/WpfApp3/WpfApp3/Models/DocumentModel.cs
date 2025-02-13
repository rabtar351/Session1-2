using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly DateCreated { get; set; }
        public DateOnly DateUpdated { get; set; }
        public string Category { get; set; } = null!;
        public bool HasComment { get; set; }
    }
}
