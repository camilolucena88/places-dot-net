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
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = context.Users.ToList();
        
        return Ok(users);
    }
    

}