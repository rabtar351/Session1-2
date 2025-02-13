using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class EventType
{
    [Key]
    [Column("EventTypeID")]
    public int EventTypeId { get; set; }

    [StringLength(200)]
    public string EventTypeName { get; set; } = null!;

    [InverseProperty("EventType")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
