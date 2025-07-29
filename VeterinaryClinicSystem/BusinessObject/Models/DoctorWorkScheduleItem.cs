using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class DoctorWorkScheduleItem
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ServiceName { get; set; }
        public int Shift { get; set; }
        public string Note { get; set; }
    }
}
