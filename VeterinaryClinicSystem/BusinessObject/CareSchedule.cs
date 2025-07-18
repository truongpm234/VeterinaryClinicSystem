using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class CareSchedule
{
    public int ScheduleId { get; set; }

    public int PetId { get; set; }

    public string CareType { get; set; } = null!;

    public DateOnly InitialDate { get; set; }

    public DateOnly? NextDueDate { get; set; }

    public bool? IsCompleted { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Pet Pet { get; set; } = null!;
}
