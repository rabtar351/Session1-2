using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Comment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Document_Id")]
    public int DocumentId { get; set; }

    [StringLength(200)]
    public string Text { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [Column("AuthorID")]
    public int AuthorId { get; set; }

    [StringLength(200)]
    public string Position { get; set; } = null!;

    [ForeignKey("AuthorId")]
    [InverseProperty("Comments")]
    public virtual Employee Author { get; set; } = null!;

    [ForeignKey("DocumentId")]
    [InverseProperty("Comments")]
    public virtual Document Document { get; set; } = null!;
}
