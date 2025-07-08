using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinicSystem.Repositories;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;
        public NotificationService(INotificationRepository repo) => _repo = repo;

        public Task<List<Notification>> GetPendingAsync(DateTime now)
            => _repo.GetPendingAsync(now);

        public Task AddAsync(Notification notif)
            => _repo.AddAsync(notif);

        public Task UpdateAsync(Notification notif)
            => _repo.UpdateAsync(notif);
    }
}
