using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinicSystem
{
    public class CreateAppointmentDto
    {
        public int DoctorId { get; set; }
        public string DoctorEmail { get; set; }
        public int OwnerId { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
