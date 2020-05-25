using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Infrastructure
{
    /// <summary>
    /// Internal server result, contains 500 status code.
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error) :
            base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
