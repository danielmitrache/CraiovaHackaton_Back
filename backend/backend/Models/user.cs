using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("users")]
public partial class User
{
    [Key]
    public long id { get; set; }

    [Required]
    public string name { get; set; } = null!;

    [InverseProperty("owner")]
    public virtual ICollection<Car> cars { get; set; } = new List<Car>();

    [ForeignKey("id")]
    [InverseProperty("user")]
    public virtual Login idNavigation { get; set; } = null!;
}
