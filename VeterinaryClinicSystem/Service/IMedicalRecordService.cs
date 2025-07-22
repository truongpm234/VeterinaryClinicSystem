using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMedicalRecordService
    {
        public BillDetail CalculateTotalBillForAppointment(int appointmentId);
    }
}