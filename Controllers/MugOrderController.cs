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


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson05.Controllers
{
    public class MugOrderController : Controller
    {
        private AppDbContext _dbContext;

        public MugOrderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult CourseConduct()
        {
            //For upcoming courses
            CourseConduct model = new CourseConduct();
            // needs to pull from both AppUser and CourseSchedule DB
            model.TrainerName = User.Identity.Name;

            List<AppUser> appUsers = DBUtl.GetList<AppUser>(@"SELECT * FROM AppUser WHERE Name = '" + model.TrainerName + "'");
            AppUser trainer = appUsers[0];
            model.TrainerName = trainer.Id + trainer.LastLogin;
            model.CourseSchedule = new List<CourseSchedule>();
            model.CourseSchedule = DBUtl.GetList<CourseSchedule>(@"SELECT * FROM CourseSchedule WHERE TrainerId = '" + trainer.Id + "' AND Date >= CURRENT_TIMESTAMP");// " AND AdditionalCourses LIKE " + trainer.Role);
            // model.CourseSchedule = DBUtl.GetList<CourseSchedule>(@"SELECT * FROM CourseSchedule WHERE TrainerId = ''");

            return View(model);
        }

        public IActionResult CourseConducted()
        {
            //For past courses
            CourseConduct model = new CourseConduct();
            // needs to pull from both AppUser and CourseSchedule DB
            model.TrainerName = User.Identity.Name;

            List<AppUser> appUsers = DBUtl.GetList<AppUser>(@"SELECT * FROM AppUser WHERE Name = '" + model.TrainerName + "'");
            AppUser trainer = appUsers[0];
            model.TrainerName = trainer.Id + trainer.LastLogin;
            model.CourseSchedule = new List<CourseSchedule>();
            model.CourseSchedule = DBUtl.GetList<CourseSchedule>(@"SELECT * FROM CourseSchedule WHERE TrainerId = '" + trainer.Id + "' AND Date < CURRENT_TIMESTAMP");// " AND AdditionalCourses LIKE " + trainer.Role);
            // model.CourseSchedule = DBUtl.GetList<CourseSchedule>(@"SELECT * FROM CourseSchedule WHERE TrainerId = ''");

            return View(model);
        }

        [Authorize]
        public IActionResult Index()
        {
            DbSet<MugOrder> dbs = _dbContext.XioHoo;
            List<MugOrder> model = null;
            if (User.IsInRole("Admin"))
                model = dbs.ToList();
            else
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                model = dbs.Where(so => so.CreatedBy == userId).ToList();
            }
            return View(model);
        }

        [Authorize]
        public IActionResult Update(int id)
        {
            var trainer = DBUtl.GetList("SELECT Id FROM MugOrder");
            ViewData["trainer"] = new SelectList(trainer, "Id");

            string userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<MugOrder> lstBooking = DBUtl.GetList<MugOrder>("SELECT * FROM MugOrder WHERE  Id='{0}'",
                id, userid);

            if (lstBooking.Count > 0)
            {
                MugOrder model = lstBooking[0];
                return View(model);
            }
            else
            {
                TempData["Msg"] = $"Trainer {id} not found!";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult Update(MugOrder mugOrder)
        {
            if (ModelState.IsValid)
            {
                DbSet<MugOrder> dbs = _dbContext.XioHoo;
                MugOrder tOrder = dbs.Where(mo => mo.Id == mugOrder.Id)
                                     .FirstOrDefault();

                if (tOrder != null)
                {
                    tOrder.Email = mugOrder.Email;
                    tOrder.FullName = mugOrder.FullName;
                    tOrder.Courses = mugOrder.Courses;
                    tOrder.AdditionalCourses = mugOrder.AdditionalCourses;
                    tOrder.DOB = mugOrder.DOB;

                    

                    if (_dbContext.SaveChanges() == 1)
                        TempData["Msg"] = "Trainer updated!";
                    else
                        TempData["Msg"] = "Database has not been updated, Please ensure that there is a change in data!";
                }
                else
                {
                    TempData["Msg"] = "Trainer not found!";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Msg"] = "Invalid information entered";
            }
            return RedirectToAction("Index");
        }




        //un-comment Ctrl-K + Ctrl-U
        [Authorize]
        public IActionResult AttendanceUpdate(int id)
        {
            var AU = DBUtl.GetList("SELECT CourseID FROM CourseAttendance");
            ViewData["AU"] = new SelectList(AU, "Id");

            // string userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //List<CourseAttendance> lstBooking = DBUtl.GetList<CourseAttendance>("SELECT * FROM CourseAttendance WHERE courseAttendanceId='{0}'", id, userid);

            List<CourseAttendance> model = DBUtl.GetList<CourseAttendance>("SELECT * FROM CourseAttendance WHERE CourseID = " + id);

            if (model.Count > 0)
            {
                //CourseAttendance model = lstBooking[0];
                return View(model);
            }
            else
            {
                TempData["Msg"] = $"Attendance {id} not found!";
                return RedirectToAction("Index");
            }
        }

        //viewing of past courses attendance
        [Authorize]
        public IActionResult AttendanceUpdatedPast(int id)
        {
            var AU = DBUtl.GetList("SELECT CourseID FROM CourseAttendance");
            ViewData["AU"] = new SelectList(AU, "Id");

            // string userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //List<CourseAttendance> lstBooking = DBUtl.GetList<CourseAttendance>("SELECT * FROM CourseAttendance WHERE courseAttendanceId='{0}'", id, userid);

            List<CourseAttendance> model = DBUtl.GetList<CourseAttendance>("SELECT * FROM CourseAttendance WHERE CourseID = " + id);

            if (model.Count > 0)
            {
                //CourseAttendance model = lstBooking[0];
                return View(model);
            }
            else
            {
                TempData["Msg"] = $"Attendance {id} not found!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AttendanceUpdate(List<CourseAttendance> CA)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < CA.Count(); i++)
                {
                    DbSet<CourseAttendance> dbs = _dbContext.CourseAttendance;
                    //CourseAttendance tOrder = dbs.Where(mo => mo.CourseID == CA[i].CourseID).FirstOrfault();
                    CourseAttendance tOrder = dbs.Where(mo => mo.CourseId == CA[i].CourseId &&
                        mo.Participant_Name == CA[i].Participant_Name).FirstOrDefault();

                    
                    if (tOrder != null)
                    {
                        tOrder.Attendance = CA[i].Attendance;

                        if (_dbContext.SaveChanges() == 1)
                            TempData["Msg"] = "Attendance updated!";
                        //else
                            //TempData["Msg"] = "Failed to update database!";
                    }
                    else
                    {
                        TempData["Msg"] = "Failed to update database!";
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                TempData["Msg"] = "Invalid information entered";
            }
            return RedirectToAction("Index");
        }
    }
}