using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Canditate
{
    [Key]
    [Column("CanditateID")]
    public int CanditateId { get; set; }

    [StringLength(200)]
    public string FirstName { get; set; } = null!;

    [StringLength(200)]
    public string LastName { get; set; } = null!;

    public DateOnly ApplicationDate { get; set; }

    [StringLength(200)]
    public string Field { get; set; } = null!;

    public string Resume { get; set; } = null!;
}
