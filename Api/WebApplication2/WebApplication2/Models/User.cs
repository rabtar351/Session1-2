using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class User
{
    [Key]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(300)]
    public string Password { get; set; } = null!;
}
