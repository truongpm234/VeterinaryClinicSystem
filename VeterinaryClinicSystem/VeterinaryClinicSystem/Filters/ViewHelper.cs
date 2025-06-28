namespace VeterinaryClinicSystem.Filters
{
    public static class RoleHelper
    {
        public static bool HasRole(this HttpContext context, string role)
        {
            return context.Session.GetString("Role") == role;
        }

        public static bool InRoles(this HttpContext context, params string[] roles)
        {
            var userRole = context.Session.GetString("Role");
            return roles.Contains(userRole);
        }
    }
}

//@inject IHttpContextAccessor HttpContextAccessor
//@{
//    var ctx = HttpContextAccessor.HttpContext;
//}

//@if(ctx.InRoles("Admin", "Manager"))
//{
//    < button > Thống kê doanh thu </ button >
//}

