using WebApplication.Models;

namespace WebApplication.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFacultyService
{
    Task<List<Faculty>> GetFaculties();
    Task<Faculty> GetFacultyById(int id);
    Task<Faculty> CreateFaculty(Faculty faculty);
    Task UpdateFaculty(int id, Faculty faculty);
    Task DeleteFaculty(int id);
}

public class FacultyService : IFacultyService
{
    private readonly List<Faculty> _faculties = new()
    {
        new()
        {
            Id = 1, Name="Faculty of Engineering", Head = "John Smith"
        },
        new()
        {
            Id = 2, Name = "Faculty of Humanities", Head = "Sarah Johnson"
        },
        new()
        {
            Id = 3, Name = "Faculty of Business", Head = "David Lee"
        },
        new()
        {
            Id = 4, Name = "Faculty of Medicine", Head = "Elizabeth Brown"
        }
    };
    
    public async Task<List<Faculty>> GetFaculties()
    {
        return await Task.FromResult(_faculties);
    }

    public async Task<Faculty> GetFacultyById(int id)
    {
        return await Task.FromResult(_faculties.FirstOrDefault(u => u.Id == id));
    }

    public async Task<Faculty> CreateFaculty(Faculty faculty)
    {
        faculty.Id = _faculties.Max(u => u.Id) + 1;
        _faculties.Add(faculty);
        return await Task.FromResult(faculty);
    }

    public async Task UpdateFaculty(int id, Faculty faculty)
    {
        var existingParking = await GetFacultyById(id);
        if (existingParking != null)
        {
            existingParking.Name = faculty.Name;
            existingParking.Head = faculty.Head;
        }
    }

    public async Task DeleteFaculty(int id)
    {
        var existingParking = await GetFacultyById(id);
        if (existingParking != null)
        {
            _faculties.Remove(existingParking);
        }
    }
}

