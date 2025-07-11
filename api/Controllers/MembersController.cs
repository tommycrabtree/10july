using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/[controller]")] // localhost:5001/api/members
[ApiController]
public class MembersController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AppUser>>> GetMembers()
    {
        var members = await context.Users.ToListAsync();

        return members;
    }

    [HttpGet("{id}")] // localhost:5001/api/members/joe-id
    public async Task<ActionResult<AppUser>> GetMember(string id)
    {
        var member = await context.Users.FindAsync(id);

        if (member == null) return NotFound();

        return member;
    }
}
