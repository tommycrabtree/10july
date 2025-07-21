using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class BuggyController : BaseApiController
{
    [HttpGet("auth")]
    public IActionResult GetAuth()
    {
        return Unauthorized();
    }

    [HttpGet("not-found")]
    public IActionResult GetNotFound()
    {
        return NotFound();
    }

    [HttpGet("server-error")]
    public IActionResult GetServerError()
    {
        throw new Exception("This is a server error, buddy");
    }

    [HttpGet("bad-request")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new { message = "You can make better requests" });
    }
}
