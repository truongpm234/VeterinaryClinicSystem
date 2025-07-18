using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class PrescriptionDetail
{
    public int PrescriptionId { get; set; }

    public int RecordId { get; set; }

    public int MedicationId { get; set; }

    public int Amount { get; set; }

    public string? Dosage { get; set; }

    public string? Instructions { get; set; }

    public virtual Medication Medication { get; set; } = null!;

    public virtual MedicalRecord Record { get; set; } = null!;
}
