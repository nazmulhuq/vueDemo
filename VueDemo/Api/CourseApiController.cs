using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Data;
using VueDemo.Models;

namespace VueDemo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
        private readonly Context _context;
        public CourseApiController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Course> courses = _context.Courses
                .Include(c=>c.Teacher)
                .ToList();
           
            return Ok(courses);
        }
        [Route("/Api/CourseApi/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Course course = _context.Courses
                .Include(c=>c.Teacher)
                .Include(c=> c.Students)
                .Single(c=>c.Id == id);
            if (course != null)
                return Ok(course);
            else 
                return BadRequest();
        }

    }
}
