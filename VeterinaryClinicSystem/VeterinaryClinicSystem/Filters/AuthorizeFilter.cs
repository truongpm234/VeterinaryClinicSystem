using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace VeterinaryClinicSystem.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeFilter : Attribute, IPageFilter
    {
        private readonly string[] _roles;
        //[AuthorizeFilter("Admin")]
        //[AuthorizeFilter("Doctor", "Staff")]
        public AuthorizeFilter(params string[] roles)
        {
            _roles = roles;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context) { }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var httpContext = context.HttpContext;

            var role = httpContext.Session.GetString("Role");

            if (string.IsNullOrEmpty(role) || !_roles.Contains(role))
            {
                context.Result = new RedirectToPageResult("/AccessDenied");
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context) { }
    }
}
