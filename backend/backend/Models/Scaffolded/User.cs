using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

public partial class User
{
    [Key]
    public long id { get; set; }

    public string name { get; set; } = null!;

    [InverseProperty("owner")]
    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    [ForeignKey("id")]
    [InverseProperty("User")]
    public virtual Login idNavigation { get; set; } = null!;
}
