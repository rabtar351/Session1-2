using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Department
{
    [Key]
    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [StringLength(200)]
    public string DepartmentName { get; set; } = null!;

    public string? Description { get; set; }

    [Column("ManagerID")]
    public int? ManagerId { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    [InverseProperty("Department")]
    public virtual ICollection<DeparmtentPosition> DeparmtentPositions { get; set; } = new List<DeparmtentPosition>();

    [InverseProperty("Department")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("ManagerId")]
    [InverseProperty("Departments")]
    public virtual Employee? Manager { get; set; }
}
