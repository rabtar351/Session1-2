using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
     public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? ManagerId { get; set; }
        public string? Description { get; set; }
    }
}
