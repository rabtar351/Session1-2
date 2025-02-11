using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Position
{
    [Key]
    [Column("PositionID")]
    public int PositionId { get; set; }

    [StringLength(200)]
    public string PositionName { get; set; } = null!;

    [InverseProperty("Position")]
    public virtual ICollection<DeparmtentPosition> DeparmtentPositions { get; set; } = new List<DeparmtentPosition>();

    [InverseProperty("Position")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
