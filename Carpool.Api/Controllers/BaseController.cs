﻿using Carpool.BLL.Common;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Carpool.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ProblemDetails(List<IError> validationError)
        {
            var error = validationError[0];

            error.Metadata.TryGetValue(Constants.ErrorType, out var errorType);

            var responseStatusCode = errorType switch
            {
                ErrorType.NotFound => (int)HttpStatusCode.NotFound,
                ErrorType.Validation => (int)HttpStatusCode.BadRequest,
                ErrorType.Conflit => (int)HttpStatusCode.Conflict,
                ErrorType.BadGateway => (int)HttpStatusCode.BadGateway,
                _ => (int)HttpStatusCode.InternalServerError
            };

            return Problem(statusCode: responseStatusCode, title: error.Message);
        }
    }
}
