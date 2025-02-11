using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class CalendarType
{
    [Key]
    [Column("CalendarTypeID")]
    public int CalendarTypeId { get; set; }

    [StringLength(200)]
    public string CalendarTypeName { get; set; } = null!;

    [InverseProperty("CalendarType")]
    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
}
