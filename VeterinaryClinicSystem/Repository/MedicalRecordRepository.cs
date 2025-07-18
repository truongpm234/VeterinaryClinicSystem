using BusinessObject.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        public BillDetail CalculateTotalBillForAppointment(int appointmentId) => MedicalRecordDAO.CalculateTotalBillForAppointment(appointmentId);
    }
}
