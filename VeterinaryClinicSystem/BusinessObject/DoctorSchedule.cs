using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class DoctorSchedule
{
    public int ScheduleId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? WorkDate { get; set; }

    public string? Note { get; set; }

    public int? Shift { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
