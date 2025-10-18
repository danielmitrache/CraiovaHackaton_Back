using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("city")]
[Index("name", Name = "city_name_key", IsUnique = true)]
public partial class city
{
    [Key]
    public long id { get; set; }

    [Required]
    public string name { get; set; } = null!;

    [InverseProperty("city")]
    public virtual ICollection<service> services { get; set; } = new List<service>();
}

