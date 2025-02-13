using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class TrainingClass
{
    [Key]
    [Column("TrainingID")]
    public int TrainingId { get; set; }

    [Column("EventID")]
    public int EventId { get; set; }

    [Column("MaterialID")]
    public int MaterialId { get; set; }

    public string? TrainingDescription { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("TrainingClasses")]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey("MaterialId")]
    [InverseProperty("TrainingClasses")]
    public virtual Material Material { get; set; } = null!;
}
