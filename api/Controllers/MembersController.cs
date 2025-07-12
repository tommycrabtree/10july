using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class MembersController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<AppUser>>> GetMembers()
    {
        var members = await context.Users.ToListAsync();

        return members;
    }

    [Authorize]
    [HttpGet("{id}")] // localhost:5001/api/members/joe-id
    public async Task<ActionResult<AppUser>> GetMember(string id)
    {
        var member = await context.Users.FindAsync(id);

        if (member == null) return NotFound();

        return member;
    }
}
