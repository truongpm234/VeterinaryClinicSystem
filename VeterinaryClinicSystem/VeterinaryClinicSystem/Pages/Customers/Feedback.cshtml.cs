using BusinessObject;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VeterinaryClinicSystem.Pages.Customers
{



    [Authorize(Roles = "Customer")]
    public class FeedbackModel : PageModel
    {
        private readonly VeterinaryClinicSystemContext _context;

        public FeedbackModel(VeterinaryClinicSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Feedback Input { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Input.CreatedAt = DateTime.Now;
            Input.CustomerId = GetCustomerId(); // t? vi?t hàm này n?u c?n
            _context.Feedbacks.Add(Input);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }

        private int GetCustomerId()
        {
            var userIdClaim = User.FindFirst("UserID");
            if (userIdClaim == null)
            {
                throw new Exception("UserID claim not found.");
            }
            return int.Parse(userIdClaim.Value);
        }

    }
}
