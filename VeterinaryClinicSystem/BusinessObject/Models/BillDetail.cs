using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class BillDetail
    {
        public List<(string MedicationName, decimal UnitPrice, int Amount, decimal Total)> Medications { get; set; } = new();
        public decimal MedicationTotal { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal Total => MedicationTotal + ServicePrice;
    }

}
