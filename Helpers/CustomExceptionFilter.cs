using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeManagementSystem.Helpers
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider, IWebHostEnvironment webHostEnvironment)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            LogExceptionToFile(context.Exception);

            var result = new ViewResult { ViewName = "ErrorPage" };
            result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception object", context.Exception);

            context.ExceptionHandled = true;
            context.Result = result;
        }

        private void LogExceptionToFile(Exception exception)
        {
            var env = _webHostEnvironment.WebRootPath;
            string? logPath = env + "\\errorLog.txt";

            using (StreamWriter writer = new StreamWriter(logPath, true)) 
            {
                writer.WriteLine("-------------------------------------------------");
                writer.WriteLine($"{DateTime.Now}{exception.GetType().Name}: {exception.Message}");
                writer.WriteLine($"StackTrace: {exception.StackTrace}");
                writer.WriteLine();

            }
        }
    }
}
