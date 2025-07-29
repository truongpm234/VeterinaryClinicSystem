using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PrescriptionDetailDAO
    {
        public static void AddPrescriptionDetails(List<PrescriptionDetail> items, int recordId)
        {
            using var context = new VeterinaryClinicSystemContext();

            foreach (var item in items)
            {
                item.RecordId = recordId;
                context.PrescriptionDetails.Add(item);
            }

            context.SaveChanges();
        }

    }
}