using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

public partial class MaterialStatus
{
    [Key]
    [Column("MaterialStatusID")]
    public int MaterialStatusId { get; set; }

    [StringLength(200)]
    public string MaterialStatusName { get; set; } = null!;

    [InverseProperty("MaterialStatus")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
