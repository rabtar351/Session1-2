using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class Material
{
    [Key]
    [Column("MaterialID")]
    public int MaterialId { get; set; }

    [StringLength(200)]
    public string MaterialName { get; set; } = null!;

    public DateOnly ApprovalDate { get; set; }

    public DateOnly ModificationDate { get; set; }

    [Column("MaterialStatusID")]
    public int MaterialStatusId { get; set; }

    [Column("MaterialTypeID")]
    public int MaterialTypeId { get; set; }

    [StringLength(200)]
    public string Domain { get; set; } = null!;

    [StringLength(200)]
    public string Author { get; set; } = null!;

    [ForeignKey("MaterialStatusId")]
    [InverseProperty("Materials")]
    public virtual MaterialStatus MaterialStatus { get; set; } = null!;

    [ForeignKey("MaterialTypeId")]
    [InverseProperty("Materials")]
    public virtual MaterialType MaterialType { get; set; } = null!;

    [InverseProperty("Material")]
    public virtual ICollection<TrainingClass> TrainingClasses { get; set; } = new List<TrainingClass>();
}
