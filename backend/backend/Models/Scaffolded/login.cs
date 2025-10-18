using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[Table("login")]
[Index("email", Name = "login_email_key", IsUnique = true)]
public partial class login
{
    [Key]
    public long id { get; set; }

    public string password { get; set; } = null!;

    public string email { get; set; } = null!;

    [InverseProperty("idNavigation")]
    public virtual service? service { get; set; }

    [InverseProperty("idNavigation")]
    public virtual user? user { get; set; }
}
