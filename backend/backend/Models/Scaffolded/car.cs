using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[Index("owner_id", Name = "idx_cars_owner")]
public partial class car
{
    [Key]
    public long id { get; set; }

    public string brand { get; set; } = null!;

    public string model { get; set; } = null!;

    public string? motorisation { get; set; }

    public int? year { get; set; }

    public long owner_id { get; set; }

    [InverseProperty("car")]
    public virtual ICollection<appointment> appointments { get; set; } = new List<appointment>();

    [ForeignKey("owner_id")]
    [InverseProperty("cars")]
    public virtual user owner { get; set; } = null!;
}
