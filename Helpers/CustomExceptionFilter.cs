using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSystem.Helpers
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "ErrorPage" };

            context.ExceptionHandled = true;
            context.Result = result;
        }

    }
}
