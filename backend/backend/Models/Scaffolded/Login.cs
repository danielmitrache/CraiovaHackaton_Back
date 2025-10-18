using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[Table("Login")]
[Index("email", Name = "Login_email_key", IsUnique = true)]
public partial class Login
{
    [Key]
    public long id { get; set; }

    public string password { get; set; } = null!;

    public string email { get; set; } = null!;

    public short account_type { get; set; }

    [InverseProperty("idNavigation")]
    public virtual Service? Service { get; set; }

    [InverseProperty("idNavigation")]
    public virtual User? User { get; set; }
}
