using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;

namespace VeterinaryClinicSystem.Pages.Customers
{
    public class FeedbackModel : PageModel
    {
        private readonly VeterinaryClinicSystemContext _context;

        public FeedbackModel(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Feedback Input { get; set; } = new Feedback();

        public List<User> Doctors { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();


        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("Account");
            if (userId == null) return;

            Doctors = _context.Users
                .Where(u => u.RoleId == 3 && u.IsActive)
                .ToList();

            Appointments = _context.Appointments
            .Include(a => a.Doctor).ThenInclude(d => d.DoctorNavigation)
             .Where(a => a.OwnerId == userId && a.Status == "Completed") // Sửa từ CustomerId -> OwnerId
            .ToList();

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            var userId = HttpContext.Session.GetInt32("Account");
            if (userId == null)
                return RedirectToPage("/Authentication/Login");

            Input.CustomerId = userId;
            Input.CreatedAt = DateTime.Now;

            _context.Feedbacks.Add(Input);
            _context.SaveChanges();


            return RedirectToPage("/index");
        }
    }
}
