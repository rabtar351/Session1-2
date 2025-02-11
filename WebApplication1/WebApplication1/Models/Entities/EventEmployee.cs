using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class EventEmployee
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    [Column("EventEmployeeTypeID")]
    public int? EventEmployeeTypeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EventEmployees")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("EventEmployeeTypeId")]
    [InverseProperty("EventEmployees")]
    public virtual EventEmployeeType? EventEmployeeType { get; set; }
}
