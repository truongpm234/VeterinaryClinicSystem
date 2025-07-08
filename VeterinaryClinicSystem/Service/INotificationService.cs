using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface INotificationService
    {
        Task<List<Notification>> GetPendingAsync(DateTime now);
        Task AddAsync(Notification notif);
        Task UpdateAsync(Notification notif);
    }
}
