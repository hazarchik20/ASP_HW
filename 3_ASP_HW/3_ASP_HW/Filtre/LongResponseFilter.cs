using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace _3_ASP_HW.Filtre
{
    public class LongResponseFilter : Attribute ,IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult  )
            {
                var json = JsonSerializer.Serialize(objectResult.Value);

                if (json.Length > 200)
                {
                    context.Result = new BadRequestObjectResult(
                        $"Response too large. Max allowed size is {200} characters.");
                }
            }
            else if (context.Result is ContentResult contentResult)
            {
                if (contentResult.Content?.Length > 200)
                {
                    context.Result = new BadRequestObjectResult(
                        $"Response too large. Max allowed size is {200} characters.");
                }
            }
        }
    }
}
