﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Infrastructure
{
    /// <summary>
    /// Forbidden result, contains 403 status code.
    /// </summary>
    public class ForbiddenObjectResult : ObjectResult
    {
        public ForbiddenObjectResult(object error) :
            base(error)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}
