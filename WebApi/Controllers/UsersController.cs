using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(ApplicationDbContext context) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        
        return users;
    }

    [HttpGet("{id}")] 
    public async Task<ActionResult<User>> GetOneUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();
        
        return user;
    }

    [HttpPost] 
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOneUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        var existingUser = await context.Users.FindAsync(id);

        if (existingUser == null)
        {
            return NotFound(); // Return 404 Not Found if the user does not exist
        }

        // Update the existing user's properties
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        context.Entry(existingUser).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return Ok(existingUser);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0)
        {
            return BadRequest("0 is an invalid ID");
        }

        var employeeToDelete = await context.Users.FindAsync(id);

        if (employeeToDelete != null)
        {
            context.Users.Remove(employeeToDelete);
            await context.SaveChangesAsync();

            return Ok(); //Return 200 OK Status Code.
        }
        else
        {
            return NotFound($"No employee was found with the ID: {id}"); //Return 404 Status Code
        }
    }

}