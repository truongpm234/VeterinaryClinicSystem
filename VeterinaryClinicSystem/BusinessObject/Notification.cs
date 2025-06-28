using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UserId { get; set; }

    public int? AppointmentId { get; set; }

    public string? Content { get; set; }

    public DateTime? SentAt { get; set; }

    public string? Type { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual User? User { get; set; }
}
