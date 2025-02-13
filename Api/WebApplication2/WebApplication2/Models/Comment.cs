using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class Comment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DocumentID")]
    public int DocumentId { get; set; }

    [StringLength(200)]
    public string Text { get; set; } = null!;

    [Column("Date_Created")]
    public DateOnly DateCreated { get; set; }

    [Column("Date_Updated")]
    public DateOnly DateUpdated { get; set; }

    [Column("AuthorID")]
    public int AuthorId { get; set; }

    [StringLength(300)]
    public string? Position { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Comments")]
    public virtual Employee Author { get; set; } = null!;

    [ForeignKey("DocumentId")]
    [InverseProperty("Comments")]
    public virtual Document Document { get; set; } = null!;
}
