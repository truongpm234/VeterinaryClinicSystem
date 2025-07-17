using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? PetId { get; set; }

    public int? DoctorId { get; set; }

    public int? AppointmentId { get; set; }

    public string? Diagnosis { get; set; }

    public string? MedicationDetails { get; set; }

    public DateOnly? FollowUpDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsFollow { get; set; }

    public int? Amount { get; set; }

    public int? MedicationId { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Medication? Medication { get; set; }

    public virtual Pet? Pet { get; set; }
}
