using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class MaterialType
{
    [Key]
    [Column("MaterialTypeID")]
    public int MaterialTypeId { get; set; }

    [StringLength(200)]
    public string MaterialTypeName { get; set; } = null!;

    [InverseProperty("MaterialType")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
