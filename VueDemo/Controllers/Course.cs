using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.ViewModels;

namespace VueDemo.Controllers
{
    public class Course : Controller
    {
        [Authorize(Roles =Constants.Teacher)]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CourseList()
        {
            return View();
        }
        public IActionResult CourseDetails(int id)
        {

            ViewData["courseId"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeCourse(SubscribeCourseViewModel model)
        {

            throw new NotImplementedException();
        }
    }
}
