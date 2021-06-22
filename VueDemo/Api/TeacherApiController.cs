using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class TeacherApiController : ControllerBase
    {
        private readonly Context _context;
        public TeacherApiController(Context context)
        {
            _context = context;
        }

        [Route("/Api/TeacherApi/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Teacher teacher = _context.Teachers.Find(id);
            if (teacher != null)
                return Ok(teacher);
            else
                return BadRequest();
        }
    }
}
