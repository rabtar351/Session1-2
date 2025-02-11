using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Absence
{
    [Key]
    [Column("AbsencesID")]
    public int AbsencesId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Column("SustitutelID")]
    public int SustitutelId { get; set; }

    [StringLength(200)]
    public string? Reason { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("AbsenceEmployees")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("SustitutelId")]
    [InverseProperty("AbsenceSustitutels")]
    public virtual Employee Sustitutel { get; set; } = null!;
}
