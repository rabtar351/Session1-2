using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Event
{
    [Key]
    [Column("EventID")]
    public int EventId { get; set; }

    [Column("CalendarID")]
    public int CalendarId { get; set; }

    [StringLength(200)]
    public string EventName { get; set; } = null!;

    [Column("EventTypeID")]
    public int EventTypeId { get; set; }

    [Column("EventStatusID")]
    public int EventStatusId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? ResponsiblePersons { get; set; }

    public string? Description { get; set; }

    [ForeignKey("CalendarId")]
    [InverseProperty("Events")]
    public virtual Calendar Calendar { get; set; } = null!;

    [ForeignKey("EventStatusId")]
    [InverseProperty("Events")]
    public virtual EventStatus EventStatus { get; set; } = null!;

    [ForeignKey("EventTypeId")]
    [InverseProperty("Events")]
    public virtual EventType EventType { get; set; } = null!;

    [InverseProperty("Event")]
    public virtual ICollection<TrainingClass> TrainingClasses { get; set; } = new List<TrainingClass>();
}
