using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinicSystem
{
    public class CreateAppointmentDto
    {
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string DoctorName { get; set; }
    }
}
