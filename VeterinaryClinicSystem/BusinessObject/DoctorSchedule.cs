using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class DoctorSchedule
{
    public int ScheduleId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? WorkDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public bool? IsAvailable { get; set; }

    public string? Note { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
