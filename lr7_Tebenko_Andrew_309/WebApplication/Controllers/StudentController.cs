using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public ActionResult<List<Student>> GetStudents()
    {
        var students = _studentService.GetStudents();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetByStudentId(int id)
    {
        var student = _studentService.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> CreateStudent(Student student)
    {
        _studentService.CreateStudent(student);
        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        var existStudent = _studentService.GetStudentById(id);
        if (existStudent == null)
        {
            return NotFound();
        }
        _studentService.UpdateStudent(id, student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var existStudent = _studentService.GetStudentById(id);
        if (existStudent == null)
        {
            return NotFound();
        }
        _studentService.DeleteStudent(id);
        return NoContent();
    }
}
