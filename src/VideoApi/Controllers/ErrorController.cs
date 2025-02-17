using Microsoft.AspNetCore.Mvc;

namespace VideoApi.Controllers;

[ApiController]
[Route("error")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public IActionResult HandleError()
    {
        return Problem("An unexpected error occurred. Please try again later.");
    }
}