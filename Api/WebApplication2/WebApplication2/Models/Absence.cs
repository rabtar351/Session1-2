using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Absence
{
    [Key]
    [Column("AbsenceID")]
    public int AbsenceId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Column("SubstitutelID")]
    public int SubstitutelId { get; set; }

    public string Reason { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("AbsenceEmployees")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("SubstitutelId")]
    [InverseProperty("AbsenceSubstitutels")]
    public virtual Employee Substitutel { get; set; } = null!;
}
