using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _facultyService;

    public FacultyController(IFacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [HttpGet]
    public ActionResult<List<Faculty>> GetFaculties()
    {
        var faculties = _facultyService.GetFaculties();
        return Ok(faculties);
    }

    [HttpGet("{id}")]
    public ActionResult<Faculty> GetFacultyById(int id)
    {
        var faculty = _facultyService.GetFacultyById(id);
        if (faculty == null)
        {
            return NotFound();
        }
        return Ok(faculty);
    }

    [HttpPost]
    public ActionResult<Faculty> CreateFaculty(Faculty faculty)
    {
        _facultyService.CreateFaculty(faculty);
        return Ok(faculty);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFaculty(int id, Faculty faculty)
    {
        var existFaculty = _facultyService.GetFacultyById(id);
        if (existFaculty == null)
        {
            return NotFound();
        }
        _facultyService.UpdateFaculty(id, faculty);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFaculty(int id)
    {
        var existFaculty = _facultyService.GetFacultyById(id);
        if (existFaculty == null)
        {
            return NotFound();
        }
        _facultyService.DeleteFaculty(id);
        return NoContent();
    }
}
