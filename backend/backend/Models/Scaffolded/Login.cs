using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

<<<<<<< HEAD:backend/backend/Models/Scaffolded/login.cs
[Table("login")]
[Index("email", Name = "login_email_key", IsUnique = true)]
=======
[Table("Login")]
[Index("email", Name = "Login_email_key", IsUnique = true)]
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/Login.cs
public partial class Login
{
    [Key]
    public long id { get; set; }

    public string password { get; set; } = null!;

    public string email { get; set; } = null!;

<<<<<<< HEAD:backend/backend/Models/Scaffolded/login.cs
    [InverseProperty("idNavigation")]
    public virtual Service? service { get; set; }

    [InverseProperty("idNavigation")]
    public virtual User? user { get; set; }
=======
    public short account_type { get; set; }

    [InverseProperty("idNavigation")]
    public virtual Service? Service { get; set; }

    [InverseProperty("idNavigation")]
    public virtual User? User { get; set; }
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/Login.cs
}
