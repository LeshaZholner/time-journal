using Microsoft.AspNetCore.Mvc.Filters;

namespace TimeJournal.API.Infrastructure.Filters;

public class GlobalExceptionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}
