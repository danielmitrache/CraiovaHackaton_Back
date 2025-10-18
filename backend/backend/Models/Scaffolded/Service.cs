using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[Index("cui", Name = "Services_cui_key", IsUnique = true)]
[Index("city_id", Name = "idx_services_city")]
<<<<<<< HEAD:backend/backend/Models/Scaffolded/service.cs
[Index("cui", Name = "services_cui_key", IsUnique = true)]
=======
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/Service.cs
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
<<<<<<< HEAD:backend/backend/Models/Scaffolded/service.cs
    public virtual ICollection<Appointment> appointments { get; set; } = new List<Appointment>();

    [ForeignKey("city_id")]
    [InverseProperty("services")]
    public virtual City? city { get; set; }

    [ForeignKey("id")]
    [InverseProperty("service")]
=======
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("city_id")]
    [InverseProperty("Services")]
    public virtual City? city { get; set; }

    [ForeignKey("id")]
    [InverseProperty("Service")]
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/Service.cs
    public virtual Login idNavigation { get; set; } = null!;
}
