using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]

    public decimal? Price { get; set; }

    public string? ServiceType { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
