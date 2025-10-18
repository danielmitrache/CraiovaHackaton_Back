using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("login")]
[Index("email", Name = "login_email_key", IsUnique = true)]
public partial class login
{
    [Key]
    public long id { get; set; }

    [Required]
    public string password { get; set; } = null!;

    [Required]
    public string email { get; set; } = null!;

    [Column("account_type")]
    public AccountType account_type { get; set; }

    [InverseProperty("idNavigation")]
    public virtual service? service { get; set; }

    [InverseProperty("idNavigation")]
    public virtual user? user { get; set; }
}

