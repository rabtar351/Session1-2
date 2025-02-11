using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class EventStatus
{
    [Key]
    [Column("EventStatusID")]
    public int EventStatusId { get; set; }

    [StringLength(200)]
    public string EventStatusName { get; set; } = null!;

    [InverseProperty("EventStatus")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
