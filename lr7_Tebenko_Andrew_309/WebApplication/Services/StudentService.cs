using WebApplication.Models;

namespace WebApplication.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentService
{
    Task<List<Student>> GetStudents();
    Task<Student> GetStudentById(int id);
    Task<Student> CreateStudent(Student student);
    Task UpdateStudent(int id, Student student);
    Task DeleteStudent(int id);
}

public class StudentService : IStudentService
{
    private readonly List<Student> _students = new()
    {
        new()
        {
            Id = 1, Name = "Andrey", Surname = "Tebenko"
        },
        new()
        {
            Id = 2, Name = "Ava", Surname = "Thompson"
        },        
        new()
        {
            Id = 3, Name = "Ethan", Surname = "Davis"
        },
        new()
        {
            Id = 4, Name = "Chloe", Surname = "Lee"
        },
        new()
        {
            Id = 5, Name = "Mason", Surname = "Rodriguez"
        }
    };
    
    public async Task<List<Student>> GetStudents()
    {
        return await Task.FromResult(_students);
    }

    public async Task<Student> GetStudentById(int id)
    {
        return await Task.FromResult(_students.FirstOrDefault(u => u.Id == id));
    }

    public async Task<Student> CreateStudent(Student student)
    {
        student.Id = _students.Max(u => u.Id) + 1;
        _students.Add(student);
        return await Task.FromResult(student);
    }

    public async Task UpdateStudent(int id, Student student)
    {
        var existStudent = await GetStudentById(id);
        if (existStudent != null)
        {
            existStudent.Name = student.Name;
            existStudent.Surname = student.Surname;
        }
    }

    public async Task DeleteStudent(int id)
    {
        var existStudent = await GetStudentById(id);
        if (existStudent != null)
        {
            _students.Remove(existStudent);
        }
    }
}

