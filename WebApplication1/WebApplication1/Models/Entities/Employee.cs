using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(200)]
    public string FirstName { get; set; } = null!;

    [StringLength(200)]
    public string LastName { get; set; } = null!;

    [StringLength(200)]
    public string Patronymic { get; set; } = null!;

    [StringLength(20)]
    public string MobilePhone { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("PositionID")]
    public int? PositionId { get; set; }

    [Column("SupervisorID")]
    public int? SupervisorId { get; set; }

    [Column("AssistentID")]
    public int? AssistentId { get; set; }

    [StringLength(20)]
    public string? WorkPhone { get; set; }

    [StringLength(254)]
    public string? Email { get; set; }

    [StringLength(10)]
    public string? Office { get; set; }

    public string? AdditionalInfo { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Absence> AbsenceEmployees { get; set; } = new List<Absence>();

    [InverseProperty("Sustitutel")]
    public virtual ICollection<Absence> AbsenceSustitutels { get; set; } = new List<Absence>();

    [InverseProperty("Employee")]
    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    [InverseProperty("Author")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Manager")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("Employee")]
    public virtual ICollection<EventEmployee> EventEmployees { get; set; } = new List<EventEmployee>();

    [ForeignKey("PositionId")]
    [InverseProperty("Employees")]
    public virtual Position? Position { get; set; }
}
