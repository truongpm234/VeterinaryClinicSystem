using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinicSystem.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationDAO _dao;
        public NotificationRepository(NotificationDAO dao) => _dao = dao;

        public Task<List<Notification>> GetPendingAsync(DateTime now)
            => _dao.GetPendingAsync(now);

        public Task AddAsync(Notification notif)
            => _dao.AddAsync(notif);

        public Task UpdateAsync(Notification notif)
            => _dao.UpdateAsync(notif);
    }
}
