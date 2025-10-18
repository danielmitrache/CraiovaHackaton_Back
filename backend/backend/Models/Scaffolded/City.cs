using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

<<<<<<< HEAD:backend/backend/Models/Scaffolded/city.cs
[Table("city")]
[Index("name", Name = "city_name_key", IsUnique = true)]
=======
[Table("City")]
[Index("name", Name = "City_name_key", IsUnique = true)]
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/City.cs
public partial class City
{
    [Key]
    public long id { get; set; }

    public string name { get; set; } = null!;

    [InverseProperty("city")]
<<<<<<< HEAD:backend/backend/Models/Scaffolded/city.cs
    public virtual ICollection<Service> services { get; set; } = new List<Service>();
=======
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/City.cs
}
