using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Medication
{
    public int MedicationId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Unit { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}
