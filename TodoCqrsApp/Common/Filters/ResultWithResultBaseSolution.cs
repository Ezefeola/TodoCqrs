using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoCqrsApp.Common.Result;

namespace TodoCqrsApp.Common.Filters
{
    public class ResultWithResultBaseSolution : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value is ResultBase result)
            {
                context.HttpContext.Response.StatusCode = (int)result.HttpStatusCode;
                context.Result = new JsonResult(result)
                {
                    StatusCode = (int)result.HttpStatusCode,
                    ContentType = "application/json"
                };
            }
            base.OnActionExecuted(context);
        }
    }
}