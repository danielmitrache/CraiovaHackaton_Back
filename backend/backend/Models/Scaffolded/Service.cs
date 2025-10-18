using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[Table("Services")]
[Index("city_id", Name = "idx_services_city")]
[Index("cui", Name = "services_cui_key", IsUnique = true)]
public partial class Service
{
    [Key]
    public long id { get; set; }

    public string name { get; set; } = null!;

    public int? nr_employees { get; set; }

    public string? description { get; set; }

    public string? cui { get; set; }

    public string? address { get; set; }

    public long? city_id { get; set; }

    public bool? can_itp { get; set; }

    [InverseProperty("service")]
    public virtual ICollection<Appointment> appointments { get; set; } = new List<Appointment>();

    [ForeignKey("city_id")]
    [InverseProperty("services")]
    public virtual City? city { get; set; }

    [ForeignKey("id")]
    [InverseProperty("service")]
    public virtual Login idNavigation { get; set; } = null!;
}
