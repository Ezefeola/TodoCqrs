using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TodoCqrsApp.Common.Filters
{
    public class ResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (objectResult.Value is IHasHttpStatusCode resultWithStatus)
                {
                    context.HttpContext.Response.StatusCode = (int)resultWithStatus.HttpStatusCode;
                    context.Result = new JsonResult(resultWithStatus)
                    {
                        StatusCode = (int)resultWithStatus.HttpStatusCode,
                        ContentType = "application/json"
                    };
                }
            }
            base.OnActionExecuted(context);
        }
    }

    public interface IHasHttpStatusCode
    {
        HttpStatusCode HttpStatusCode { get; }
    }
}