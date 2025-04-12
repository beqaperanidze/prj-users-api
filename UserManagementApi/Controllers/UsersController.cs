using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Data;
using UserManagementApi.Models;

namespace UserManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class UsersController(ApplicationDbContext context) : ControllerBase
{


    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return context.Users.ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges(); 

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest(); 
        }

        context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        try
        {
            context.SaveChanges();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }

        context.Users.Remove(user);
        context.SaveChanges();

        return NoContent(); 
    }

    private bool UserExists(int id)
    {
        return context.Users.Any(e => e.Id == id);
    }
}