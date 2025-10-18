using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[PrimaryKey("car_id", "service_id")]
[Index("car_id", "start_date", Name = "idx_appt_car_dt")]
[Index("service_id", "start_date", Name = "idx_appt_service_dt")]
public partial class appointment
{
    [Key]
    public long car_id { get; set; }

    [Key]
    public long service_id { get; set; }

    public DateTime start_date { get; set; }

    public DateTime? end_date { get; set; }

    [Precision(12, 2)]
    public decimal? labour_price { get; set; }

    [Precision(12, 2)]
    public decimal? material_price { get; set; }

    [ForeignKey("car_id")]
    [InverseProperty("appointments")]
    public virtual car car { get; set; } = null!;

    [ForeignKey("service_id")]
    [InverseProperty("appointments")]
    public virtual service service { get; set; } = null!;
}
