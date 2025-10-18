using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("cars")]
[Index("owner_id", Name = "idx_cars_owner")]
public partial class Car
{
    [Key]
    public long id { get; set; }

    [Required]
    public string brand { get; set; } = null!;

    [Required]
    public string model { get; set; } = null!;

    public string? motorisation { get; set; }

    public int? year { get; set; }

    [Required]
    public long owner_id { get; set; }

    [InverseProperty("car")]
    public virtual ICollection<Appointment> appointments { get; set; } = new List<Appointment>();

    [ForeignKey("owner_id")]
    [InverseProperty("cars")]
    public virtual User owner { get; set; } = null!;
}