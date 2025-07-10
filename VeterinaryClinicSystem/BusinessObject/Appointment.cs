using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PetId { get; set; }

    public int? OwnerId { get; set; }

    public int? DoctorId { get; set; }

    public int? ScheduleId { get; set; }

    public int? ServiceId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual User? Owner { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual DoctorSchedule? Schedule { get; set; }

    public virtual Service? Service { get; set; }
}
