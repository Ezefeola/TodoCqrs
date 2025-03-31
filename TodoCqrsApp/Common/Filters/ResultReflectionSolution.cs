using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Reflection;
using TodoCqrsApp.Common.Result;

namespace TodoCqrsApp.Common.Filters
{
    public class ResultReflectionSolution : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var valueType = objectResult.Value.GetType();
                if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var httpStatusProperty = valueType.GetProperty("HttpStatusCode", BindingFlags.Public | BindingFlags.Instance);
                    if (httpStatusProperty != null && httpStatusProperty.PropertyType == typeof(HttpStatusCode))
                    {
                        var statusCode = httpStatusProperty.GetValue(objectResult.Value);
                        context.HttpContext.Response.StatusCode = (int)statusCode!;
                        context.Result = new JsonResult(objectResult.Value)
                        {
                            StatusCode = (int)statusCode,
                            ContentType = "application/json"
                        };
                    }
                }
            }
            base.OnActionExecuted(context);
        }
    }
}