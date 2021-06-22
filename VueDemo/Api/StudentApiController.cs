using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Data;

namespace VueDemo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly Context _context;
        public StudentApiController(Context context)
        {
            _context = context;
        }
        [Route("/Api/StudentApi/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
                return Ok(student);
            else
                return BadRequest();
        }
    }
}
