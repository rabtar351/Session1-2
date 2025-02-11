using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Calendar
{
    [Key]
    [Column("CalendarID")]
    public int CalendarId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("CalendarTypeID")]
    public int CalendarTypeId { get; set; }

    [ForeignKey("CalendarTypeId")]
    [InverseProperty("Calendars")]
    public virtual CalendarType CalendarType { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    [InverseProperty("Calendars")]
    public virtual Department? Department { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Calendars")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("Calendar")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
