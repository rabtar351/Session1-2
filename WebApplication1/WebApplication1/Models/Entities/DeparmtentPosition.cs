using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

[PrimaryKey("DepartmentId", "PositionId")]
public partial class DeparmtentPosition
{
    [Key]
    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [Key]
    [Column("PositionID")]
    public int PositionId { get; set; }

    public bool IsPrimary { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("DeparmtentPositions")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("PositionId")]
    [InverseProperty("DeparmtentPositions")]
    public virtual Position Position { get; set; } = null!;
}
