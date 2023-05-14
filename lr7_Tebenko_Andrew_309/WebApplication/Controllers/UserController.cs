using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        _userService.CreateUser(user);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
        {
            return NotFound();
        }
        _userService.UpdateUser(id, user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
        {
            return NotFound();
        }
        _userService.DeleteUser(id);
        return NoContent();
    }
}
