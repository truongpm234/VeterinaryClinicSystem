using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class DoctorDashboard
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Reason { get; set; }
        public string ServiceName { get; set; } 
        public int? Shift { get; set; }
        public int MedicalRecordId { get; set; }
        public string Diagnosis { get; set; }
        public bool IsOngoingCase { get; set; }
    }
}