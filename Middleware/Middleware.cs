using Newtonsoft.Json;
using EmployeeManagementSystem.Models;
using System.Security.Principal;

namespace EmployeeManagementSystem.Middleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _context;
        public Middleware(RequestDelegate next, IHttpContextAccessor context)
        {
            _next = next;
            _context = context;
        }

        public async Task Invoke(HttpContext ctx)
        {
            var cookie = ctx.Request.Cookies["User"];

            if (!string.IsNullOrEmpty(cookie))
            {
                var loggedInUser = JsonConvert.DeserializeObject<User>(cookie);

                var user = new LoggedInUser();
                user.Name = loggedInUser.Employee.FirstName;
                user.IsAuthenticated = true;
                //user.DepartmentName = loggedInUser.Employee.Department.Name;

                string[]? roles = { "Admin", "User" };
                
                
                var currentUser = new GenericPrincipal(user, roles);

                _context!.HttpContext!.User = currentUser;
            }

            await _next(ctx);
        }
    }
}
