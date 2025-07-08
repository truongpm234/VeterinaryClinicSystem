using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NotificationDAO
    {
        private readonly VeterinaryClinicSystemContext _context;

        public NotificationDAO(VeterinaryClinicSystemContext context)
            => _context = context;

        public async Task<List<Notification>> GetPendingAsync(DateTime now)
        {
            return await _context.Notifications
                .Include(n => n.Appointment).ThenInclude(a => a.Owner)
                .Where(n => !n.SentAt.HasValue && n.Appointment.AppointmentDate <= now)
                .ToListAsync();
        }

        public async Task AddAsync(Notification notif)
        {
            await _context.Notifications.AddAsync(notif);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification notif)
        {
            _context.Notifications.Update(notif);
            await _context.SaveChangesAsync();
        }

        public async Task<Notification> GetByIdAsync(int id)
            => await _context.Notifications.FindAsync(id);
    }
}