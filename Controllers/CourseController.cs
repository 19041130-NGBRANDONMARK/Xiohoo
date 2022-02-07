using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson05.Models;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson05.Controllers
{
    public class CourseController : Controller
    {
        private AppDbContext _dbContext;

        public CourseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Attendance()
        {
            List<CourseController> model = DBUtl.GetList<CourseController>(@"SELECT * FROM CourseAttendance");
            return View(model);
        }
    }
}
