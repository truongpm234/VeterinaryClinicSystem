using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinicSystem.Repositories
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetPendingAsync(DateTime now);
        Task AddAsync(Notification notif);
        Task UpdateAsync(Notification notif);
    }
}