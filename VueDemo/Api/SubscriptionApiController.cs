using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Data;
using VueDemo.ViewModels;

namespace VueDemo.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionApiController : ControllerBase
    {
        private readonly Context _context;
        public SubscriptionApiController(Context context)
        {
            _context = context;
        }

        //[Route("/Api/SubscriptionApi/{id}")]
        [HttpPost]
        [Authorize(Roles =Constants.Student)]
        public IActionResult Subscribe(SubscribeCourseViewModel model)
        {
            var id = model.CourseId;
            throw new NotImplementedException();
        }
    }
}
