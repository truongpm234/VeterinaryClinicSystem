using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class InventoryTransaction
{
    public int TransactionId { get; set; }

    public int? MedicationId { get; set; }

    public int? Quantity { get; set; }

    public string? Type { get; set; }

    public string? Note { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Medication? Medication { get; set; }
}
