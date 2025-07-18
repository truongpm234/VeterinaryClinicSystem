using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Pet
{
    public int PetId { get; set; }

    public int? OwnerId { get; set; }

    public string? Name { get; set; }

    public string? Species { get; set; }

    public string? Breed { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public decimal? Weight { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<CareSchedule> CareSchedules { get; set; } = new List<CareSchedule>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual User? Owner { get; set; }
}
