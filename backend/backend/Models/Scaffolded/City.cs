using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[Table("City")]
[Index("name", Name = "city_name_key", IsUnique = true)]
public partial class City
{
    [Key]
    public long id { get; set; }

    public string name { get; set; } = null!;

    [InverseProperty("city")]
    public virtual ICollection<Service> services { get; set; } = new List<Service>();
}
