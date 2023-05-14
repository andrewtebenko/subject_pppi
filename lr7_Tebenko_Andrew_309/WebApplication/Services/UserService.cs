using WebApplication.Models;

namespace WebApplication.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> CreateUser(User user);
    Task UpdateUser(int id, User user);
    Task DeleteUser(int id);
}

public class UserService : IUserService
{
    private readonly List<User> _users = new()
    {
        new()
        {
            Id = 1, Name = "John Doe", Email = "johndoe@example.com", Password = "123456"
        },
        new()
        {
            Id = 2, Name = "Jane Smith", Email = "janesmith@example.com", Password = "654321"
        },
        new()
        {
            Id = 3, Name = "Bob Johnson", Email = "bobjohnson@example.com", Password = "qwerty"
        }
    };
    
    public async Task<List<User>> GetAllUsers()
    {
        return await Task.FromResult(_users);
    }

    public async Task<User> GetUserById(int id)
    {
        return await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }

    public async Task<User> CreateUser(User user)
    {
        user.Id = _users.Max(u => u.Id) + 1;
        _users.Add(user);
        return await Task.FromResult(user);
    }

    public async Task UpdateUser(int id, User user)
    {
        var existingUser = await GetUserById(id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
        }
    }

    public async Task DeleteUser(int id)
    {
        var existingUser = await GetUserById(id);
        if (existingUser != null)
        {
            _users.Remove(existingUser);
        }
    }
}

