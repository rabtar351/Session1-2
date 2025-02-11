using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

[Table("User")]
public partial class User
{
    [Key]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(400)]
    public string Password { get; set; } = null!;
}
