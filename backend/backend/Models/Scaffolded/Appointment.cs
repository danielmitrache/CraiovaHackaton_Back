using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Scaffolded;

[PrimaryKey("car_id", "service_id")]
[Index("car_id", "start_date", Name = "idx_appt_car_dt")]
[Index("service_id", "start_date", Name = "idx_appt_service_dt")]
public partial class Appointment
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
<<<<<<< HEAD:backend/backend/Models/Scaffolded/appointment.cs
    [InverseProperty("appointments")]
    public virtual Car car { get; set; } = null!;

    [ForeignKey("service_id")]
    [InverseProperty("appointments")]
=======
    [InverseProperty("Appointments")]
    public virtual Car car { get; set; } = null!;

    [ForeignKey("service_id")]
    [InverseProperty("Appointments")]
>>>>>>> origin/newMain:backend/backend/Models/Scaffolded/Appointment.cs
    public virtual Service service { get; set; } = null!;
}
