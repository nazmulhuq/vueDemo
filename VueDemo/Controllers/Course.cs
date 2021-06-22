﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Controllers
{
    public class Course : Controller
    {
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
    }
}
