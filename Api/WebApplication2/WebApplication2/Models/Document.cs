using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Document
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Column("Date_Created")]
    public DateOnly DateCreated { get; set; }

    [Column("Date_Updated")]
    public DateOnly DateUpdated { get; set; }

    [StringLength(200)]
    public string Category { get; set; } = null!;

    [Column("Has_Comment")]
    public bool HasComment { get; set; }

    [InverseProperty("Document")]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
