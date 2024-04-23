using Infrastructure.Contexts;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _context.Courses
            .Include(i => i.Category)
            .OrderByDescending(o => o.LastUpdated)
            .ToListAsync();

        return Ok(CourseFactory.Create(courses));
    }
}
