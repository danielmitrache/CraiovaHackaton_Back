using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("appointment")]
public partial class appointment
{
    [Key]
    [Column(Order = 0)]
    public long car_id { get; set; }

    [Key]
    [Column(Order = 1)]
    public long service_id { get; set; }

    [Required]
    public DateTime start_date { get; set; }

    public DateTime? end_date { get; set; }

    [Column(TypeName = "numeric(12,2)")]
    public decimal? labour_price { get; set; }

    [Column(TypeName = "numeric(12,2)")]
    public decimal? material_price { get; set; }

    [ForeignKey("car_id")]
    [InverseProperty("appointments")]
    public virtual car car { get; set; } = null!;

    [ForeignKey("service_id")]
    [InverseProperty("appointments")]
    public virtual service service { get; set; } = null!;
}

