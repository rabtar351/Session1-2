using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class EventEmployeeType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [InverseProperty("EventEmployeeType")]
    public virtual ICollection<EventEmployee> EventEmployees { get; set; } = new List<EventEmployee>();
}
