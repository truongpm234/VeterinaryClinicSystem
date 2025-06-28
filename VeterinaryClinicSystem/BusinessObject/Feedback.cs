using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? AppointmentId { get; set; }

    public int? CustomerId { get; set; }

    public int? DoctorId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
