using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("users")]
public partial class user
{
    [Key]
    public long id { get; set; }

    [Required]
    public string name { get; set; } = null!;

    [InverseProperty("owner")]
    public virtual ICollection<car> cars { get; set; } = new List<car>();

    [ForeignKey("id")]
    [InverseProperty("user")]
    public virtual login idNavigation { get; set; } = null!;
}
