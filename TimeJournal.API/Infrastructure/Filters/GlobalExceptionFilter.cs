using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TimeJournal.Repositories.Exceptions;

namespace TimeJournal.API.Infrastructure.Filters;

public class GlobalExceptionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null) return;

        context.Result = HandleException(context.Exception);
        context.ExceptionHandled = true;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    private static ActionResult HandleException(Exception exception)
    {
        return exception switch
        {
            ObjectNotFoundException => new NotFoundObjectResult(exception.Message),
            _ => new ObjectResult("Unexpected error occurred") { StatusCode = StatusCodes.Status500InternalServerError }
        };
    }
}
