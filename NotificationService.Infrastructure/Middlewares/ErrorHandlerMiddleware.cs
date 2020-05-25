using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure
{
    /// <summary>
    /// Represents Error handling middleware. Used to process error's user messages.
    /// </summary>
    public sealed class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IActionResultExecutor<ObjectResult> _actionResultExecutor;

        public ErrorHandlerMiddleware(RequestDelegate next,
            IActionResultExecutor<ObjectResult> actionResultExecutor)
        {
            _next = next;
            _actionResultExecutor = actionResultExecutor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (InvalidDataException ex)
            {
                await SendResponseAsync(context, new BadRequestObjectResult(ex.Message));
            }
            catch (InvalidPermissionException ex)
            {
                await SendResponseAsync(context, new ForbiddenObjectResult(ex.Message));
            }
            catch (NotFoundException ex)
            {
                await SendResponseAsync(context, new NotFoundObjectResult(ex.Message));
            }
            catch (Exception ex)
            {
                await SendResponseAsync(context, new InternalServerErrorObjectResult(ex.Message));
            }
        }

        /// <summary>
        /// Executes passed action result.
        /// </summary>
        /// <param name="context">HttpContext of current request.</param>
        /// <param name="objectResult">Instance of ObjectResult implementation, contains error data.</param>
        private Task SendResponseAsync(HttpContext context, ObjectResult objectResult) =>
                _actionResultExecutor.ExecuteAsync(new ActionContext() { HttpContext = context }, objectResult);
    }
}
